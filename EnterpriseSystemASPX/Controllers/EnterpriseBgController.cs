using EnterpriseSystemASPX.BLL;
using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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

            bool validData = true;

            validData = validData && (!string.IsNullOrEmpty(enterpriseName) && new Regex(@"^([\w]|[\u4E00-\u9FA5]){2,20}$").IsMatch(enterpriseName));
            validData = validData && (!string.IsNullOrEmpty(enterpriseEmail) && new Regex(@"^(([\w-\s]+)|([\w-]+(?:\.[\w-]+)*)|([\w-\s]+)([\w-]+(?:\.[\w-]+)*))(@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$)|(@\[?((25[0-5]\.|2[0-4][0-9]\.|1[0-9]{2}\.|[0-9]{1,2}\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\.){2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\]?$)",RegexOptions.IgnoreCase).IsMatch(enterpriseEmail));
            validData = validData && (!string.IsNullOrEmpty(enterpriseTelphoneNumber) && new Regex(@"^\+?(\d[\d\-\+\(\) ]{5,}\d$)").IsMatch(enterpriseTelphoneNumber));
            validData = validData && (!string.IsNullOrEmpty(enterpriseAddress));
            
            if (validData)
            {
                if (BLLEnterprise.SaveEnterpriseInfoChanges(BLLEnterprise.Current.EnterpriseID, enterpriseName, enterpriseUrl, enterpriseAddress, enterpriseTelphoneNumber, enterpriseEmail, enterpriseRight, EnterpriseLogo))
                {
                    return Redirect("~/EnterpriseBg/EnterpriseInfo");
                }
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

        public ActionResult EnterpriseCaseList(int? page)
        {
            page = page ?? 1;
            if (page < 1) 
            {
                page = 1;
            }

            ViewBag.MenuGroup = "Case";
            ViewBag.PageTitle = "成功案例";

            PageHelper pageHelper = new PageHelper();
            if (!page.HasValue)
                page = 1;
            pageHelper.TotalCount = BLLEnterpriseCases.EnterpriseCases(BLLEnterprise.Current.EnterpriseID).Count;
            pageHelper.PageNext = page.Value + 1;
            pageHelper.PageCurrent = page.Value;
            pageHelper.PagePre = page.Value - 1;
            ViewBag.pageHelper = pageHelper;
            List<EnterpriseCases> EnterpriseCasesList = BLLEnterpriseCases.GetEnterpriseCasesList(pageHelper.PageCurrent - 1, pageHelper.PageSize);

            return View(EnterpriseCasesList);
        }

        public ActionResult EnterpriseCaseEdit(int? EnterpriseCaseID, string enterpriseCaseTitle, string enterpriseCaseContent)
        {
            ViewBag.MenuGroup = "Case";
            ViewBag.PageTitle = "编辑成功案例";

            EnterpriseCases enterpriseCase = null;
            if (EnterpriseCaseID.HasValue)
            {
                enterpriseCase = BLLEnterpriseCases.EnterpriseCaseByEnterpriseCaseID(EnterpriseCaseID.Value);
                if (enterpriseCase == null)
                {
                    ViewBag.ErrorMessage = "没有查询到指定的成功案例。";
                }
                else if (!string.IsNullOrEmpty(enterpriseCaseTitle) && !string.IsNullOrEmpty(enterpriseCaseContent))
                {
                    if (BLLEnterpriseCases.EnterpriseCaseEdit(EnterpriseCaseID.Value, enterpriseCaseTitle, enterpriseCaseContent))
                    {
                        return Redirect("~/EnterpriseBg/EnterpriseCaseList");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "修改失败。";
                    }
                }
            }
            else
            {
                ViewBag.ErrorMessage = "没有查询到指定的成功案例。";
            }

            return View(enterpriseCase);
        }

        public ActionResult EnterpriseCaseAdd(string enterpriseCaseTitle, string enterpriseCaseContent)
        {
            enterpriseCaseTitle = enterpriseCaseTitle ?? "";
            enterpriseCaseContent = enterpriseCaseContent ?? "";
            if (enterpriseCaseTitle != "")
            {
                if (BLLEnterpriseCases.AddEnterpriseCase(BLLEnterprise.Current.EnterpriseID, enterpriseCaseTitle, enterpriseCaseContent)) {
                    return Redirect("/EnterpriseBg/EnterpriseCaseList");
                }
            }

            ViewBag.MenuGroup = "Case";
            ViewBag.PageTitle = "添加成功案例";

            return View();
        }

        public ActionResult EnterpriseCaseDetail(int? EnterpriseCaseID) 
        {
            ViewBag.MenuGroup = "Case";
            ViewBag.PageTitle = "成功案例";

            ViewBag.ErrorMessage = "";
            EnterpriseCases enterpriseCase = null;
            if (EnterpriseCaseID.HasValue)
            {
                enterpriseCase = BLLEnterpriseCases.EnterpriseCaseByEnterpriseCaseID(EnterpriseCaseID.Value);
                if (enterpriseCase == null) 
                {
                    ViewBag.ErrorMessage = "没有查询到指定的成功案例。";
                }
            }
            else {
                ViewBag.ErrorMessage = "没有查询到指定的成功案例。";
            }

            return View(enterpriseCase);
        }

        public ActionResult EnterpriseCaseDelete(int? EnterpriseCaseID)
        {
            ViewBag.MenuGroup = "Case";
            ViewBag.PageTitle = "成功案例";

            ViewBag.ErrorMessage = "";
            EnterpriseCases enterpriseCase = null;
            if (EnterpriseCaseID.HasValue)
            {
                enterpriseCase = BLLEnterpriseCases.EnterpriseCaseByEnterpriseCaseID(EnterpriseCaseID.Value);
                if (enterpriseCase != null && enterpriseCase.EnterpriseID == BLLEnterprise.Current.EnterpriseID)
                {
                    if (BLLEnterpriseCases.EnterpriseCaseDelete(EnterpriseCaseID.Value))
                    {
                        return Redirect("EnterpriseCaseList");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "没有权限删除该记录！";
                }
            }
            else
            {
                return Redirect("EnterpriseCaseList");
            }

            return View();
        }

        public ActionResult EnterpriseDynamicList(int? page)
        {
            page = page ?? 1;
            if (page < 1)
            {
                page = 1;
            }

            ViewBag.MenuGroup = "Dynamic";
            ViewBag.PageTitle = "企业动态";

            PageHelper pageHelper = new PageHelper();
            if (!page.HasValue)
                page = 1;
            pageHelper.TotalCount = BLLEnterpriseDynamic.EnterpriseDynamics(BLLEnterprise.Current.EnterpriseID).Count;
            pageHelper.PageNext = page.Value + 1;
            pageHelper.PageCurrent = page.Value;
            pageHelper.PagePre = page.Value - 1;
            ViewBag.pageHelper = pageHelper;
            List<EnterpriseDynamic> EnterpriseDynamicsList = BLLEnterpriseDynamic.EnterpriseDynamic(pageHelper.PageCurrent - 1, pageHelper.PageSize);

            return View(EnterpriseDynamicsList);
        }

        public ActionResult EnterpriseDynamicEdit(int? EnterpriseDynamicID, string enterpriseDynamicTitle, string enterpriseDynamicContent)
        {
            ViewBag.MenuGroup = "Dynamic";
            ViewBag.PageTitle = "编辑企业动态";

            EnterpriseDynamic enterpriseDynamic = null;
            if (EnterpriseDynamicID.HasValue)
            {
                enterpriseDynamic = BLLEnterpriseDynamic.EnterpriseDynamicByEnterpriseDynamicID(EnterpriseDynamicID.Value);
                if (enterpriseDynamic == null)
                {
                    ViewBag.ErrorMessage = "没有查询到指定的成功案例。";
                }
                else if (!string.IsNullOrEmpty(enterpriseDynamicTitle) && !string.IsNullOrEmpty(enterpriseDynamicContent))
                {
                    if (BLLEnterpriseDynamic.EnterpriseDynamicEdit(EnterpriseDynamicID.Value, enterpriseDynamicTitle, enterpriseDynamicContent))
                    {
                        return Redirect("~/EnterpriseBg/EnterpriseDynamicList");
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "修改失败。";
                    }
                }
            }
            else
            {
                ViewBag.ErrorMessage = "没有查询到指定的成功案例。";
            }

            return View(enterpriseDynamic);
        }

        public ActionResult EnterpriseDynamicAdd(string enterpriseDynamicTitle, string enterpriseDynamicContent)
        {
            enterpriseDynamicTitle = enterpriseDynamicTitle ?? "";
            enterpriseDynamicContent = enterpriseDynamicContent ?? "";
            if (enterpriseDynamicTitle != "")
            {
                if (BLLEnterpriseDynamic.AddEnterpriseDynamic(BLLEnterprise.Current.EnterpriseID, enterpriseDynamicTitle, enterpriseDynamicContent))
                {
                    return Redirect("/EnterpriseBg/EnterpriseDynamicList");
                }
            }

            ViewBag.MenuGroup = "Dynamic";
            ViewBag.PageTitle = "添加企业动态";

            return View();
        }

        public ActionResult EnterpriseDynamicDetail(int? EnterpriseDynamicID)
        {
            ViewBag.ErrorMessage = "";
            EnterpriseDynamic enterpriseDynamic = null;
            if (EnterpriseDynamicID.HasValue)
            {
                enterpriseDynamic = BLLEnterpriseDynamic.EnterpriseDynamicByEnterpriseDynamicID(EnterpriseDynamicID.Value);
                if (enterpriseDynamic == null)
                {
                    ViewBag.ErrorMessage = "没有查询到指定的成功案例。";
                }
            }
            else
            {
                ViewBag.ErrorMessage = "没有查询到指定的成功案例。";
            }

            return View(enterpriseDynamic);
        }

        public ActionResult EnterpriseDynamicDelete(int? EnterpriseDynamicID)
        {
            ViewBag.ErrorMessage = "";
            EnterpriseDynamic enterpriseDynamic = null;
            if (EnterpriseDynamicID.HasValue)
            {
                enterpriseDynamic = BLLEnterpriseDynamic.EnterpriseDynamicByEnterpriseDynamicID(EnterpriseDynamicID.Value);
                if (enterpriseDynamic != null && enterpriseDynamic.EnterpriseID == BLLEnterprise.Current.EnterpriseID)
                {
                    if (BLLEnterpriseDynamic.EnterpriseDynamicDelete(EnterpriseDynamicID.Value))
                    {
                        return Redirect("EnterpriseDynamicList");
                    }
                }
                else
                {
                    ViewBag.ErrorMessage = "没有权限删除该记录！";
                }
            }
            else
            {
                return Redirect("EnterpriseDynamicList");
            }

            return View();
        }

        public ActionResult ChangePassword(string oldpassword, string password, string repassword)
        {
            ViewBag.MenuGroup = "Password";
            ViewBag.PageTitle = "修改密码";

            if(oldpassword == BLLEnterprise.Current.EnterprisePassword)
            {
                if(password == repassword && BLLEnterprise.ChangePassword(BLLEnterprise.Current.EnterpriseID,password))
                {
                    Response.Write("Success");
                    Response.Flush();
                    Response.End();
                }
            }

            return View();
        }
    }
}
