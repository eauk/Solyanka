using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Solyanka.Domain;
using Solyanka.Domain.Core.Repositories;
using Solyanka.Domain.Core.WhereSpec;
using Solyanka.Domain.Events;
using Solyanka.Domain.Persistance;
using Solyanka.Domain.Specifications;
using Solyanka.UI.Models;

namespace Solyanka.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepository _repository;

        private SendEmailEvent _smEvent;

        //1 private delegate void SendEmailDel(string email, string name, string confirmString);
        
        public AccountController()
        {
            _repository = new Repository(new DataContext());
            _smEvent = new SendEmailEvent();
        }

        [HttpGet, Authorize]
        public ActionResult MyRoom()
        {
            return View("MyRoom");
        }

        [HttpGet]
        public ActionResult SignUp()
        {
            return View("SignUp");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(SingupVm model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password != model.ConfirmPassword)
                {
                    ModelState.AddModelError("", Consts.PasswordsDoNotMatchMessage);
                    return View(model);
                }

                var user = _repository.Query(whereSpecification: new UserByEmailWhereSpec(model.Email)).FirstOrDefault();

                if (user != null)
                {
                    ModelState.AddModelError("", Consts.InvalidEmailMessage);
                    return View(model);
                }
                else
                {
                    var newUser = new User()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.UserName,
                        Email = model.Email,
                        Password = CryptoLibrary.Md5(model.Password),
                        ConfirmString = Guid.NewGuid().ToString()
                        //Password = CreatePassword.GetHashPassword(model.Password)  //SHA1
                    };
                    _repository.Save(newUser);

                    
                    //1 SendEmailDel del = SendEmailMethod;
                    //1 del.Invoke(model.Email, model.UserName, newUser.ConfirmString);
                   
                   
                    //2 Action<string, string, string> del = SendEmailMethod;
                    //2 del.Invoke(model.Email, model.UserName, newUser.ConfirmString);
                   
                   
                    //3 Action<string, string, string> del = (email, name, confirm) =>
                    //3                            {
                    //3                                var netEmail = new NetEmail();
                    //3                                netEmail.Send(email, name, confirm);
                    //3                            };
                    //3 del(model.Email, model.UserName, newUser.ConfirmString);
                    
                    //4 int x = 0;
                    //4 _smEvent.Send += (sender, args) => { x = 1; }; //в цепочку событий добавляем первый обработчик (подписчик)
                    //4 _smEvent.Send += (sender, args) => { x += 5; }; //в цепочку событий добавляем еще один обработчик (подписчик)
                    //4 _smEvent.Send += (sender, args) => Auth(model.Email, newUser.Id.ToString(), persistence: true);

                    //4 _smEvent.OnSend(new SendEmailEventArgs(model.Email, model.UserName, newUser.ConfirmString));
                    //метод OnSend отсылает письмо и вызывает все подписчики => вычисляет х и авторизуется

                    var subscriber = new SendEmailSubscriber();
                    _smEvent.Send += (sender, args) => Auth(model.Email, newUser.Id.ToString(), persistence: true);
                    _smEvent.Send += (sender, args) => subscriber.Subscribe(model.Email, model.UserName, newUser.ConfirmString);
                    _smEvent.OnSend();

                    
                    //sendEmail.Send += subscriber.HandleEvent;
                    //sendEmail.OnSend();

                  
                    return RedirectToAction("MyRoom");
                }    
            }
            else
                ModelState.AddModelError("", Consts.InvalidAllMessage);

            return View(model);
        }

        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("LogIn");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(LoginVm model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = _repository.Query(whereSpecification: new UserByEmailWhereSpec(model.UserName)
                    .And(new UserByPasswordWhereSpec(CryptoLibrary.Md5(model.Password))))
                    .FirstOrDefault();

                if (user == null)
                {
                    user = _repository.Query(whereSpecification: new UserByNameWhereSpec(model.UserName)
                    .And(new UserByPasswordWhereSpec(CryptoLibrary.Md5(model.Password))))
                    .FirstOrDefault();

                    if (user == null)
                    {
                        ModelState.AddModelError("", Consts.InvalidNameOrPassMessage);
                        return View(model);
                    }
                }

                Auth(user.Email, user.Id.ToString(), model.RememberMe);
                return RedirectToLocal(returnUrl);
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Email(string confirmString)
        {
            var user = _repository.Query(whereSpecification: new UserByConfirmStringWhereSpec(confirmString)).FirstOrDefault();

            if(user == null)
                return RedirectToAction("FailedConfirm");
            else
            {
                user.ConfirmString = "Confirmed";
                user.EmailConfirmed = true;
                _repository.SaveOrUpdate(user);
                return RedirectToAction("SucceedConfirm");
            }
        }

        [HttpGet]
        public ActionResult FailedConfirm()
        {
            return View("FailedConfirm");
        }

        [HttpGet]
        public ActionResult SucceedConfirm()
        {
            return View("SucceedConfirm");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LogIn");
        }

        private void Auth(string name, string id, bool persistence)
        {
            DateTime expiration = persistence ? DateTime.Now.AddDays(Consts.CountPersistence) : DateTime.Now.AddMinutes(Consts.CountPersistence);
            string encryptTick = FormsAuthentication.Encrypt(new FormsAuthenticationTicket(1, name, DateTime.Now, expiration, true, id));

            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTick);
            System.Web.HttpContext.Current.Response.Cookies.Add(cookie);
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);
            else
                return RedirectToAction("MyRoom", "Account");
        }

        //private  void SendEmailMethod(string email, string name, string confirmString)
        //{
        //    var netEmail = new NetEmail();
        //    netEmail.Send(email, name, confirmString);
        //}
        
    }

    
}
