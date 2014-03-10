﻿using System;
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
                return ExistEnterprise(email);
            }
        }

        public static bool IsLogin(string email, string pwd)
        {
            Enterprise enterprise = BLLEnterprise.GetEnterprise(email, pwd);
            if (enterprise == null) return false;
            EMSCookie.AddCookie("EnterpriseCookie", email);

            bool isLoginSuccess = enterprise != null;

            return isLoginSuccess;
        }

        public static void Logout()
        {
            EMSCookie.DeleteCookie("EnterpriseCookie");
            //HttpContext.Current.Session["AdminSession"] = null;
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

        public static List<Enterprise> GetEnterpriseList(int page, int pageSize)
        {
            DALEnterprise _DAL = new DALEnterprise();
            List<Enterprise> enterpriseList = _DAL.GetEnterpriseList(page, pageSize);

            return enterpriseList;
        }
    }
}