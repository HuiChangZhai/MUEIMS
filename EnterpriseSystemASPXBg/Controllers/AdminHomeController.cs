using EnterpriseSystemASPX.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSystemASPXBg.Controllers
{
    public class AdminHomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (!BLLMEnterpriseAdmin.IsLogin())
            {
                return Redirect("~/AdminAccount/Login");
            }
            else
            {
                return View();
            }
        }

    }
}
