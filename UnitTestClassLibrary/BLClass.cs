using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestClassLibrary
{
    public static class  BLClass
    {
        public static bool validateEmail(string email)
        {
            string Email = "sh0450230@gmail.com";
            if(email!=Email)
            {
                return false;

            }
            return true;
        }

        private static String AGELIX_FROM = "sk0450230@gmail.com";
        private static String AGELIX_BCC = "shaifykhan@gmail.com";
        private static String AGELIX_SMTP = "smtp.gmail.com";
        private static String AGELIX_PWD = "8448665526";
        private static int AGELIX_PORT = 587;
        public static bool SendEmail(string emailTo, String msgSubject, string msgBody)
        {
            bool status;
            MailAddress from = new MailAddress(AGELIX_FROM, "Agelix Consulting LLC");
            MailMessage mail = new MailMessage(from.ToString(), emailTo, msgSubject, msgBody); 
            mail.Bcc.Add(AGELIX_BCC);
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient(AGELIX_SMTP);
            client.Port = AGELIX_PORT;
            client.EnableSsl = true;
            client.UseDefaultCredentials = true; // Important: This line of code must be executed before setting the NetworkCredentials object, otherwise the setting will be reset (a bug in .NET)
            NetworkCredential cred = new System.Net.NetworkCredential(AGELIX_FROM, AGELIX_PWD);
            client.Credentials = cred;
            try
            {
                client.Send(mail);
            }
            catch(Exception ex)
            {
                return false;
            }
              return true;

        }

    }
}
