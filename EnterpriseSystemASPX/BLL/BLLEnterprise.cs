using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using EnterpriseSystemASPX.Common;
using EnterpriseSystemASPX.DAL;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.BLL
{
    [Serializable]
    public static class BLLEnterprise
    {
        public static Enterprise Current
        {
            get 
            {
                string email = EMSCookie.ReadCookie("EnterpriseCookie");
                if (string.IsNullOrWhiteSpace(email)) return null;
                Enterprise _enterprise = ExistEnterprise(email);
                return ExistEnterprise(email);
            }
        }

        public static Enterprise IsLogin(string email, string pwd)
        {
            Enterprise enterprise = BLLEnterprise.GetEnterprise(email, pwd);
            if (enterprise == null) return null;
            EMSCookie.AddCookie("EnterpriseCookie", email);

            return enterprise;
        }

        public static void Logout()
        {
            EMSCookie.DeleteCookie("EnterpriseCookie");
            //HttpContext.Current.Session["AdminSession"] = null;
        }

        public static List<Enterprise> GetEnterprise()
        {
            DALEnterprise _DAL = new DALEnterprise();
            List<Enterprise> list = _DAL.GetEnterprise();

            return list;
        }

        public static Enterprise GetEnterprise(string enterpriseemail, string enterprisepwd)
        {
            DALEnterprise _DAL = new DALEnterprise();
            Enterprise enterprise = _DAL.GetEnterprise(enterpriseemail, enterprisepwd);

            return enterprise;
        }

        public static Enterprise ExistEnterprise(string enterpriseemail)
        {
            DALEnterprise _DAL = new DALEnterprise();
            Enterprise enterprise = _DAL.ExistEnterprise(enterpriseemail);

            return enterprise;
        }
    }
}