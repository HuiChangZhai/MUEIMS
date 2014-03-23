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

        public static string ServerDns
        {
            get
            {
                string strUri = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
                strUri = strUri.Substring(strUri.IndexOf(":") + 3);
                strUri = strUri.Substring(0, strUri.IndexOf("/"));
                return strUri;
            }
        }

        public static Enterprise IsLogin(string email, string pwd)
        {
            Enterprise enterprise = BLLEnterprise.GetEnterprise(email, pwd);
            if (enterprise == null) return null;
            EMSCookie.AddCookie("EnterpriseCookie", email);

            return enterprise;
        }

        public static bool IsLogin() 
        {
            return BLLEnterprise.Current != null;
        }

        public static void Logout()
        {
            EMSCookie.DeleteCookie("EnterpriseCookie");
            //HttpContext.Current.Session["AdminSession"] = null;
        }

        public static bool RegisterEnterprise(string enterpriseName, string enterpriseEmail, string password, string enterpriseAddress, string enterpriseTel)
        {
            DALEnterprise _DAL = new DALEnterprise();
            return _DAL.RegisterEnterprise(enterpriseName, enterpriseEmail, password, enterpriseAddress, enterpriseTel);
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

        public static Enterprise GetEnterprise(int enterpriseID)
        {
            DALEnterprise _DAL = new DALEnterprise();
            Enterprise enterprise = _DAL.GetEnterprise(enterpriseID);

            return enterprise;
        }

        public static Enterprise GetBgEnterprise(int id)
        {
            DALEnterprise _DAL = new DALEnterprise();
            Enterprise enterprise = _DAL.GetBgEnterprise(id);

            return enterprise;
        }

        public static bool SetEnterpriseBrief(int enterpriseID,string brief)
        {
            DALEnterprise _DAL = new DALEnterprise();
            return _DAL.SetEnterpriseBrief(enterpriseID, brief);
        }

        public static Enterprise ExistEnterprise(string enterpriseemail)
        {
            DALEnterprise _DAL = new DALEnterprise();
            Enterprise enterprise = _DAL.ExistEnterprise(enterpriseemail);

            return enterprise;
        }

        public static Enterprise GetEnterpriseByEmailOnly(string enterpriseemail)
        {
            DALEnterprise _DAL = new DALEnterprise();
            Enterprise enterprise = _DAL.GetEnterpriseByEmailOnly(enterpriseemail);

            return enterprise;
        }

        public static List<Enterprise> GetEnterpriseList(int page, int pageSize)
        {
            DALEnterprise _DAL = new DALEnterprise();
            List<Enterprise> enterpriseList = _DAL.GetEnterpriseList(page, pageSize);

            return enterpriseList;
        }

        public static bool SaveEnterpriseInfoChanges(int enterpriseID,string enterpriseName, string enterpriseUrl, string enterpriseAddress, string enterpriseTelphoneNumber, string enterpriseEmail, string enterpriseRight, string EnterpriseLogo)
        {
            DALEnterprise _DAL = new DALEnterprise();
            return _DAL.SaveEnterpriseInfoChanges(enterpriseID, enterpriseName, enterpriseUrl, enterpriseAddress, enterpriseTelphoneNumber, enterpriseEmail, enterpriseRight, EnterpriseLogo);
        }

        public static void DeleteEnterprise(int id)
        {
            DALEnterprise _DAL = new DALEnterprise();

            _DAL.DeleteEnterprise(id);
        }

        public static bool SetEnterpriseStatus(int id, bool status)
        {
            DALEnterprise _DAL = new DALEnterprise();

            return _DAL.SetEnterpriseStatus(id, status);
        }

        public static bool ChangePassword(int EnterpriseID, string password)
        {
            DALEnterprise _DAL = new DALEnterprise();

            return _DAL.ChangePassword(EnterpriseID, password);
        }
    }
}