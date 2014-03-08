using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSystemASPX;
using EnterpriseSystemASPX.BLL;
using EnterpriseSystemASPX.Models;
using EnterpriseSystemASPX.Common;

namespace EnterpriseSystemASPXBg.Controllers
{
    public class AdminAccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login(string adminname, string password)
        {
            if (string.IsNullOrEmpty(adminname) && string.IsNullOrEmpty(password))
            {
                if (EMSCookie.ReadCookie("AdminCookie") == "")
                {
                    ViewBag.Message = "请登录";
                }
                else
                {
                    ViewBag.Message = "自动登录";
                }
            }
            else 
            {
                MEnterpriseAdmin admin = BLLMEnterpriseAdmin.AdminLogin(adminname, password);
                if (admin == null)
                {
                    ViewBag.Message = "登录失败";
                }
                else
                {
                    ViewBag.Message = "已经登录";
                    EMSCookie.AddCookie("AdminCookie", adminname);
                }
            }
            return View();
        }

    }
}
