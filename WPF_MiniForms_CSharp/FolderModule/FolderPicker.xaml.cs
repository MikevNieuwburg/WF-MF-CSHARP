using System.Windows;
using WPF_MiniForms_CSharp.Models.Modules;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.FolderModule
{
    /// <summary>
    /// Interaction logic for FolderPicker.xaml
    /// </summary>
    public partial class FolderPicker : Window
    {
        private Folder _folder;
        public FolderService Service { get; set; }
        public FolderPicker()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var folder = Service.GetFolder();
            _folder = folder;
            txtLimitedInput.Text = _folder.DirectoryPath;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Service.TaskResult = _folder;
        }
    }
}
