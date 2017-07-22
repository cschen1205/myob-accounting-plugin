using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using SwissArmyKnife.Util;

namespace SwissArmyKnife.Emails
{
    public sealed class Emailer
    {
        private static Emailer mInstance = null;
        private static object mLocker = new object();
        public static Emailer Instance
        {
            get
            {
                if (mInstance == null)
                {
                    lock (mLocker)
                    {
                        mInstance = new Emailer();
                    }
                }
                return mInstance;
            }
        }

        public static void Email(string host, string to,
                         string body,
                         string subject,
                         string fromAddress,
                         string fromDisplay,
                         string credentialUser,
                         string credentialPassword,
                         params MailAttachment[] attachments)
        {
            try
            {
                MailMessage mail = new MailMessage();
               
                /*
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", 1);
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "SmtpHostUserName");
                mail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "SmtpHostPassword");
                */

                mail.Body = body;
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(to));
                mail.From = new MailAddress(fromAddress, fromDisplay, Encoding.UTF8);
                mail.Subject = subject;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;
                foreach (MailAttachment ma in attachments)
                {
                    mail.Attachments.Add(ma.File);
                }
                SmtpClient smtp = new SmtpClient();
                if (credentialUser != null && credentialPassword != null)
                {
                    smtp.Credentials = new System.Net.NetworkCredential(credentialUser, credentialPassword);
                }
                if(host != null) smtp.Host = host;
                smtp.Send(mail);
            }
            catch (Exception )
            {
                
            }
        }
    }
}
