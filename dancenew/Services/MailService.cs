using System;
using System.Net;
using System.Net.Mail;
using System.Web.Configuration;

namespace dancenew.Services
{
    public class MailService : IMailService
    {
        public bool SendMail(string from, string to, string subject, string body)
        {
            try
            {
                var msg = new MailMessage(from, to, subject, body);
                Send(msg);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        private void Send(MailMessage message)
        {
            string user = (WebConfigurationManager.AppSettings["mailuser"]);
            string password = (WebConfigurationManager.AppSettings["mailpwd"]);
            var loginInfo = new NetworkCredential(user, password);
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = loginInfo
            };
            smtp.Send(message);
        }
    }
}