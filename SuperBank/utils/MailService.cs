using System;
using System.Net;
using System.Net.Mail;

namespace SuperBank.utils
{
    public class MailService
    {
        private const string EMAIL = "utsnetsuperbank@gmail.com";
        private const string PASSWORD = "hanoi123";

        public static void SendMail(string to, string subject, string content)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(EMAIL);
                message.To.Add(new MailAddress(to));
                message.Subject = subject;  
                message.Body = content;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(EMAIL, PASSWORD);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
            }
            catch (SmtpException e)
            {
                Console.WriteLine("Mail send error, try again later.\n{0}", e);
                Console.ReadKey();
            }
        }
    }
}
