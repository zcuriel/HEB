using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using HEB.NetGiphyA.Common;

namespace HEB.NetGiphyA.Util
{
    public static class Email
    {
        public static void sendEmail(string emailTo, string userName)
        {
            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(emailTo, userName));
                message.From = new MailAddress(Constants.DEFAULT_EMAIL_FROM, Constants.DEFAULT_EMAIL_FROM_NAME);
                message.Bcc.Add(new MailAddress(Constants.DEFAULT_EMAIL_FROM, Constants.DEFAULT_EMAIL_FROM_NAME));
                message.Subject = "User Registration";
                message.Body = "Test";
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential("email", "password");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }
    }
}
