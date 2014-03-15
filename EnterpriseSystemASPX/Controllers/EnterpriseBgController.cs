using EnterpriseSystemASPX.BLL;
using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSystemASPX.Controllers
{
    public class EnterpriseBgController : Controller
    {
        //
        // GET: /EnterpriseBg/
        private int PageSize = 10;

        public ActionResult Index()
        {
            ViewBag.MenuGroup = "Info";
            ViewBag.PageTitle = "企业信息";
            ViewBag.CurrentEnterprise = BLLEnterprise.Current;

            return View("~/Views/EnterpriseBg/EnterpriseInfo.aspx");
        }
        
        public ActionResult EnterpriseInfo()
        {
            ViewBag.MenuGroup = "Info";
            ViewBag.PageTitle = "企业信息";
            ViewBag.CurrentEnterprise = BLLEnterprise.Current;

            return View();
        }

        public ActionResult EnterpriseInfoEdit(string enterpriseName, string enterpriseUrl, string enterpriseAddress, string enterpriseTelphoneNumber, string enterpriseEmail, string enterpriseRight, string EnterpriseLogo)
        {
            ViewBag.MenuGroup = "Info";
            ViewBag.PageTitle = "编辑企业信息";

            if (true)
            {
                BLLEnterprise.SaveEnterpriseInfoChanges(BLLEnterprise.Current.EnterpriseID,enterpriseName, enterpriseUrl,enterpriseAddress,enterpriseTelphoneNumber,enterpriseEmail,enterpriseRight,EnterpriseLogo);
            }

            if (!BLLEnterprise.IsLogin())
                return Redirect("~/Home");

            ViewBag.CurrentEnterprise = BLLEnterprise.Current;

            return View();
        }

        public ActionResult EnterpriseBrief(string action,string brief)
        {
            if (!BLLEnterprise.IsLogin())
                return Redirect("~/Home");

            ViewBag.MenuGroup = "Info";
            ViewBag.PageTitle = "企业简介";

            if (action == "Save")
            {
                brief = (brief == null ? "" : brief);
                BLLEnterprise.SetEnterpriseBrief(BLLEnterprise.Current.EnterpriseID, brief);
            }

            ViewBag.CurrentEnterprise = BLLEnterprise.Current;

            return View();
        }

        public ActionResult EnterpriseCaseList()
        {
            ViewBag.MenuGroup = "Case";
            ViewBag.PageTitle = "成功案例";
            return View();
        }

        public ActionResult EnterpriseCaseEdit()
        {
            ViewBag.MenuGroup = "Case";
            ViewBag.PageTitle = "编辑成功案例";
            return View();
        }

        public ActionResult EnterpriseCaseAdd()
        {
            ViewBag.MenuGroup = "Case";
            ViewBag.PageTitle = "添加成功案例";
            return View();
        }

        public ActionResult EnterpriseDynamicList()
        {
            ViewBag.MenuGroup = "Dynamic";
            ViewBag.PageTitle = "企业动态";
            return View();
        }

        public ActionResult EnterpriseDynamicEdit()
        {
            ViewBag.MenuGroup = "Dynamic";
            ViewBag.PageTitle = "编辑企业动态";
            return View();
        }

        public ActionResult EnterpriseDynamicAdd()
        {
            ViewBag.MenuGroup = "Dynamic";
            ViewBag.PageTitle = "添加企业动态";
            return View();
        }

        public ActionResult ChangePassword(string password)
        {
            return View();
        }
    }
}
