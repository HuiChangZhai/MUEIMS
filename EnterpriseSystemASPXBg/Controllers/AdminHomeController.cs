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

        public ActionResult MessageList(int? pageindex)
        {
            if (!BLLMEnterpriseAdmin.IsLogin())
                return Redirect("~/AdminAccount/Login");
            ViewBag.MenuTitle = "留言列表";
            PageHelper page = new PageHelper();
            if (!pageindex.HasValue)
                pageindex = 1;
            page.TotalCount = BLLMEnterpriseMessage.GetMEnterriseMessage().Count;
            page.PageNext = pageindex.Value + 1;
            page.PageCurrent = pageindex.Value;
            page.PagePre = pageindex.Value - 1;
            List<MEnterpriseMessage> messageList = BLLMEnterpriseMessage.GetPageMessage(page,pageindex.Value);
            ViewBag.Page = page;
            return View(messageList);
        }

        public ActionResult MessageDetail(int id, string read)
        {
            if (id <= 0) return null;            
            if (!string.IsNullOrEmpty(read))
            {
                BLLMEnterpriseMessage.UpdateMEnterriseMessage(id, read == "是" ? true : false);
                ViewBag.result = "success";
            }
            MEnterpriseMessage message = BLLMEnterpriseMessage.GetMEnterriseMessage(id);
            return View(message);
        }

        public ActionResult MessageDelete(int id)
        {
            BLLMEnterpriseMessage.DeleteMEnterriseMessage(id);
            return RedirectToAction("MessageList");
        }
    }
}
