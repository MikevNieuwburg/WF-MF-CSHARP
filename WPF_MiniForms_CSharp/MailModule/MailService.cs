using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Functions
{
    public class MailService
    {
        private readonly ComposeMail _mail;

        public MailService(ComposeMail mail) 
        {
            _mail = mail;
        }


        private bool ValidateMailProperties()
        {
            if (ValidateRegex(_mail.Receivers.ToList(), "Receiver") == false ||
                ValidateRegex(_mail.CarbonCopy.ToList(), "Carbon Copy") == false || 
                ValidateRegex(_mail.BlindCarbonCopy.ToList(), "Blind Carbon Copy") == false)
            {
                string error = "Error on the following item(s):";
                Debug.WriteLine(error);
                return false;
            }
            return true;
        }

        private bool ValidateRegex(List<string>? list, string? property = null)
        {
            string mailPattern = "^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$";
            if (list == new List<string>())
                ArgumentException.ThrowIfNullOrEmpty(nameof(list));
            if (list.Any(x => !Regex.IsMatch(x, mailPattern)))
                return false;
            return true;
        }

        private void SendMail()
        {
            if (_mail.Receivers == null)
                return;

            MailMessage message = new MailMessage()
            {
                Subject = _mail.Header,
                Body = _mail.Body,
                BodyEncoding = Encoding.UTF8
            };

            if (_mail.Receivers.Count() > 0)
            {
                MailAddressCollection recipients = new MailAddressCollection();
                foreach (var receiver in _mail.Receivers)
                {
                    message.To.Add(new MailAddress(receiver));
                }
            }
            if (_mail.CarbonCopy.Count() > 0)
            {
                MailAddressCollection recipients = new MailAddressCollection();
                foreach (var receiver in _mail.Receivers)
                {
                    message.CC.Add(new MailAddress(receiver));
                }
            }
            if (_mail.BlindCarbonCopy.Count() > 0)
            {
                MailAddressCollection recipients = new MailAddressCollection();
                foreach (var receiver in _mail.Receivers)
                {
                    message.Bcc.Add(new MailAddress(receiver));
                }
            }

            using SmtpClient smtp = new SmtpClient();
            
            smtp.UseDefaultCredentials = true;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential("random.guids@gmail.com", "roysoxyhodtbycwu");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;
            smtp.Timeout = 20000;

            try
            {
                smtp.Send(message);
            }
            catch (SmtpException ex)
            {
                Debug.WriteLine(ex.ToString()); 
            }
            finally 
            { 
                smtp.Dispose(); 
            }
            
        }
        public void Execute()
        {
            if (ValidateMailProperties())
                SendMail();
        }
    }
}
