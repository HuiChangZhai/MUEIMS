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
        //private static readonly object userlock = new object();
        //public static MEnterpriseAdmin Current
        //{
        //    get
        //    {
        //        DALMEnterpriseAdmin _DAL = new DALMEnterpriseAdmin();
        //        if (HttpContext.Current.User == null)
        //            return null;
        //        if (!HttpContext.Current.User.Identity.IsAuthenticated)
        //            return null;
        //        MEnterpriseAdmin u = HttpContext.Current.Session["__Admin__"] as MEnterpriseAdmin;
        //        if (u == null)
        //        {
        //            lock (userlock)
        //            {
        //                if (u == null)
        //                {
        //                    u = _DAL.GetMEnterpriseAdmin(HttpContext.Current.User.Identity.Name);
        //                    HttpContext.Current.Session["__Admin__"] = u;
        //                }
        //            }

        //        }
        //        return u;
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["__Admin__"] = value;
        //    }
        //}

        ///// <summary>
        ///// 设置adminCookie
        ///// </summary>
        ///// <param name="adminName">管理员Name</param>
        ///// <param name="isPersistent">是否点击记住我</param>
        //public static void SetAuthCookies(string adminName, bool isPersistent)
        //{
        //    DALMEnterprise _DAL = new DALMEnterprise();
        //    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
        //                              adminName, DateTime.Now, DateTime.Now.AddDays(7), isPersistent, "publisher",
        //                              FormsAuthentication.FormsCookiePath);
        //    string encTicket = FormsAuthentication.Encrypt(ticket);
        //    HttpCookie c = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

        //    HttpCookie cUser = new HttpCookie("_MADMINUSER", HttpUtility.UrlEncode(adminName));

        //    if (!HttpContext.Current.Request.IsLocal)
        //    {
        //        c.Domain = FormsAuthentication.CookieDomain;
        //        cUser.Domain = FormsAuthentication.CookieDomain;
        //    }
        //    if (isPersistent)
        //    {
        //        c.Expires = DateTime.Now.AddDays(7);
        //        cUser.Expires = DateTime.Now.AddDays(7);
        //    }
        //    HttpContext.Current.Response.Cookies.Add(c);
        //    HttpContext.Current.Response.Cookies.Add(cUser);
        //    FormsIdentity id = new FormsIdentity(ticket);
        //    string[] roles = ticket.UserData.Split(',');
        //    GenericPrincipal principal = new GenericPrincipal(id, roles);
        //    HttpContext.Current.User = principal;
        //}

        ///// <summary>
        ///// 获取用户Cookie
        ///// </summary>
        ///// <returns></returns>
        //public static string GetAuthCookies()
        //{
        //    HttpCookie c = HttpContext.Current.Request.Cookies["_MADMINUSER"];

        //    if (c == null)
        //        return null;
        //    return c.Value;
        //}

        ///// <summary>
        ///// 清除用户Cookie
        ///// </summary>
        //public static void ClearAuthCookies()
        //{
        //    HttpCookie c = new HttpCookie(FormsAuthentication.FormsCookieName);
        //    HttpCookie cUser = new HttpCookie("_MADMINUSER");
        //    c.Expires = DateTime.Now.AddYears(-1);
        //    cUser.Expires = DateTime.Now.AddYears(-1);
        //    if (!HttpContext.Current.Request.IsLocal)
        //    {
        //        c.Domain = FormsAuthentication.CookieDomain;
        //        cUser.Domain = FormsAuthentication.CookieDomain;
        //    }
        //    HttpContext.Current.Response.Cookies.Clear();
        //    HttpContext.Current.Response.Cookies.Add(c);
        //    HttpContext.Current.Response.Cookies.Add(cUser);
        //    HttpContext.Current.User = null;
        //}

        public static MEnterpriseAdmin AdminLogin(string adminName, string password)
        {
            if (string.IsNullOrEmpty(adminName) && string.IsNullOrEmpty(password))
            {
                return null;
            }
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
            HttpContext.Current.Session["AdminSession"] = admin;

            return isLoginSuccess;
        }

        public static void Logout()
        {
            EMSCookie.DeleteCookie("AdminCookie");
            HttpContext.Current.Session["AdminSession"] = null;
        }

        public static MEnterpriseAdmin Current
        {
            get { return HttpContext.Current.Session["AdminSession"] as MEnterpriseAdmin; }
        }

    }
}