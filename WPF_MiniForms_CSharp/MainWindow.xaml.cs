using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using WPF_MiniForms_CSharp.Core;
using WPF_MiniForms_CSharp.FolderModule;
using WPF_MiniForms_CSharp.Models.Modules;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHost _host;
        private string _selectedModule;
        private ModuleEnum.ModulesEnum _moduleEnum;
        private readonly Modules _modules;
        private readonly List<string> _moduleNames = new List<string>();
        private readonly List<object> _moduleObjects = new List<object>();

        public MainWindow(Modules modules)
        {
            InitializeComponent();
            _modules = modules;
            
            foreach (var module in Enum.GetValues(typeof(ModuleEnum.ModulesEnum))) 
            {
                _moduleNames.Add(string.Concat(module.ToString().Select(s => Char.IsUpper(s) ? " " + s : s.ToString())).TrimStart(' '));
            }

            listBoxModules.ItemsSource = _moduleNames;
            listBoxModules.SelectionChanged += ListBoxModules_SelectionChanged;
            _selectedModule = "";
        }

        private void ListBoxModules_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listBoxModules.SelectedItem == null)
                return;
            _selectedModule = listBoxModules.SelectedItem.ToString();
            labelSelectedItem.Content = $"Item Selected : {listBoxModules.SelectedItem}";
        }

        private void AddModuleClick(object sender, RoutedEventArgs e)
        {
            switch (_moduleEnum)
            {
                case ModuleEnum.ModulesEnum.FolderIn:
                    var folderinService = _modules.GetFolderPicker(_host.Services.GetRequiredService<FolderPicker>(), _host.Services.GetRequiredService<FolderService>());
                    _modules.StartTask(folderinService.Service.Execute());
                    if (folderinService.Service.TaskResult is Folder folderIn)
                    {
                        if (string.IsNullOrEmpty(folderIn.DirectoryPath))
                            return;
                        listBoxModuleOrder.Items.Add(_selectedModule);
                        _moduleObjects.Add(folderIn);
                    }
                    break;
                case ModuleEnum.ModulesEnum.FolderOut:
                    var folderoutService = _modules.GetFolderPicker(_host.Services.GetRequiredService<FolderPicker>(), _host.Services.GetRequiredService<FolderService>());
                    _modules.StartTask(folderoutService.Service.Execute());
                    if (folderoutService.Service.TaskResult is Folder folderOut)
                    {
                        if (string.IsNullOrEmpty(folderOut.DirectoryPath))
                            return;
                        listBoxModuleOrder.Items.Add(_selectedModule);
                        _moduleObjects.Add(folderOut);
                    }
                    break;
                case ModuleEnum.ModulesEnum.Encrypt:
                    
                    break;
                case ModuleEnum.ModulesEnum.Decrypt:
                    
                    break;
                case ModuleEnum.ModulesEnum.MailOut:
                    
                    break;
                case ModuleEnum.ModulesEnum.TextReplace:
                    
                    break;
                case ModuleEnum.ModulesEnum.TextToPdf:
                    
                    break;
                case ModuleEnum.ModulesEnum.WordTemplate:

                    break;
                default:
                    throw new ArgumentNullException("No module was selected. Please select one before you try to add it.");
            }
        }

        public void PassHost(IHost host)
        {
            _host = host;
        }

        private void RunModules(object sender, RoutedEventArgs e)
        {
        }
    }
}
