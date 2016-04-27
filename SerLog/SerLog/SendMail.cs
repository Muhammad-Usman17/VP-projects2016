using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SerLog
{
    class SendMail
    {
        private static SendMail obj;
        private SendMail()
        {

        }
        public static SendMail mail
        {
            get
            {
                if (obj == null)
                {
                    obj = new SendMail();
                }
                return obj;

            }
        }

        public void sendNotification(String appAdd, String adminAdd)
        {

            SmtpClient client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(appAdd, "bse123456");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(appAdd);
            mail.To.Add(adminAdd);
            mail.Subject = "Email testing";
            mail.Body = "serlog verification test";
            try
            {
                client.Send(mail);
                MessageBox.Show("Email sent ");
            }
            catch (SmtpException e)
            {

                MessageBox.Show(e.InnerException.Message);
            }
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }

        }
    }
}
