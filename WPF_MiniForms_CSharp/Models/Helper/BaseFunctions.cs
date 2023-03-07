using Microsoft.VisualBasic;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPF_MiniForms_CSharp.Models.Helper
{
    internal class BaseFunctions
    {
        public BaseFunctions()
        {
        }

        internal string GetFolder

        internal object? StartQueueProcess(Func<object>? value)
        {
            if (value == null)
                return null;
            return value.Invoke();
        }

    }
}
