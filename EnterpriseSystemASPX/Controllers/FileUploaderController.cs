using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EnterpriseSystemASPX.Controllers
{
    public class FileUploaderController : Controller
    {
        [HttpPost]
        public string Index(HttpPostedFileBase file, HttpPostedFileBase enterpriseLogo, HttpPostedFileBase templateFile)
        {
            string now = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + (new Random().Next(1000,10000));
            if (file != null && file.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = now + Path.GetFileName(file.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/uploadImages"), fileName);
                file.SaveAs(path);
                return fileName;
            }
            else if (enterpriseLogo != null && enterpriseLogo.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = now + Path.GetFileName(enterpriseLogo.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/uploadImages"), fileName);
                enterpriseLogo.SaveAs(path);
                return fileName;
            }
            else if (templateFile != null && templateFile.ContentLength > 0)
            {
                // extract only the fielname
                var fileName = Path.GetFileName(templateFile.FileName);
                // store the file inside ~/App_Data/uploads folder
                var path = Path.Combine(Server.MapPath("~/Content/CSS"), fileName);
                templateFile.SaveAs(path);
                return fileName;
            }

            return "";
        }
    }
}
