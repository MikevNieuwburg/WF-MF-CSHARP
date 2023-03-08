using System.Collections.Generic;
using System.Windows;
using WPF_MiniForms_CSharp.Models.Interfaces;

namespace WPF_MiniForms_CSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IEnumerable<IModule> _tasks = new List<IModule>();
        public MainWindow()
        {
            InitializeComponent();
            OnClick();
        }

        public void OnClick()
        {
            foreach (var task in _tasks)
            {
                var result = task.Execute();
            }
        }

        private void FolderPicked(object sender, Models.Records.Folder e)
        {

        }
    }
}
