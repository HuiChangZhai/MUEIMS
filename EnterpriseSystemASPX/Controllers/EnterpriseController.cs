using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSystemASPX.Controllers
{
    public class EnterpriseController : Controller
    {
        //
        // GET: /Enterprise/

        public ActionResult Index(string name)
        {
            ViewBag.EPmenu = "EPI";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            ViewBag.template = "template1";
            return View();
        }

        public ActionResult EPBrief(string name)
        {
            ViewBag.EPmenu = "EPB";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View(); 
        }

        public ActionResult EPDynamic(string name)
        {
            ViewBag.EPmenu = "EPD";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View();
        }

        public ActionResult EPAchieveCase(string name)
        {
            ViewBag.EPmenu = "EPAC";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View();
        }

        public ActionResult EPAboutUs(string name)
        {
            ViewBag.EPmenu = "EPAU";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View();
        }
    }
}
