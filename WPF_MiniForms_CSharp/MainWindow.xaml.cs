using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Media3D;
using WPF_MiniForms_CSharp.Core;
using WPF_MiniForms_CSharp.EncryptionModule;
using WPF_MiniForms_CSharp.FolderModule;
using WPF_MiniForms_CSharp.MailModule;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Interfaces;
using WPF_MiniForms_CSharp.TextModule;

namespace WPF_MiniForms_CSharp
{
    public partial class MainWindow : Window
    {
        private IHost _host;
        private string _selectedModule;
        private ModuleEnum.ModulesEnum _moduleEnum;
        private readonly Modules _modules;
        private readonly List<string> _moduleNames = new List<string>();
        private readonly List<IService> _moduleObjects = new List<IService>();

        public MainWindow(Modules modules, IHost host)
        {
            InitializeComponent();
            _modules = modules;
            _host = host;

            foreach (var module in Enum.GetValues(typeof(ModuleEnum.ModulesEnum)))
            {
                _moduleNames.Add(string.Concat(module.ToString()!.Select(s => char.IsUpper(s) ? " " + s : s.ToString())).TrimStart(' '));
            }

            listBoxModules.ItemsSource = _moduleNames;
            listBoxModules.SelectionChanged += ListBoxModules_SelectionChanged;
            _selectedModule = "";
        }

        private void ListBoxModules_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (listBoxModules.SelectedItem == null)
                return;
            _selectedModule = listBoxModules.SelectedItem.ToString()!;
            if(Enum.Parse(typeof(ModuleEnum.ModulesEnum), listBoxModules.SelectedItem.ToString()!.Replace(" ", "")) is ModuleEnum.ModulesEnum parsedValue)
                _moduleEnum = parsedValue;
            labelSelectedItem.Content = $"Item Selected : {listBoxModules.SelectedItem}";
        }

        private void AddModuleClick(object sender, RoutedEventArgs e)
        {
            switch (_moduleEnum)
            {
                case ModuleEnum.ModulesEnum.FolderIn:
                case ModuleEnum.ModulesEnum.FolderOut:
                    var folderWindow = _host.Services.GetRequiredService<FolderPicker>();
                    if(folderWindow.ShowDialog() == true)
                        listBoxModuleOrder.Items.Add(_selectedModule);
                    break;
                case ModuleEnum.ModulesEnum.Encrypt:
                case ModuleEnum.ModulesEnum.Decrypt:
                    var encryptionWindow = _host.Services.GetRequiredService<Encryption>();
                    if(encryptionWindow.ShowDialog() == true)
                        listBoxModuleOrder.Items.Add(_selectedModule);
                    break;
                case ModuleEnum.ModulesEnum.MailOut:
                    var mailWindow = _host.Services.GetRequiredService<MailCompose>();
                    if (mailWindow.ShowDialog() == true)
                        listBoxModuleOrder.Items.Add(_selectedModule);
                    break;
                case ModuleEnum.ModulesEnum.TextReplace:
                    var replaceWindow = _host.Services.GetRequiredService<TextReplace>();
                    if (replaceWindow.ShowDialog() == true)
                        listBoxModuleOrder.Items.Add(_selectedModule);
                    break;
                case ModuleEnum.ModulesEnum.TextToPdf:
                    var convertWindow = _host.Services.GetRequiredService<ConvertComposer>();
                    if (convertWindow.ShowDialog() == true)
                        listBoxModuleOrder.Items.Add(_selectedModule);
                    break;
                case ModuleEnum.ModulesEnum.WordTemplate:
                    break;
                default:
                    throw new ArgumentNullException("No module was selected. Please select one before you try to add it.");
            }
        }

        private void RunModules(object sender, RoutedEventArgs e)
        {

        }
    }
}
