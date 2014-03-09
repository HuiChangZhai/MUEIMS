using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace EnterpriseSystemASPX.Common
{
    public static class EmailHelper
    {
        public static bool SendMail(string mailAddress, string subject, string body)
        {
            try
            {
                MailMessage mailMessage = new MailMessage();
                mailMessage.To.Add(new MailAddress(mailAddress));
                mailMessage.From = new MailAddress("934042737@qq.com", "多企业用户管理系统");
                mailMessage.ReplyToList.Add(new MailAddress("934042737@qq.com"));
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                SmtpClient mailSmtpClient = new SmtpClient();
                
                mailSmtpClient.Host = "smtp.qq.com";
                mailSmtpClient.Credentials = new System.Net.NetworkCredential("934042737@qq.com", "lycp19900726");
                
                mailSmtpClient.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}