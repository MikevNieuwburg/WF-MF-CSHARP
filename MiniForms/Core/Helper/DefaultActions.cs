using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniForms.Core.Helper
{
    internal class DefaultActions
    {
        public Func<Object?> GetFolder = () => 
        { 
            using (FolderBrowserDialog  dialog = new FolderBrowserDialog())
            { 
                dialog.ShowDialog();
                if(dialog.ShowDialog() == DialogResult.OK)
                    return dialog.SelectedPath;
            };

            return null;
        };
    }
}
