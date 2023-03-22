using System.Security;
using System.Windows.Forms;

namespace WPF_MiniForms_CSharp.FolderModule;

public class FolderFunctions
{
    private const string FOLDER_TITLE = "Pick a folder";
    private readonly TemporaryFolder _tempFolder;

    public FolderFunctions(TemporaryFolder tempFolder)
    {
        _tempFolder = tempFolder;
    }

    public string GetTemporaryFolder => _tempFolder.GetTemporaryDirectory();

    public string? FolderPath(string title = "")
    {
        using var dialog = new FolderBrowserDialog
        {
            Description = (title?.Length == 0 ? FOLDER_TITLE : title) ?? string.Empty,
            UseDescriptionForTitle = true,
            SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            ShowNewFolderButton = true
        };
        if (dialog.ShowDialog() != DialogResult.OK)
            return string.Empty;
        dialog.Dispose();
        return dialog.SelectedPath + @"\";
    }

    public IEnumerable<string> FolderFiles(string path)
    {
        if (string.IsNullOrEmpty(path))
            return Array.Empty<string>();

        try
        {
            return Directory.EnumerateFiles(Path.GetDirectoryName(path) ?? string.Empty);
        }
        catch (Exception ex)
        {
            throw ex switch
            {
                ArgumentException argException => argException,
                DirectoryNotFoundException directoryNotFoundException => directoryNotFoundException,
                IOException exception => exception,
                SecurityException securityException => securityException,
                UnauthorizedAccessException unauthorizedAccessException => unauthorizedAccessException,
                _ => ex
            };
        }
    }

    public string GetFile(string filter)
    {
        using var ofd = new OpenFileDialog();
        ofd.Filter = filter;
        var result = ofd.ShowDialog();
        return result == DialogResult.OK ? ofd.FileName : string.Empty;
    }
}