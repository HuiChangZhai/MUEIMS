using EnterpriseSystemASPX.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSystemASPX.Models;
using System.Text;
using EnterpriseSystemASPX.Common;
using System.IO;

namespace EnterpriseSystemASPXBg.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(int? pageindex)
        {
            ViewBag.MenuGroup = "EI";
            if (!BLLMEnterpriseAdmin.IsLogin())
                return Redirect("~/AdminAccount/Login");
            ViewBag.MenuTitle = "企业列表";


            PageHelper page = new PageHelper();
            if (!pageindex.HasValue)
                pageindex = 1;
            page.TotalCount = BLLEnterprise.GetEnterprise().Count;
            page.PageNext = pageindex.Value + 1;
            page.PageCurrent = pageindex.Value;
            page.PagePre = pageindex.Value - 1;
            ViewBag.Page = page;
            List<Enterprise> EnterpriseList = BLLEnterprise.GetEnterpriseList(page.PageCurrent - 1, page.PageSize);

            return View(EnterpriseList);
        }

        public ActionResult EnterpriseDetail(int id, string pass)
        {
            ViewBag.MenuGroup = "EI";
            ViewBag.MenuTitle = "企业详情";

            if (id <= 0) return null;
            if (!string.IsNullOrEmpty(pass))
            {
                BLLEnterprise.SetEnterpriseStatus(id, pass == "是" ? true : false);
                ViewBag.result = "success";
            }
            Enterprise enterprise = BLLEnterprise.GetBgEnterprise(id);
            return View(enterprise);
        }

        public ActionResult DeleteEnterprise(int id)
        {
            ViewBag.MenuGroup = "EI";
            ViewBag.MenuTitle = "企业列表";
            BLLEnterprise.DeleteEnterprise(id);
            return Redirect("Index");
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
            List<MEnterpriseMessage> messageList = BLLMEnterpriseMessage.GetPageMessage(page, pageindex.Value);
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
            MEnterprise menterprise = BLLMEnterprise.GetMEnterprise();
            if (menterprise == null)
                menterprise = new MEnterprise();
            return View(menterprise);
        }

        [HttpPost]
        public ActionResult MEnterpriseInfo(string id, string name, string tel, string email, string copy, string address, string shortbrief, string enterpriseLogo_f)
        {
            ViewBag.MenuGroup = "SI";
            ViewBag.MenuTitle = "系统说明";
            MEnterprise menterprise = new MEnterprise();
            int mid = 0;
            if (!string.IsNullOrEmpty(id))
                mid = int.Parse(id);
            menterprise = BLLMEnterprise.GetMEnterprise();
            menterprise.MEnterpriseName = name;
            if (!string.IsNullOrEmpty(tel))
                menterprise.MEnterpriseTelphoneNumber = tel;
            if (!string.IsNullOrEmpty(copy))
                menterprise.MEnterpriseRight = copy;
            if (!string.IsNullOrEmpty(email))
                menterprise.MEnterpriseEmail = email;
            if (!string.IsNullOrEmpty(address))
                menterprise.MEnterpriseAddress = address;
            if (!string.IsNullOrEmpty(shortbrief))
                menterprise.MEnterpriseBriefShort = shortbrief;
            if (!string.IsNullOrEmpty(enterpriseLogo_f))
                menterprise.MEnterpriseLogo = enterpriseLogo_f;
            BLLMEnterprise.UpdateMEnterprise(menterprise);
            ViewBag.Result = "success";
            return View(menterprise);
        }

        public ActionResult MEnterpriseBiref(string action, string brief)
        {
            ViewBag.MenuGroup = "SI";
            ViewBag.MenuTitle = "系统简介";
            if (action == "Save")
            {
                brief = (brief == null ? "" : brief);
                MEnterprise enterprise = BLLMEnterprise.GetMEnterprise();
                BLLMEnterprise.SetMEnterpriseBiref(enterprise == null ? 0 : enterprise.MEnterpriseID, brief);
            }

            ViewBag.CurrentMEnterprise = BLLMEnterprise.GetMEnterprise();

            return View();
        }

        public ActionResult CasesList(int? pageindex)
        {
            ViewBag.MenuGroup = "AC";
            ViewBag.MenuTitle = "案例列表";
            PageHelper page = new PageHelper();
            if (!pageindex.HasValue)
                pageindex = 1;
            page.TotalCount = BLLMEnterpriseCases.GetMEnterpriseCases().Count;
            page.PageNext = pageindex.Value + 1;
            page.PageCurrent = pageindex.Value;
            page.PagePre = pageindex.Value - 1;
            List<MEnterpriseCases> casesList = BLLMEnterpriseCases.GetMEnterpriseCases(page, pageindex.Value);
            ViewBag.Page = page;

            return View(casesList);
        }

        public ActionResult CasesDetail(int id, string show)
        {
            ViewBag.MenuGroup = "AC";
            ViewBag.MenuTitle = "案例详情";
            if (id <= 0) return null;
            if (!string.IsNullOrEmpty(show))
            {
                BLLMEnterpriseMessage.UpdateMEnterriseMessage(id, show == "是" ? true : false);
                ViewBag.result = "success";
            }
            MEnterpriseCases cases = BLLMEnterpriseCases.GetMEnterpriseCases(id);
            return View(cases);
        }

        public ActionResult DeleteCases(int id)
        {
            ViewBag.MenuGroup = "AC";
            ViewBag.MenuTitle = "案例列表";
            BLLMEnterpriseCases.DeleteMEnterpriseCases(id);

            return RedirectToAction("CasesList");
        }

        public ActionResult AddCases(string ename, string eshort, string eurl, string show)
        {
            ViewBag.MenuGroup = "AC";
            ViewBag.MenuTitle = "添加案例";

            List<SelectListItem> selectlist = BLLMEnterpriseCases.GetCasesList();
            ViewBag.selectItem = selectlist;
            //保存到MEnterpriseCases
            if (!string.IsNullOrWhiteSpace(show))
            {
                MEnterpriseCases cases = new MEnterpriseCases();
                cases.MEnterpriseID = 1;
                cases.MEnterpriseCasesTitle = ename;
                cases.MEnterpriseCasesContent = eshort;
                cases.MEnterpriseCaseShow = show == "是" ? true : false;
                cases.MEnterpriseCaseUrl = eurl;

                BLLMEnterpriseCases.InsertMEnterpriseCases(cases);
                ViewBag.Result = "success";
            }
            return View();
        }

        public string AddEnterpriseInfo(int id)
        {
            Enterprise enterprise = BLLEnterprise.GetEnterprise(id);
            StringBuilder builder = new StringBuilder();
            builder.Append("<tr class='enterpriseinfo'><td style='width: 100px;'>企业名称</td><td class='tdContent'>" + enterprise.EnterpriseName ?? "" + "</td></tr>");
            builder.Append("<tr class='enterpriseinfo'><td style='width: 100px;'>企业电话</td><td class='tdContent'>" + enterprise.EnterpriseTelphoneNumber ?? "" + "</td></tr>");
            builder.Append("<tr class='enterpriseinfo'><td style='width: 100px;'>企业邮箱</td><td class='tdContent'>" + enterprise.EnterpriseEmail ?? "" + "</td></tr>");
            builder.Append("<tr class='enterpriseinfo'><td style='width: 100px;'>企业地址</td><td class='tdContent'>" + enterprise.EnterpriseAddress ?? "" + "</td></tr>");
            builder.Append("<tr class='enterpriseinfo'><td style='width: 100px;'>版权声明</td><td class='tdContent'>" + enterprise.EnterpriseRight ?? "" + "</td></tr>");
            //builder.Append("<tr class='enterpriseinfo'><td style='width: 100px;'>注册时间</td><td class='tdContent'>" + enterprise.EnterpriseRegistTime.HasValue ? enterprise.EnterpriseRegistTime.Value.ToString("yyyy-MM-dd") : "" + "</td></tr>");
            builder.Append("<tr class='enterpriseinfo'><td style='width: 100px;'>企业说明</td><td class='tdContent'>" + enterprise.EnterpriseBriefShort ?? "" + "</td></tr>");
            builder.Append("<tr class='enterpriseinfo'><td style='width: 100px;'>企业简介</td><td class='tdContent'>" + enterprise.EnterpriseBrief ?? "" + "</td></tr>");

            builder.Append("<input type='hidden' name='ename' value='" + enterprise.EnterpriseName + "' />");
            builder.Append("<input type='hidden' name='eshort' value='" + enterprise.EnterpriseBriefShort + "' />");
            builder.Append("<input type='hidden' name='eurl' value='" + enterprise.EnterpriseUrl + "' />");
            //builder.Append("<input type='hidden' name='imgurl' value='" + BLLEnterprise.ServerDns + enterprise. + "' />");


            return builder.ToString();
        }
    }
}
