using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSystemASPX.BLL;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login(string enterpriseEmail, string password)
        {
            if (enterpriseEmail != null && password != null)
            {
                Enterprise enterprise = BLLEnterprise.Login(enterpriseEmail, password);
                if(enterprise != null)
                {
                    ViewBag.Message = "登录成功。";
                }
                else
                {
                    ViewBag.Message = "登录失败!";
                }
                return View();
            }
            else
            {
                ViewBag.Message = "请登录。";
                return View();
            }
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}
