using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using MiniForms.Interfaces;
using System.Diagnostics;
using MiniForms.Core.Constants;

namespace MiniForms.Models
{
    public class MailOut : ITask
    {
        private MailAddress mailSender = new MailAddress(""); 
        private List<string> propertyError = new List<string>();

        public Type TaskType => typeof(MailOut);

        public string Name => nameof(MailOut);

        public string Description => LanguageFile.DESC_MAILOUT;

        public object TaskData => throw new NotImplementedException();

        public MailOut()
        {
        }

        private bool ValidateMailProperties(MailProperties mailProperties)
        {
            if (ValidateRegex(mailProperties.Receiver, "Receiver") == false || ValidateRegex(mailProperties.CC, "Carbon Copy") == false || ValidateRegex(mailProperties.BCC, "Blind Carbon Copy") == false)
            {
                string error = "Error on the following item(s):";
                for (int i = 0; i < propertyError.Count; i++)
                {
                    error += $"\n{propertyError[i]}";
                }
                Debug.WriteLine(error);
                return false;
            } 
            return true;
        }

        private bool ValidateRegex(List<string>? list, string? property = null)
        {
            string mailPattern = "^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$";
            if (list == new List<string>())
                return true;
            if (list.Any(x => !Regex.IsMatch(x, mailPattern)))
                return false;
            return true;
        }

        private void SendMail(MailProperties mailProperties)
        {
            SingleMail(mailProperties.Header, mailProperties.Body,mailProperties.Receiver, mailProperties.CC, mailProperties.BCC);
        }

        private void SingleMail(string Title, string Content, List<string>? Receiver = null, List<string>? CopyReceivers = null, List<string>? BlindReceivers = null)
        {
            if (Receiver == null)
                return;

            List<MailMessage> messages = new List<MailMessage>();

            for (int i = 0; i < Receiver?.Count; i++)
            {
                messages.Add(new MailMessage(new MailAddress(project_resources.ResourceManager.GetString("MAIL_ADRESS") ?? ""), new MailAddress(Receiver[i]))
                {
                    Subject = Title,
                    Body = Content
                });

                if (messages.Last().From == new MailAddress(""))
                    messages.RemoveAt(messages.Count - 1);

            }

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.UseDefaultCredentials = true;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.Credentials = new NetworkCredential("smtp_username", "smtp_password");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Timeout = 20000;

                try
                {
                    for (int i = 0; i < messages.Count; i++)
                    {
                        smtp.Send(messages[i]);
                    }
                }
                catch (SmtpException ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                finally { smtp.Dispose(); }
            }
        }


        public virtual void Execute(string param)
        {
            var mailProperties = new MailProperties();
            if (ValidateMailProperties(mailProperties))
                SendMail(mailProperties);
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
