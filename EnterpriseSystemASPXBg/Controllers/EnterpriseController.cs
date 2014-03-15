using EnterpriseSystemASPX.BLL;
using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSystemASPXBg.Controllers
{
    public class EnterpriseController : Controller
    {
        //
        // GET: /Enterprise/

        private int PageSize = 10;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnterpriseInfos(int? pageCount)
        {
            pageCount = pageCount ?? 0;
            List<Enterprise> enterpriseList = BLLEnterprise.GetEnterpriseList(pageCount.Value, PageSize);
            ViewBag.EnterpriseList = enterpriseList;
            ViewBag.CurrentPage = pageCount.Value;
            return View();
        }

    }
}
