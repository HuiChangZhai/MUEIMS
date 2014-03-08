using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using EnterpriseSystemASPX.Common;
using EnterpriseSystemASPX.BLL;
using EnterpriseSystemASPX.Models;

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

        public ActionResult SendMessage(string name, string tel, string email, string message)
        {
            MEnterpriseMessage Mmessage = new MEnterpriseMessage();
            Mmessage.MessageEnterpriseName = name;
            Mmessage.MessageEnterpriseTel = tel;
            Mmessage.MessageEnterpriseEmail = email;
            Mmessage.Message = message;
            Mmessage.MessageIsRead = false;
            ViewBag.Menu = "AU";
            if (string.IsNullOrEmpty(name))
                ViewBag.MnameEorror = "请输入公司名称";
            if (string.IsNullOrEmpty(tel))
                ViewBag.MtelEorror = "请输入联系电话";
            if (string.IsNullOrEmpty(message))
                ViewBag.MmessageEorror = "请输入您的留言";
            if (string.IsNullOrEmpty(email))
                ViewBag.MemailEorror = "请输入邮箱地址";
            else
            {
                Regex reg = new Regex(@"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})");
                if (!reg.IsMatch(email)) ViewBag.MemailError = "请输入正确的邮箱地址";
            }
            if (!string.IsNullOrEmpty(ViewBag.MnameEorror) || !string.IsNullOrEmpty(ViewBag.MtelEorror)
                 || !string.IsNullOrEmpty(ViewBag.MmessageEorror) || !string.IsNullOrEmpty(ViewBag.MemailEorror))
                return View("AboutUs");
            BLLMEnterpriseMessage.SetMEnterriseMessage(Mmessage);
            return View("AboutUs");

        }
    }
}
