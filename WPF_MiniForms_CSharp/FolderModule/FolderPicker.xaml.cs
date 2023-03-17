using System.Windows;
using WPF_MiniForms_CSharp.Models.Modules;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.FolderModule; 

public partial class FolderPicker : Window
{
    private Folder _folder;
    private readonly FolderService _service;
    public FolderPicker(FolderService service)
    {
        InitializeComponent();
        _service = service;
        DataContext = this;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var folder = _service.GetFolder();
        _folder = folder;
        txtLimitedInput.Text = _folder.DirectoryPath;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        _service.TaskResult = _folder;
        Close();
    }
}
