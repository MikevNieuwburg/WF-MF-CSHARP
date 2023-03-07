using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp.Models.Objects
{
    internal class MailOutObject : ITask
    {
        // Inject email Service?
        public MailOutObject() { }


        public string? TaskName => nameof(MailOutObject);

        public Type? TaskType => typeof(MailOutObject);

        public Task<bool> Execute()
        {
            // Send Email

            return true;
        }
    }
}
