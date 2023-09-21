using System;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace HospitalFinalProject.Helpers
{
    public static class Helper
    {
        //-----------------------------------------------//
        #region SendMail
        public static async Task SendMail(string resetEmailLink, string mailTo)
        {

            SmtpClient client = new SmtpClient();
            client.Host = "smtp.yandex.com";
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("ahmad.o@itbrains.edu.az", "uykiiihdctjpqbly");
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage("ahmad.o@itbrains.edu.az", mailTo);
            message.Subject = "sifre sifirlama";
            message.Body = @$"<h4>sifre yebileme link</h4> 
                                <p><a href='{resetEmailLink}'>sifre yenile</a></p>";
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            await client.SendMailAsync(message);
        }
        #endregion
        //-----------------------------------------------//

        /////Enums
        //-----------------------------------------------//
        #region Roles
        public enum Roles
        {
            Admin,
            Doctor,
            Moderator
        }
        #endregion
        #region Gender
        public enum Gender
        {
            Kişi,
            Qadın,
        }
        #endregion
        //-----------------------------------------------//


    }
}
