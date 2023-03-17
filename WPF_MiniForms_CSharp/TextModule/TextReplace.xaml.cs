using System.Windows;
using System.Windows.Controls;

namespace WPF_MiniForms_CSharp.TextModule;

public partial class TextReplace : Window
{
    public TextReplace()
    {
        InitializeComponent();
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
    }
}
