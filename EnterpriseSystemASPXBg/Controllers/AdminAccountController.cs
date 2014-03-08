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
                if (!BLLMEnterpriseAdmin.IsLogin())
                {
                    ViewBag.Message = "";
                }
                else
                {
                    return Redirect("~/AdminHome/Index");
                }
            }
            else
            {
                if (BLLMEnterpriseAdmin.Login(adminname, password))
                {
                    return Redirect("~/AdminHome/Index");
                }
                else
                {
                    ViewBag.Message = "登录失败";
                }
            }

            return View();
        }

        public ActionResult Logout()
        {
            BLLMEnterpriseAdmin.Logout();
            return Redirect("~/AdminAccount/Login");
        }
    }
}
