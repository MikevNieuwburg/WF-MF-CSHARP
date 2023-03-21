using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using WPF_MiniForms_CSharp.Core;

namespace WPF_MiniForms_CSharp.Models.Functions;

public class FolderFunctions
{
    private TemporaryFolder _tempFolder;

    public FolderFunctions(TemporaryFolder tempFolder)
    {
        _tempFolder = tempFolder;
    }

    public string GetTemporaryFolder => _tempFolder.GetTemporaryDirectory();

    public IEnumerable<string>? Files()
    {
        var path = _tempFolder.GetTemporaryDirectory();
        return FolderFiles(path);
    }
    public IEnumerable<string>? Directories()
    {
        var path = _tempFolder.GetTemporaryDirectory();
        return FolderDirectories(path);
    }

    public Dictionary<string, IEnumerable<string>> GetFolder()
    {

        var path = _tempFolder.GetTemporaryDirectory();
        var directories = FolderDirectories(path);
        var dictionary = new Dictionary<string, IEnumerable<string>>();

        if (directories?.Count() > 0)
        {
            for (int i = 0; i < directories.Count(); i++)
            {
                var dir = directories.ToArray()[i];
                var contentFromDir = FolderFiles(dir + '\\');
                if (contentFromDir != null)
                    dictionary.Add(dir, contentFromDir);

            }
        }
        return dictionary;
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

    public string GetFile(string filter)
    {
        using OpenFileDialog ofd = new OpenFileDialog();
        ofd.Filter = filter;
        var result = ofd.ShowDialog();


        if (result == DialogResult.OK)
        {
            return ofd.FileName;
        }
        throw new FileNotFoundException("File not found.");
    }
}
