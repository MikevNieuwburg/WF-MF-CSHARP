using System.Windows;
using WPF_MiniForms_CSharp.Models.Functions;

namespace WPF_MiniForms_CSharp.TextModule;

/// <summary>
///     Interaction logic for WordTemplate.xaml
/// </summary>
public partial class WordTemplate : Window
{
    private readonly FolderFunctions _folder;

    public WordTemplate(WordTemplateService templateService, FolderFunctions folder)
    {
        InitializeComponent();
        _folder = folder;
        Service = templateService;
        if (string.IsNullOrEmpty(TemplateFile) == false)
            templateTb.Text = TemplateFile;
    }

    public WordTemplateService Service { get; }

    public string TemplateFile { get; set; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        templateTb.Text = _folder.GetFile("Word Template (*.dotx)|*.dotx|Word Template <2007(*.dot)|*.dot");
        Service.Template = templateTb.Text;
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(templateTb.Text) == false)
            Service.OutputName = templateTb.Text;
        DialogResult = true;
    }
}