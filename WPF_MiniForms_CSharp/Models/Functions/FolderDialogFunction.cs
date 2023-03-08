using System;
using System.Windows.Forms;

namespace WPF_MiniForms_CSharp.Models.Functions
{
    internal class FolderDialogFunction
    {
        public FolderDialogFunction()
        {
        }

        public string Folder(string Title = "")
        {
            using var dialog = new FolderBrowserDialog()
            {
                Description = (Title == string.Empty) ? "Pick a folder" : Title,
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
