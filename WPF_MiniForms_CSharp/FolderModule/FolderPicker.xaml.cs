using System.Windows;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Modules;

namespace WPF_MiniForms_CSharp.FolderModule;

public partial class FolderPicker : Window
{
    private readonly FolderFunctions _functions;
    public FolderService Service;
    public string GivenPath { get; set; }

    public FolderPicker(FolderService service, FolderFunctions functions)
    {
        InitializeComponent();
        txtLimitedInput.Text = GivenPath;
        _functions = functions;
        Service = service;
        DataContext = this;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var path = _functions.FolderPath();
        txtLimitedInput.Text = path;
        GivenPath = path;
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}
