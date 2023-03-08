using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using WPF_MiniForms_CSharp.Models.Modules;

namespace WPF_MiniForms_CSharp.Views
{
    public partial class FolderBrowserUserControl : UserControl
    {
        private FolderModule module;
        public string? Title { get; set; }
        public int? MaxLength { get; set; }

        public event Handler handler;
        public delegate void Handler(object sender, string e);

        public FolderBrowserUserControl()
        {
            InitializeComponent();
            module = new FolderModule();
            this.DataContext = this;
        }

        private void FileDialogOpener(object sender, RoutedEventArgs e)
        {
            txtLimitedInput.Text = module.GetFolder(); 
        }

        protected virtual void EventRaiser()
        { 
            handler?.Invoke(this, txtLimitedInput.Text);
        }
    }
}
