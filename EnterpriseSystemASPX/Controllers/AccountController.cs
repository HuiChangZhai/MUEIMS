using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

        public ActionResult Login(string useremail, string userpwd, bool? rememberme)
        {
            if (string.IsNullOrEmpty(useremail) && string.IsNullOrEmpty(userpwd))
                return View();
            //服务端开始验证数据
            if (string.IsNullOrWhiteSpace(useremail))
                ViewBag.emailError = "请输入您的邮箱";
            else
            {
                Regex reg = new Regex(@"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})");
                if (!reg.IsMatch(useremail)) ViewBag.emailError = "请输入正确的邮箱地址";
            
                //检查是否存在这个用户
                Enterprise existEnterprise = BLLEnterprise.ExistEnterprise(useremail);
                if (existEnterprise == null) ViewBag.emailError = "该邮箱地址不存在";
            }
            if (string.IsNullOrWhiteSpace(userpwd))
                ViewBag.pwdError = "请输入您的密码";
            if (!string.IsNullOrEmpty(ViewBag.emailError) || !string.IsNullOrEmpty(ViewBag.pwdError))
                return View();
            //检查用户输入是否正确
            Enterprise _enterprise = BLLEnterprise.GetEnterprise(useremail, userpwd);
            string loginError = string.Empty;
            if (_enterprise == null)
                loginError = "邮箱密码错误";
            else if(!_enterprise.EnterpriseActive.HasValue || !_enterprise.EnterpriseActive.Value)
                loginError = "您的账户未激活，请联系网站内部人员";
            if (!string.IsNullOrEmpty(loginError))
                return View();
            return Redirect("~/Home/Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Logout()
        {
            BLLEnterprise.Logout();
            return Redirect("~/Home/Index");
        }
    }
}
