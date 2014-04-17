﻿using System;
using System.Linq;
using System.Web.Mvc;
using Solyanka.Domain;
using Solyanka.Domain.Core.Repositories;
using Solyanka.Domain.Persistance;

namespace Solyanka.UI.Controllers
{
    
    public class AjaxTestController : Controller
    {
        private readonly IRepository _repository;

        public AjaxTestController()
        {
            _repository = new Repository(new DataContext());
        }
        public string TellMeTime()
        {
            return DateTime.Now.ToString();
        }

        public string WelcomeMsg(string input)
        {
            if (!String.IsNullOrEmpty(input))
                return "Please welcome " + input + ".";
            else
                return "Please enter your name.";
        }

        public ActionResult People()
        {
            var peoples = _repository.Query<User>().ToList();
            return Json(peoples, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult People(string name)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = name
            };
            _repository.Save(user);
            return null;
        }

        [HttpPost]
        public ActionResult SaveData(string userName, string age, string note)
        {
            var user = new User()
            {
                Id = Guid.NewGuid(),
                Name = userName,
                Email = age,
                Password = note
            };
            _repository.Save(user);
            return Json(user, JsonRequestBehavior.AllowGet);
        }
    }
}
