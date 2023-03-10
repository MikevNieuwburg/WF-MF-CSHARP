using System.Collections.Generic;
using System.Windows;
using WPF_MiniForms_CSharp.Core;
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
        }

        private void ExecuteTasks()
        {
            foreach (var task in _tasks)
            {
                var result = task.Execute();
            }
        }
        private void ExecuteModules(object sender, object passedModule)
        {
            ExecuteTasks();

        }
    }
}
