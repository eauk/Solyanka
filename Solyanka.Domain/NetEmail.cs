using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using Solyanka.Domain.Resources;

namespace Solyanka.Domain
{
    public class NetEmail
    {
        public void Send(string emailTo, string name, string confirmString)
        {
            var emailFrom = ConfigurationManager.AppSettings["Mail"];
            var mailPassword = ConfigurationManager.AppSettings["MailPassword"];
            var smtpHost = ConfigurationManager.AppSettings["SmtpHost"];
            var smtpPort = ConfigurationManager.AppSettings["SmtpPort"];

            var confirmAddress = string.Format("http://localhost:2484/Account/Email/{0}", confirmString);

            var smtpClient = new SmtpClient(smtpHost, Int32.Parse(smtpPort));
            smtpClient.Credentials = new NetworkCredential(emailFrom, mailPassword);
            smtpClient.EnableSsl = true;

            var message = new MailMessage();
            message.From = new MailAddress(emailFrom);
            message.To.Add(new MailAddress(emailTo));
            message.Subject = EmailRes.Registration_Form_Subject;
            message.Body = string.Format(EmailRes.Registration_Form_Body, name, confirmAddress);
            message.IsBodyHtml = true;

            smtpClient.Send(message);
        }
    }
}