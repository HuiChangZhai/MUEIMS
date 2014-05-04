using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSystemASPX.Models;
using EnterpriseSystemASPX.BLL;

namespace EnterpriseSystemASPX.Controllers
{
    public class EnterpriseController : Controller
    {
        //
        // GET: /Enterprise/

        public ActionResult Index(string name)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPI";
            
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            ViewBag.template = "template1";
            
            return View();
        }

        public ActionResult EPBrief(string name)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPB";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View(); 
        }

        public ActionResult EPDynamic(string name)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPD";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View();
        }

        public ActionResult EPAchieveCase(string name)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPAC";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View();
        }

        public ActionResult EPAboutUs(string name)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPAU";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View();
        }

        public ActionResult NotExists(string name) 
        {
            ViewBag.EPmenu = "EPAU";
            ViewBag.title = name;
            return View();
        }
    }
}
