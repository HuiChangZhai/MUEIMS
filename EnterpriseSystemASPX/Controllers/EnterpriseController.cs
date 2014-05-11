using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EnterpriseSystemASPX.Models;
using EnterpriseSystemASPX.BLL;

namespace EnterpriseSystemASPX.Controllers
{
    public class EnterpriseController : Controller
    {
        //
        // GET: /Enterprise/

        public ActionResult Index(string name)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPI";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;

            List<EnterpriseCases> EnterpriseCaseList = BLLEnterpriseCases.GetEnterpriseCasesList(entreprise.EnterpriseID, 0, 50);
            ViewBag.EnterpriseCaseList = EnterpriseCaseList;

            List<EnterpriseDynamic> EnterpriseDynamicList = BLLEnterpriseDynamic.EnterpriseDynamic(entreprise.EnterpriseID, 0, 50);
            ViewBag.EnterpriseDynamicList = EnterpriseDynamicList;

            return View();
        }

        public ActionResult EPBrief(string name)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPB";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View(); 
        }

        public ActionResult EPDynamic(string name, int? enterpriseDynamicID, int? currentPage)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPD";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;

            if (enterpriseDynamicID != null)
            {
                EnterpriseDynamic dynamic =BLLEnterpriseDynamic.EnterpriseDynamicByEnterpriseDynamicID(enterpriseDynamicID.Value);
                if (dynamic.Enterprise.EnterpriseID == entreprise.EnterpriseID)
                {
                    ViewBag.EnterpriseDynamic = dynamic;
                }
                
                return View("/Views/Enterprise/EPDynamicDetail.aspx");
            }

            int page = 1;
            if (currentPage != null)
            {
                page = currentPage.Value;
            }

            List<EnterpriseDynamic> dynamicList = BLLEnterpriseDynamic.EnterpriseDynamics(entreprise.EnterpriseID);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = dynamicList.Count() / 9 + (dynamicList.Count() % 9 == 0 ? 0 : 1);

            List<EnterpriseDynamic> list = BLLEnterpriseDynamic.EnterpriseDynamic(entreprise.EnterpriseID, page - 1, 9);

            return View(list);
        }

        public ActionResult EPAchieveCase(string name,int? enterpriseCaseID,int? currentPage)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPAC";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;

            if (enterpriseCaseID != null)
            {
                EnterpriseCases enterpriseCase = BLLEnterpriseCases.EnterpriseCaseByEnterpriseCaseID(enterpriseCaseID.Value);
                if (enterpriseCase.Enterprise.EnterpriseID == entreprise.EnterpriseID)
                {
                    ViewBag.EnterpriseCase = enterpriseCase;
                }

                return View("/Views/Enterprise/EPAchieveCaseDetail.aspx");
            }
            int page = 1;
            if (currentPage != null)
            {
                page = currentPage.Value;
            }

            List<EnterpriseCases> caseList = BLLEnterpriseCases.EnterpriseCases(entreprise.EnterpriseID);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPage = caseList.Count() / 9 + (caseList.Count() % 9 == 0 ? 0 : 1);

            List<EnterpriseCases> list = BLLEnterpriseCases.GetEnterpriseCasesList(entreprise.EnterpriseID, page - 1, 9);

            return View(list);
        }

        public ActionResult EPAboutUs(string name)
        {
            Enterprise entreprise = BLLEnterprise.GetEnterprise(name);
            if (null != entreprise)
                ViewBag.Enterprise = entreprise;
            else
                return Redirect("~/Enterprise/" + name + "/NotExists");

            ViewBag.EPmenu = "EPAU";
            ViewBag.title = name == null ? "多企业用户管理系统" : name;
            return View();
        }

        public ActionResult NotExists(string name) 
        {
            ViewBag.EPmenu = "EPAU";
            ViewBag.title = name;
            return View();
        }
    }
}
