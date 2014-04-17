using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solyanka.UI.Controllers
{
    public class Html5Controller : Controller
    {
        public ActionResult LocalStorage()
        {
            return View("LocalStorage");
        }
    }
}
