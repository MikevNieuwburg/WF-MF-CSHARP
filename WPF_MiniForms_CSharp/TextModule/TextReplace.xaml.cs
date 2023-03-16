using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_MiniForms_CSharp.TextModule
{
    /// <summary>
    /// Interaction logic for TextReplace.xaml
    /// </summary>
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
}
