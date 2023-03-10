using iText.Kernel.Pdf.Canvas.Wmf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MiniForms_CSharp.Core
{
    public class Modules
    {
        public List<string> GetModuleNames()
        {
            var mods = new List<string>
            {
                "Folder In",
                "Folder Out",
                "Encrypt",
                "Decrypt",
                "Mail Out",
                "Text Replace",
                "Text To PDF",
                "Word Template",
            };
            return mods;
        }
    }
}
