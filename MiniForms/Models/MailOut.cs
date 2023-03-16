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

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
