using EnterpriseSystemASPX.Common;
using EnterpriseSystemASPX.DAL;
using EnterpriseSystemASPX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;

namespace EnterpriseSystemASPX.BLL
{
    [Serializable]
    public static class BLLMEnterpriseAdmin
    {
        public static MEnterpriseAdmin AdminLogin(string adminName, string password)
        {
            if (string.IsNullOrEmpty(adminName) && string.IsNullOrEmpty(password))
                return null;
            else
            {
                DALMEnterpriseAdmin adminDal = new DALMEnterpriseAdmin();
                MEnterpriseAdmin admin = adminDal.GetMEnterpriseAdmin(adminName, password);

                return admin;
            }
        }

        public static bool IsLogin()
        {
            return EMSCookie.ReadCookie("AdminCookie") != "";
        }

        public static bool Login(string adminName, string password)
        {
            MEnterpriseAdmin admin = BLLMEnterpriseAdmin.AdminLogin(adminName, password);

            EMSCookie.AddCookie("AdminCookie", adminName);

            bool isLoginSuccess = admin != null;

            return isLoginSuccess;
        }

        public static void Logout()
        {
            EMSCookie.DeleteCookie("AdminCookie");
        }

        public static MEnterpriseAdmin Current
        {
            get {
                DALMEnterpriseAdmin _DAL = new DALMEnterpriseAdmin();
                string username = EMSCookie.ReadCookie("AdminCookie");
                if (string.IsNullOrWhiteSpace(username)) return null;
                MEnterpriseAdmin _admin = _DAL.GetMEnterpriseAdmin(username);
                if (_admin == null) return null;
                return _admin;
            }
        }

        public static bool ChangeAdminPwd(string admin, string newpwd)
        {
            DALMEnterpriseAdmin _DAL = new DALMEnterpriseAdmin();

            return _DAL.ChangeAdminPwd(admin, newpwd);           
        }
    }
}