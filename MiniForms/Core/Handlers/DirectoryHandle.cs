using System;
using System.Windows.Forms;

namespace MiniForms.Core.Handlers
{
    public class DirectoryHandle
    {
        public static string Folder
        {
            get
            {
                using var dialog = new FolderBrowserDialog()
                {
                    Description = "Pick a folder",
                    UseDescriptionForTitle = true,
                    SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                    ShowNewFolderButton = true
                };
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dialog.Dispose();
                    return dialog.SelectedPath;
                }
                return string.Empty;
            }
        }
    }
}
