using HEB.NetGiphyA.Common;
using System.Net;
using System.Net.Mail;

namespace HEB.NetGiphyA.Util
{
    public static class Email
    {

        /// <summary>
        /// Method that sends an email notification using Gmail server
        /// </summary>
        /// <param name="emailTo"></param>
        /// <param name="userName"></param>
        public static void sendEmail(string emailTo, string userName)
        {
            string bodyMsg = "<strong> New NetGiphyA User </strong> <br/>" + 
                    "<p>Thanks for registring with us. We will send you the Invite to NetGiphyA Azure directory in a few minutes. </p>" + 
                    "<p>Please complete your registration and you will be able to navigate in our whole application. </p>" + 
                    "<p>Sincerily,</p>NetGiphyA Admin team <br/>";

            using (var message = new MailMessage())
            {
                message.To.Add(new MailAddress(emailTo, userName));
                message.From = new MailAddress(Constants.DEFAULT_EMAIL_FROM, Constants.DEFAULT_EMAIL_FROM_NAME);
                message.Bcc.Add(new MailAddress(Constants.DEFAULT_EMAIL_FROM, Constants.DEFAULT_EMAIL_FROM_NAME));
                message.Subject = "User Registration Successfully - (" + emailTo + ")";
                message.IsBodyHtml = true;
                message.Body = bodyMsg;

                using (var client = new SmtpClient("smtp.gmail.com"))
                {
                    client.Port = 587;
                    client.Credentials = new NetworkCredential(Constants.EMAIL_CREDENTIAL, Constants.DEFAULT_PWD);
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }
    }
}
