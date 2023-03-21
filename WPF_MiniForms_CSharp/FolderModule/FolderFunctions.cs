using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using WPF_MiniForms_CSharp.Core;

namespace WPF_MiniForms_CSharp.Models.Functions;

public class FolderFunctions
{
    private const string FOLDER_TITLE = "Pick a folder";
    private readonly TemporaryFolder _tempFolder;

    public FolderFunctions(TemporaryFolder tempFolder)
    {
        _tempFolder = tempFolder;
    }

    public string GetTemporaryFolder => _tempFolder.GetTemporaryDirectory();

    public string FolderPath(string title = "")
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = title == string.Empty ? FOLDER_TITLE : title,
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

    public IEnumerable<string> FolderFiles(string path)
    {
        if (string.IsNullOrEmpty(path))
            return Array.Empty<string>();

        try
        {
            return Directory.EnumerateFiles(Path.GetDirectoryName(path));
        }
        catch (Exception ex)
        {
            throw new Exception("Either the argument passed failed to parse or the path is too long.",
                ex.InnerException);
        }
    }

    public string GetFile(string filter)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = filter;
        var result = ofd.ShowDialog();


        if (result == DialogResult.OK) return ofd.FileName;
        throw new FileNotFoundException("File not found.");
    }
}