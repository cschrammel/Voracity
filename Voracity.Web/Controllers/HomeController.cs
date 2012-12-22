using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Voracity.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Voracity";
            return View();
        }

        public ActionResult Play()
        {
            ViewBag.Message = "Play";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About";
            return View();
        }
    }
}
