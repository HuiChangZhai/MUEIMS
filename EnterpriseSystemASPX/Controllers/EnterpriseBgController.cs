﻿using EnterpriseSystemASPX.BLL;
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

        public ActionResult Index(int? pageCount)
        {
            pageCount = pageCount ?? 0;
            List<Enterprise> enterpriseList = BLLEnterprise.GetEnterpriseList(0, PageSize);
            ViewBag.EnterpriseList = enterpriseList;
            return View();
        }

        public ActionResult EnterpriseInfo()
        {
            return View();
        }

        public ActionResult EnterpriseInfoEdit()
        {
            return View();
        }

        public ActionResult EnterpriseCaseList()
        {
            return View();
        }

        public ActionResult EnterpriseCaseEdit()
        {
            return View();
        }

        public ActionResult EnterpriseCaseAdd()
        {
            return View();
        }

        public ActionResult EnterpriseDynamicList()
        {
            return View();
        }

        public ActionResult EnterpriseDynamicEdit()
        {
            return View();
        }

        public ActionResult EnterpriseDynamicAdd()
        {
            return View();
        }
    }
}
