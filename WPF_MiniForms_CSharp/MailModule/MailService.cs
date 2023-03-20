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
    private readonly ComposeMail _mail;
    public object TaskInput { get; set; }
    public object? TaskResult { get; set; }

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
            Debug.WriteLine(ERROR);
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

        MailMessage message = new()
        {
            Subject = _mail.Header,
            Body = _mail.Body,
            BodyEncoding = Encoding.UTF8
        };

        if (_mail.Receivers.Any())
        {
            foreach (var receiver in _mail.Receivers)
            {
                message.To.Add(new MailAddress(receiver));
            }
        }
        if (_mail.CarbonCopy.Any())
        {
            foreach (var carbonCopy in _mail.CarbonCopy)
            {
                message.CC.Add(new MailAddress(carbonCopy));
            }
        }
        if (_mail.BlindCarbonCopy.Any())
        {
            foreach (var blindCarbonCopy in _mail.BlindCarbonCopy)
            {
                message.Bcc.Add(new MailAddress(blindCarbonCopy));
            }
        }

        using SmtpClient smtp = new();
        
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
        
    }
    public void Execute()
    {
        if (ValidateMailProperties())
            SendMail();
    }
}
