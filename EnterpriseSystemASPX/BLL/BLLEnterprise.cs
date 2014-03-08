using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using EnterpriseSystemASPX.DAL;
using EnterpriseSystemASPX.Models;

namespace EnterpriseSystemASPX.BLL
{
    [Serializable]
    public static class BLLEnterprise
    {
        private static readonly object userlock = new object();
        public static Enterprise Current
        {
            get
            {
                DALEnterprise _DAL = new DALEnterprise();
                if (HttpContext.Current.User == null)
                    return null;
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                    return null;
                Enterprise u = HttpContext.Current.Session["__User__"] as Enterprise;
                if (u == null)
                {
                    lock (userlock)
                    {
                        if (u == null)
                        {
                            u = _DAL.GetEnterprise(HttpContext.Current.User.Identity.Name);
                            HttpContext.Current.Session["__User__"] = u;
                        }
                    }

                }
                return u;
            }
            set
            {
                HttpContext.Current.Session["__User__"] = value;
            }
        }

        public static void SetAuthCookies(string enterprisename, bool isPersistent)
        {
            DALEnterprise _DAL = new DALEnterprise();
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                                      enterprisename, DateTime.Now, DateTime.Now.AddDays(7), isPersistent, "publisher",
                                      FormsAuthentication.FormsCookiePath);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie c = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

            HttpCookie cUser = new HttpCookie("_MUSER", HttpUtility.UrlEncode(enterprisename));

            if (!HttpContext.Current.Request.IsLocal)
            {
                c.Domain = FormsAuthentication.CookieDomain;
                cUser.Domain = FormsAuthentication.CookieDomain;
            }
            if (isPersistent)
            {
                c.Expires = DateTime.Now.AddDays(7);
                cUser.Expires = DateTime.Now.AddDays(7);
            }
            HttpContext.Current.Response.Cookies.Add(c);
            HttpContext.Current.Response.Cookies.Add(cUser);
            FormsIdentity id = new FormsIdentity(ticket);
            string[] roles = ticket.UserData.Split(',');
            GenericPrincipal principal = new GenericPrincipal(id, roles);
            HttpContext.Current.User = principal;
        }

        public static string GetAuthCookies()
        {
            HttpCookie c = HttpContext.Current.Request.Cookies["_MUSER"];

            if (c == null)
                return null;
            return c.Value;
        }

        public static void ClearAuthCookies()
        {
            HttpCookie c = new HttpCookie(FormsAuthentication.FormsCookieName);
            HttpCookie cUser = new HttpCookie("_MUSER");
            c.Expires = DateTime.Now.AddYears(-1);
            cUser.Expires = DateTime.Now.AddYears(-1);
            if (!HttpContext.Current.Request.IsLocal)
            {
                c.Domain = FormsAuthentication.CookieDomain;
                cUser.Domain = FormsAuthentication.CookieDomain;
            }
            HttpContext.Current.Response.Cookies.Clear();
            HttpContext.Current.Response.Cookies.Add(c);
            HttpContext.Current.Response.Cookies.Add(cUser);
            HttpContext.Current.User = null;
        }
    }
}