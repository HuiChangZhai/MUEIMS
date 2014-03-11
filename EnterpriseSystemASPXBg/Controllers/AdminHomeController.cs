using EnterpriseSystemASPX.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPXBg.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (!BLLMEnterpriseAdmin.IsLogin())
                return Redirect("~/AdminAccount/Login");
            ViewBag.MenuTitle = "企业列表";
            return View();
        }

        public ActionResult MessageList()
        {
            if (!BLLMEnterpriseAdmin.IsLogin())
                return Redirect("~/AdminAccount/Login");
            ViewBag.MenuTitle = "留言列表";
            List<MEnterpriseMessage> messageList = BLLMEnterpriseMessage.GetMEnterriseMessage();

            return View(messageList);
        }

    }
}
