using System.Windows;
using System.Windows.Controls;

namespace WPF_MiniForms_CSharp.TextModule;

public partial class TextReplace : Window
{
    private bool hasChanged = false;
    private TextService _service;

    public TextReplace(TextService service)
    {
        InitializeComponent();
        _service = service;
        changePanel.Visibility = Visibility.Hidden;
    }

    private void rightSideChanged(object sender, TextChangedEventArgs e)
    {
        changePanel.Visibility = Visibility.Visible;
        rightLabelChange.Content = e.Source;
    }

    private void leftSideChanged(object sender, TextChangedEventArgs e)
    {
        changePanel.Visibility = Visibility.Visible;
        leftLabelChange.Content = e.Source;
        hasChanged = true;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if(hasChanged)
        {
            _service.TaskResult = new TextSettings(leftLabelChange.Content.ToString(), rightLabelChange.Content.ToString());
            DialogResult = true;
            Close();
        }
    }
}
