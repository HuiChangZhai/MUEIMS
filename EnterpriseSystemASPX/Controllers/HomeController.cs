using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSystemASPX.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            ViewBag.Menu = "IX";
            
            return View();
        }

        public ActionResult AchieveCase()
        {
            ViewBag.Menu = "AC";
            return View();
        }

        public ActionResult ManagementBrief()
        {
            ViewBag.Menu = "MB";
            return View();
        }

        public ActionResult HelpMessage()
        {
            ViewBag.Menu = "HM";
            return View();
        }

        public ActionResult AboutUs()
        {
            ViewBag.Menu = "AU";
            return View();
        }

        
    }
}
