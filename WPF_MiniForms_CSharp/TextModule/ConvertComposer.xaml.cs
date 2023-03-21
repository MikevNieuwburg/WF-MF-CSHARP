using System.Linq;
using System.Windows;

namespace WPF_MiniForms_CSharp.TextModule;

public partial class ConvertComposer : Window
{
    public TextService? Service { get; set; }
    public ConvertWindow? Window;
    public ConvertComposer(TextService service)
    {
        InitializeComponent();
        Service = service;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var comboFrom = fromCombo.SelectedItem?.ToString()!.Split(' ').Last();
        var comboTo = toCombo.SelectedItem?.ToString()!.Split(' ').Last();
        if (string.IsNullOrEmpty(comboTo))
        {
            MessageBox.Show("", "No item selected on convert to.");
            return;
        }
        Service!.TaskInput = new PDFConversion(ConvertFrom: comboFrom, ConvertTo: comboTo);
        Window = new ConvertWindow(From: comboFrom, To: comboTo);
        DialogResult = true;
    }
}
