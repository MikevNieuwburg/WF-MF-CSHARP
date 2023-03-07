using MiniForms.Interfaces;
using MiniForms.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MiniForms
{
    public partial class MainWindow : Window
    {
        private List<ITask> tasks = new List<ITask>();

        public MainWindow()
        {
            InitializeComponent();
            MiniForms.Models.Modules mods = new MiniForms.Models.Modules();
            lv.ItemsSource = mods.GetModules();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sind = lv.SelectedIndex; 
            var item = lv.Items.GetItemAt(sind < 0 ? 0 : sind) as Modules;
            if (item == null || sind < 0)
            {  
                MessageBox.Show("No item selected.");
                return;
            }
            var task = GetTask(item.Description ?? string.Empty);
            if (task == null)
                return;
            tasks.Add(task);
            steps.Children.Add(new Label() { Content = item.Name});
        }

        public ITask? GetTask(string description) => description switch
        {
            "fi" => new FolderIn() { },
            "fo" => new FolderOut() { },
            "co" => new Converter() { },
            "de" => new Decoder() { },
            "mo" => new MailOut() { },
            "tr" => new TextReplace() { },
            "wt" => new WordTemplate() { },
            "tp" => new TextToPdf() { },
            _ => null
        };

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            foreach (var task in tasks)
            {
                if(task is MailOut m)
                {
                    
                    task.Execute();
                }

            }
        }
    }
}
