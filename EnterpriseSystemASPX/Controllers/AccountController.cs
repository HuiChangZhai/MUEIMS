using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSystemASPX.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login(string email, string pwd)
        {
            //检查是否存在这个用户

            //服务端开始验证数据
            if (string.IsNullOrWhiteSpace(email))
                ViewBag.emailError = "请输入您的邮箱";
            else
            {
                Regex reg = new Regex(@"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})");
                if (!reg.IsMatch(email)) ViewBag.emailError = "请输入正确的邮箱地址";
            }
            if (string.IsNullOrWhiteSpace(pwd))
                ViewBag.pwdError = "请输入您的密码";
            if (string.IsNullOrEmpty(ViewBag.emailError) && string.IsNullOrEmpty(ViewBag.pwdError))
                return View();
            //检查用户输入是否正确

            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
    }
}
