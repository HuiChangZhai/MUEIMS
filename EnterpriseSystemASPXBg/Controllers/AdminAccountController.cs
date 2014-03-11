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
            if (string.IsNullOrWhiteSpace(adminname) && string.IsNullOrWhiteSpace(password))
                return View();
            if (string.IsNullOrEmpty(adminname))
                ViewBag.Message = "请输入用户名";
            else if (string.IsNullOrEmpty(password))
                ViewBag.Message = "请输入密码";
            if (BLLMEnterpriseAdmin.Login(adminname, password))
                return Redirect("~/AdminHome/Index");
            else
                ViewBag.Message = "用户名密码错误";

            return Redirect("~/AdminHome/Index");
        }

        public ActionResult Logout()
        {
            BLLMEnterpriseAdmin.Logout();
            return Redirect("~/AdminAccount/Login");
        }

        public ActionResult ChangePassword(string username, string newpwd, string comfirmpwd)
        {
            ViewBag.MenuTitle = "修改密码"; 
            if (string.IsNullOrWhiteSpace(newpwd) && string.IsNullOrWhiteSpace(comfirmpwd))
                return View();
            if (!BLLMEnterpriseAdmin.IsLogin())
                return Redirect("~/AdminHome/Index");
            if (string.IsNullOrEmpty(newpwd))
                ViewBag.Newpwderror = "请输入新密码";
            if (string.IsNullOrEmpty(comfirmpwd))
                ViewBag.Comfirmerror = "请输入确认密码";
            else if(newpwd.Trim()!=comfirmpwd.Trim())
                ViewBag.Comfirmerror = "密码不一致";
            if (BLLMEnterpriseAdmin.ChangeAdminPwd(username, newpwd))
                ViewBag.SaveResult = "修改成功";
            else
                ViewBag.SaveResult = "修改失败";
            return View();
        }
    }
}
