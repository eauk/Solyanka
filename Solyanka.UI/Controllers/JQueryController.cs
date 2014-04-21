using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solyanka.UI.Controllers
{
    public class JQueryController : Controller
    {
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
    }
}
