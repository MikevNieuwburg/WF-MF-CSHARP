using System.Windows;
using WPF_MiniForms_CSharp.Models.Functions;

namespace WPF_MiniForms_CSharp.TextModule;

/// <summary>
/// Interaction logic for WordTemplate.xaml
/// </summary>
public partial class WordTemplate : Window
{

    private FolderFunctions _folder;

    public WordTemplateService Service { get; private set; }

    public string TemplateFile { get; set; }

    public WordTemplate(WordTemplateService templateService, FolderFunctions folder)
    {
        InitializeComponent();
        _folder = folder;
        Service = templateService;
        if (string.IsNullOrEmpty(TemplateFile) == false)
            templateTb.Text = TemplateFile;
    }

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
