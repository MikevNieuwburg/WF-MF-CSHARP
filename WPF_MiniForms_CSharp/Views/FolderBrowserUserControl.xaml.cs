using System.Windows;
using System.Windows.Controls;
using WPF_MiniForms_CSharp.Models.Modules;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.Views
{
    public partial class FolderBrowserUserControl : UserControl
    {
        private FolderService module;
        private Folder folder;
        public string? Title { get; set; }
        public int? MaxLength { get; set; }

        internal event UserControlEvent ControlEvent;
        internal delegate void UserControlEvent(object sender, Folder e);

        public FolderBrowserUserControl()
        {
            InitializeComponent();
            module = new FolderService();
            this.DataContext = this;
        }

        private void FileDialogOpener(object sender, RoutedEventArgs e)
        {
            folder = module.GetFolder();
            txtLimitedInput.Text = folder.DirectoryPath;
        }

        protected virtual void EventRaiser()
        {
            ControlEvent?.Invoke(this, folder);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            EventRaiser();
        }
    }
}
