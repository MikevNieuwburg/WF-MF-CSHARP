using System.Linq;
using System.Windows;

namespace WPF_MiniForms_CSharp.TextModule;

public partial class ConvertComposer : Window
{
    public ConvertWindow? Window;

    public ConvertComposer(TextService service)
    {
        InitializeComponent();
        Service = service;
    }

    public TextService? Service { get; set; }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var comboFrom = fromCombo.SelectedItem?.ToString()!.Split(' ').Last();
        var comboTo = toCombo.SelectedItem?.ToString()!.Split(' ').Last();
        if (string.IsNullOrEmpty(comboTo))
        {
            MessageBox.Show("", "No item selected on convert to.");
            return;
        }

        Service!.TaskInput = new PDFConversion(comboFrom, comboTo);
        Window = new ConvertWindow(comboFrom, comboTo);
        DialogResult = true;
    }
}