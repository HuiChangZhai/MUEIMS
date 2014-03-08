using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseSystemASPX.Common
{
    public class EMSCookie
    {
        public static void AddCookie(string name, string value)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                EMSCookie.RemoveCookie(name);
            }

            HttpCookie cookie = new HttpCookie(name, value);

            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Request.Cookies.Add(cookie);
        }

        public static void RemoveCookie(string name)
        {
            HttpContext.Current.Response.Cookies.Remove(name);
            HttpContext.Current.Request.Cookies.Remove(name);
        }

        public static void DeleteCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                RemoveCookie(name);
            }

            HttpCookie cookie = new HttpCookie(name);
            cookie.Expires = DateTime.Now;

            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Request.Cookies.Add(cookie);
        }

        public static string ReadCookie(string name)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[name];

            if (cookie == null)
            {
                return "";
            }
            else
            { 
                return cookie.Value;
            }


        }
    }
}