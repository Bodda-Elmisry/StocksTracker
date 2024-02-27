using StocksTracker.Repository.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Net.Mail;
//using System.Net;
using System.Reflection;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit;
using MailKit.Security;

namespace StocksTracker.Infrastructure.Services
{
    public class EmailService : IEmialService
    {
        private string senderEmail;
        private string senderPassword;
        //private SmtpClient client;
        private MimeMessage email;

        public EmailService()
        {
            //--Google
            //client = new SmtpClient("smtp.gmail.com");
            //client.Port = 587;
            //client.EnableSsl = true;
            //client.UseDefaultCredentials = false;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;

            email = new MimeMessage();

            //--Yahoo
            //client = new SmtpClient("smtp.mail.yahoo.com");
            //client.Port = 465;
            //client.EnableSsl = true;
            //client.UseDefaultCredentials = false;
            //client.DeliveryMethod = SmtpDeliveryMethod.Network;
        }

        public string CreateBodyFromListToHTMl<T>(IEnumerable<T> list)
        {
            bool setHeader = true;
            string body = "<html><body>";
            
            foreach (T item in list)
            {
                if (setHeader)
                {

                    body += "<h2>";
                    body += "The new status for ";
                    body += item.GetType().Name;
                    body += "</h2>";
                    body += "<br>";
                    body += "<p>";
                    body += "Items count =";
                    body += list.Count();
                    body += "</p>";
                    setHeader = false;
                }

                foreach (PropertyInfo propertyInfo in item.GetType().GetProperties())
                {
                    if (propertyInfo.Name.ToLower() != "id")
                    {
                        body += "<p><strong>";
                        body += propertyInfo.Name;
                        body += ": ";
                        body += "</strong>";
                        body += propertyInfo.GetValue(item);
                        body += "</p>";
                    }

                }
            }

            body += "</body></html>";

            return body;
        }

        public string SendMail(string RecipientEmail, string Body, bool IsBodyHtml)
        {
            try
            {
                //using (MailMessage message = new MailMessage(senderEmail, RecipientEmail)
                //{
                //    IsBodyHtml = IsBodyHtml,
                //    Body = Body
                //})
                //{

                //    client.Send(message);
                //}

                email.From.Add(new MailboxAddress("", senderEmail));
                email.To.Add(new MailboxAddress("", RecipientEmail));

                email.Subject = "Stocks traker";

                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = Body
                };

                using (var smtp = new SmtpClient())
                {
                    smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                    // Note: only needed if the SMTP server requires authentication
                    smtp.Authenticate(senderEmail, senderPassword);

                    smtp.Send(email);
                    smtp.Disconnect(true);
                }

                return "sent";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public void SetSenderInfo(string SenderEmail, string SenderPassword)
        {
            //client.Credentials = new NetworkCredential(SenderEmail, SenderPassword);
            this.senderEmail = SenderEmail;
            this.senderPassword = SenderPassword;
        }
    }
}
