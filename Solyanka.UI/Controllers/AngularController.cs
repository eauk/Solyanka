using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solyanka.UI.Controllers
{
    public class AngularController : Controller
    {

        public ActionResult Lesson1()
        {
            return View("Lesson1");
        }

        public ActionResult Lesson2()
        {
            return View("Lesson2");
        }

        public ActionResult Lesson3()
        {
            return View("Lesson3");
        }

        public ActionResult Lesson4()
        {
            return View("Lesson4");
        }

    }
}
