using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solyanka.Domain;
using Solyanka.Domain.Core.Repositories;
using Solyanka.Domain.Persistance;

namespace Solyanka.UI.Controllers
{
    public class JQueryController : Controller
    {
        private readonly IRepository _repository;

        public JQueryController()
        {
            _repository = new Repository(new DataContext());
        }


        public ActionResult JqueryGetTime()
        {
            return View("JqueryGetTime");
        }

        public ActionResult JqueryGetSetPeople()
        {
            return View("JqueryGetSetPeople");
        }

        public ActionResult JquerySetName()
        {
            return View("JquerySetName");
        }

        public ActionResult JqueryAjaxFromAndJsonResult()
        {
            return View("JqueryAjaxFromAndJsonResult");
        }

        public ActionResult JqueryAjaxJSONHandlebars()
        {
            return View("JqueryAjaxJSONHandlebars", _repository.Query<User>().ToList());
        }
    }
}
