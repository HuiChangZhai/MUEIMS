using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnterpriseSystemASPX.Common
{
    /// <summary>
    /// Cookie 操作类
    /// </summary>
    public class EMSCookie
    {
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="value">balue</param>
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

        /// <summary>
        /// 移除Cookie
        /// </summary>
        /// <param name="name">name</param>
        public static void RemoveCookie(string name)
        {
            HttpContext.Current.Response.Cookies.Remove(name);
            HttpContext.Current.Request.Cookies.Remove(name);
        }

        /// <summary>
        /// 删除Cookie
        /// </summary>
        /// <param name="name">name</param>
        public static void DeleteCookie(string name)
        {
            if (HttpContext.Current.Request.Cookies[name] != null)
            {
                RemoveCookie(name);
            }

            HttpCookie cookie = new HttpCookie(name);
            cookie.Expires = DateTime.Now.AddYears(-1);

            HttpContext.Current.Response.Cookies.Add(cookie);
            HttpContext.Current.Request.Cookies.Add(cookie);
        }

        /// <summary>
        /// 读取Cookie
        /// </summary>
        /// <param name="name">name</param>
        /// <returns>value</returns>
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