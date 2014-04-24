using System;
using System.Web.Mvc;

namespace Solyanka.UI.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }
    }
}
