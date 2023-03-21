using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using WPF_MiniForms_CSharp.Models.Interfaces;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Models.Functions;

public partial class MailService : IService
{
    private const string ERROR = "Error on the following item(s):";
    private const string SMPT_SERVICE = "smtp.gmail.com";
    private ComposeMail? _mail;

    public object? TaskInput { get; set; }
    public object? TaskResult { get; set; }

    public void Execute()
    {
        if (ValidateMailProperties())
            SendMail();
    }

    private bool ValidateMailProperties()
    {
        if (TaskInput is ComposeMail mail)
            _mail = mail;

        if (string.IsNullOrEmpty(_mail?.Receivers))
            throw new Exception(ERROR + " receiver wasn't filled in as a valid email.");
        
        if (ValidateRegex(_mail.Receivers) == false)
            throw new Exception(ERROR + " receiver wasn't filled in as a valid email.");
        if (ValidateRegex(_mail.CarbonCopy) == false)
            throw new Exception(ERROR + " cc isn't valid.");
        if (ValidateRegex(_mail.BlindCarbonCopy) == false)
            throw new Exception(ERROR + " bcc isn't valid.");

        return true;
    }

    private bool ValidateRegex(string list)
    {
        if (list.Length > 0)
            return true;
        var input = list.Contains(';') ? list.Split(';') : new[] { list };
        if (input.ToList() == new List<string>())
            ArgumentException.ThrowIfNullOrEmpty(nameof(list));
        return input.ToList().All(x => MailPattern().IsMatch(x));
    }

    private void SendMail()
    {
        if (_mail?.Receivers == null)
            return;

        var receivers = _mail.Receivers.Contains(';')
            ? _mail.Receivers.Split(';').ToList()
            : new List<string> { _mail.Receivers };
        var carbonCopy = _mail.CarbonCopy.Contains(';')
            ? _mail.CarbonCopy.Split(';').ToList()
            : new List<string> { _mail.CarbonCopy };
        var blindCarbonCopy = _mail.BlindCarbonCopy.Contains(';')
            ? _mail.BlindCarbonCopy.Split(';').ToList()
            : new List<string> { _mail.BlindCarbonCopy };

        MailMessage message = new()
        {
            Subject = _mail.Header,
            Body = _mail.Body,
            BodyEncoding = Encoding.UTF8
        };

        if (receivers.Any())
            foreach (var receiver in receivers)
            {
                message.To.Add(new MailAddress(receiver));
            }

        if (carbonCopy.Any() && carbonCopy[0] != string.Empty)
            foreach (var cc in carbonCopy)
            {
                message.CC.Add(new MailAddress(cc));
            }

        if (blindCarbonCopy.Any() && blindCarbonCopy[0] != string.Empty)
            foreach (var bcc in blindCarbonCopy)
            {
                message.Bcc.Add(new MailAddress(bcc));
            }

        message.From = new MailAddress(settings.Default.EMAIL);

        var smtp = new SmtpClient();
        smtp.Host = SMPT_SERVICE;
        smtp.Port = 587;
        smtp.EnableSsl = true;
        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new NetworkCredential(settings.Default.EMAIL, settings.Default.PASS);

        try
        {
            smtp.Send(message);
        }
        catch (SmtpException ex)
        {
            throw new SmtpException(ex.Message);
        }
    }

    [GeneratedRegex("^[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\\.[a-zA-Z0-9]+)*$")]
    private static partial Regex MailPattern();
}