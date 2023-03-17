using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace WPF_MiniForms_CSharp.Models.Functions;

public class FolderDialogFunction
{
    public FolderDialogFunction()
    {
    }

    public string FolderPath(string title = "")
    {
        using var dialog = new FolderBrowserDialog()
        {
            Description = (title == string.Empty) ? "Pick a folder" : title,
            UseDescriptionForTitle = true,
            SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            ShowNewFolderButton = true
        };
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            dialog.Dispose();
            return dialog.SelectedPath + @"\";
        }
        return string.Empty;
    }

    public IEnumerable<string>? FolderDirectories(string path)
    {
        if (string.IsNullOrEmpty(path))
            return null;

        try
        {
            return Directory.EnumerateDirectories(Path.GetDirectoryName(path));
        }
        catch
        {
            throw new Exception("Either the argument passed failed to parse or the path is too long.");
        }
    }

    public IEnumerable<string>? FolderFiles(string path)
    {
        if (string.IsNullOrEmpty(path))
            return null;

        
        try
        {
            return Directory.EnumerateFiles(Path.GetDirectoryName(path));
        }
        catch 
        {
            throw new Exception("Either the argument passed failed to parse or the path is too long.");
        }
    }
}
