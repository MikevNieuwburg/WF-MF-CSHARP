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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_MiniForms_CSharp.Models.Helper;

namespace WPF_MiniForms_CSharp.Views
{
    public partial class FolderBrowserUserControl : UserControl
    {
        public string? Title { get; set; }
        public int? MaxLength { get; set; }

        public FolderBrowserUserControl()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void FileDialogOpener(object sender, RoutedEventArgs e)
        {
            BaseFunctions taskFactoryHelper = new BaseFunctions();
            DefaultActions defaultActions = new DefaultActions();
            txtLimitedInput.Text = (string?)taskFactoryHelper.StartQueueProcess(defaultActions.GetFolder) ?? "";
        }
    }
}
