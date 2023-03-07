using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPF_MiniForms_CSharp.Models.Helper
{
    internal class DefaultActions
    {
        internal string? GetFolder()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                Description = "Select Folder",
                UseDescriptionForTitle = true,
                ShowNewFolderButton = true
            })
            { 
                if(dialog.ShowDialog() == DialogResult.OK)
                    return  dialog.SelectedPath;
            };

            return string.Empty;
        }
    }
}
