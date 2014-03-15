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
            ViewBag.MenuGroup = "EI";
            if (!BLLMEnterpriseAdmin.IsLogin())
                return Redirect("~/AdminAccount/Login");
            ViewBag.MenuTitle = "企业列表";
            return View();
        }

        public ActionResult MessageList(int? pageindex)
        {
            ViewBag.MenuGroup = "MI";
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
            ViewBag.MenuGroup = "MI";
            ViewBag.MenuTitle = "留言详情";
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
            ViewBag.MenuGroup = "ML";
            ViewBag.MenuTitle = "留言列表";
            BLLMEnterpriseMessage.DeleteMEnterriseMessage(id);
            return RedirectToAction("MessageList");
        }

        public ActionResult MEnterpriseInfo()
        {
            ViewBag.MenuGroup = "SI";
            ViewBag.MenuTitle = "系统说明";
            return View();
        }

        public ActionResult MEnterpriseBiref()
        {
            ViewBag.MenuGroup = "SI";
            ViewBag.MenuTitle = "系统简介";
            return View();
        }

        public ActionResult CasesList()
        {
            ViewBag.MenuGroup = "AC";
            ViewBag.MenuTitle = "案例列表";
            return View();
        }

        public ActionResult AddCases()
        {
            ViewBag.MenuGroup = "AC";
            ViewBag.MenuTitle = "添加案例";
            return View();
        }
    }
}
