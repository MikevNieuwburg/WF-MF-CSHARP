using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using WPF_MiniForms_CSharp.Models.Interfaces;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Functions;

public class MailService : IService
{
    private const string ERROR = "Error on the following item(s):";
    private ComposeMail _mail;

    public object TaskInput { get; set; }
    public object? TaskResult { get; set; }

    private bool ValidateMailProperties()
    {
        if (TaskInput is ComposeMail mail)
            _mail = mail;

        if (string.IsNullOrEmpty(_mail.Receivers))
            throw new Exception(ERROR + " receiver wasn't filled in as a valid email.");


        if (ValidateRegex(_mail.Receivers, "Receiver") == false)
            throw new Exception(ERROR + " receiver wasn't filled in as a valid email.");
        if (ValidateRegex(_mail.CarbonCopy, "Carbon Copy") == false)
            throw new Exception(ERROR + " cc isn't valid.");
        if (ValidateRegex(_mail.BlindCarbonCopy, "Blind Carbon Copy") == false)
            throw new Exception(ERROR + " bcc isn't valid.");

        return true;
    }

    private bool ValidateRegex(string list, string? property = null)
    {
        if (list == "")
            return true;
        var input = (list.Contains(';')) ? list.Split(';') : new string[] { list };
        string mailPattern = "^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$";
        if (input.ToList() == new List<string>())
            ArgumentException.ThrowIfNullOrEmpty(nameof(list));
        if (input.ToList().Any(x => !Regex.IsMatch(x, mailPattern)))
            return false;
        return true;
    }

    private void SendMail()
    {
        if (_mail.Receivers == null)
            return;

        var receivers = _mail.Receivers.Contains(';') ? _mail.Receivers.Split(';').ToList() : new List<string> { _mail.Receivers };
        var carbonCopy = _mail.CarbonCopy.Contains(';') ? _mail.CarbonCopy.Split(';').ToList() : new List<string> { _mail.CarbonCopy };
        var blindCarbonCopy = _mail.BlindCarbonCopy.Contains(';') ? _mail.BlindCarbonCopy.Split(';').ToList() : new List<string> { _mail.BlindCarbonCopy };

        MailMessage message = new()
        {
            Subject = _mail.Header,
            Body = _mail.Body,
            BodyEncoding = Encoding.UTF8
        };

        if (receivers.Any())
        {
            foreach (var receiver in receivers)
            {
                message.To.Add(new MailAddress(receiver));
            }
        }
        if (carbonCopy.Any() && carbonCopy.First() != string.Empty)
        {
            foreach (var cc in carbonCopy)
            {
                message.CC.Add(new MailAddress(cc));
            }
        }
        if (blindCarbonCopy.Any() && blindCarbonCopy.First() != string.Empty)
        {
            foreach (var bcc in blindCarbonCopy)
            {
                message.Bcc.Add(new MailAddress(bcc));
            }
        }
        message.From = new MailAddress("random.guids@gmail.com");

        using SmtpClient smtp = new SmtpClient();

        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential("random.guids@gmail.com", "roysoxyhodtbycwu");



        try
        {
            smtp.Send(message);
        }
        catch (SmtpException ex)
        {
            Debug.WriteLine(ex.ToString());
        }

    }
    public void Execute()
    {
        if (ValidateMailProperties())
            SendMail();
    }
}
