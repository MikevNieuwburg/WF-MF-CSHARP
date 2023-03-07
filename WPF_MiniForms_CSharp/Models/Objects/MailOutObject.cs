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
        private Task _executableTask;

        public MailOutObject() { }


        public string? TaskName => nameof(MailOutObject);

        public Type? TaskType => typeof(MailOutObject);

        public Task? ExecuteTask { get => _executableTask; set => _executableTask = value; }
    }
}
