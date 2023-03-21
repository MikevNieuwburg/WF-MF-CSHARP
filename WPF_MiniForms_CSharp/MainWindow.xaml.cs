using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WPF_MiniForms_CSharp.Core;
using WPF_MiniForms_CSharp.EncryptionModule;
using WPF_MiniForms_CSharp.FolderModule;
using WPF_MiniForms_CSharp.MailModule;
using WPF_MiniForms_CSharp.Models.Interfaces;
using WPF_MiniForms_CSharp.TextModule;

namespace WPF_MiniForms_CSharp;

public partial class MainWindow : Window
{
    private readonly IHost _host;
    private readonly List<string> _moduleNames = new();
    private readonly List<IService> _modules = new();
    private readonly List<object> _windows = new();
    private int _lastSelectedModule;
    private ModuleEnum.ModulesEnum _moduleEnum;
    private ModuleEnum.ModulesEnum _orderModule;
    private string _selectedModule;

    public MainWindow(IHost host)
    {
        InitializeComponent();
        _host = host;
        foreach (var module in Enum.GetValues(typeof(ModuleEnum.ModulesEnum)))
            _moduleNames.Add(string.Concat(module.ToString()!.Select(s => char.IsUpper(s) ? " " + s : s.ToString()))
                .TrimStart(' '));

        listBoxModules.ItemsSource = _moduleNames;
        listBoxModules.SelectionChanged += ListBoxModules_SelectionChanged;
        listBoxModuleOrder.SelectionChanged += ModuleListItemSelected;
        _selectedModule = "";
    }

    private void ModuleListItemSelected(object sender, SelectionChangedEventArgs e)
    {
        if (listBoxModuleOrder.SelectedItem == null)
            return;
        _lastSelectedModule = listBoxModuleOrder.SelectedIndex;

        _selectedModule = listBoxModuleOrder.SelectedItem.ToString()!;
        labelLastSelectedItem.Content = $"Item Selected : {listBoxModuleOrder.SelectedItem}";
    }

    private void ListBoxModules_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (listBoxModules.SelectedItem == null)
            return;
        _selectedModule = listBoxModules.SelectedItem.ToString()!;
        if (Enum.Parse(typeof(ModuleEnum.ModulesEnum), listBoxModules.SelectedItem.ToString()!.Replace(" ", "")) is
            ModuleEnum.ModulesEnum parsedValue)
            _moduleEnum = parsedValue;
        labelSelectedItem.Content = $"Item Selected : {listBoxModules.SelectedItem}";
    }

    private void AddModuleClick(object sender, RoutedEventArgs e)
    {
        OpenModule(_moduleEnum);
    }

    private void OpenModule(ModuleEnum.ModulesEnum moduleEnum, object passWindow = null)
    {
        switch (moduleEnum)
        {
            case ModuleEnum.ModulesEnum.FolderIn:
                var folderInWindow = _host.Services.GetRequiredService<FolderPicker>();
                if (passWindow is string fiPath)
                    folderInWindow.GivenPath = fiPath;
                if (folderInWindow.ShowDialog() == true)
                {
                    listBoxModuleOrder.Items.Add(_selectedModule);
                    folderInWindow.Service.Module = _moduleEnum;
                    folderInWindow.Service.TaskInput = folderInWindow.GivenPath;
                    _modules.Add(folderInWindow.Service);
                    _windows.Add(folderInWindow.GivenPath);
                }

                break;
            case ModuleEnum.ModulesEnum.FolderOut:
                var folderOutWindow = _host.Services.GetRequiredService<FolderPicker>();
                if (passWindow is string foPath)
                    folderOutWindow.GivenPath = foPath;
                if (folderOutWindow.ShowDialog() == true)
                {
                    listBoxModuleOrder.Items.Add(_selectedModule);
                    folderOutWindow.Service.Module = _moduleEnum;
                    folderOutWindow.Service.TaskInput = folderOutWindow.GivenPath;
                    _modules.Add(folderOutWindow.Service);
                    _windows.Add(folderOutWindow.GivenPath);
                }

                break;
            case ModuleEnum.ModulesEnum.Encrypt:
            case ModuleEnum.ModulesEnum.Decrypt:
                var encryptionWindow = _host.Services.GetRequiredService<Encryption>();
                if (passWindow is EncryptionWindowObject windowObject)
                    encryptionWindow.Window = windowObject;
                if (encryptionWindow.ShowDialog() == true)
                {
                    listBoxModuleOrder.Items.Add(_selectedModule);
                    encryptionWindow.Service.TaskInput = encryptionWindow.CryptoObject;
                    _modules.Add(encryptionWindow.Service);
                    _windows.Add(encryptionWindow.Window);
                }

                break;
            case ModuleEnum.ModulesEnum.MailOut:
                var mailWindow = _host.Services.GetRequiredService<MailCompose>();
                if (passWindow is MailWindow mwObject)
                    mailWindow.Window = mwObject;
                if (mailWindow.ShowDialog() == true)
                {
                    listBoxModuleOrder.Items.Add(_selectedModule);
                    mailWindow.Service.TaskInput = mailWindow.Mail;
                    _modules.Add(mailWindow.Service);
                    _windows.Add(mailWindow.Window);
                }

                break;
            case ModuleEnum.ModulesEnum.TextReplace:
                var replaceWindow = _host.Services.GetRequiredService<TextReplace>();
                if (passWindow is TextReplaceWindow trWindow)
                    replaceWindow.Window = trWindow;
                if (replaceWindow.ShowDialog() == true)
                {
                    listBoxModuleOrder.Items.Add(_selectedModule);
                    replaceWindow.Service.ToPdf = false;
                    _modules.Add(replaceWindow.Service);
                    _windows.Add(replaceWindow.Window);
                }

                break;
            case ModuleEnum.ModulesEnum.TextToPdf:
                var convertWindow = _host.Services.GetRequiredService<ConvertComposer>();
                if (passWindow is ConvertWindow cWindow)
                    convertWindow.Window = cWindow;
                if (convertWindow.ShowDialog() == true)
                {
                    listBoxModuleOrder.Items.Add(_selectedModule);
                    if (convertWindow.Service != null)
                    {
                        convertWindow.Service.ToPdf = true;
                        _modules.Add(convertWindow.Service);
                    }

                    _windows.Add(convertWindow.Window);
                }

                break;
            case ModuleEnum.ModulesEnum.WordTemplate:
                var wordWindow = _host.Services.GetRequiredService<WordTemplate>();
                if (passWindow is string templateFile)
                    wordWindow.TemplateFile = templateFile;
                if (wordWindow.ShowDialog() == true)
                {
                    listBoxModuleOrder.Items.Add(_selectedModule);
                    _modules.Add(wordWindow.Service);
                    _windows.Add(wordWindow.TemplateFile);
                }

                break;
            default:
                throw new ArgumentNullException("No module was selected. Please select one before you try to add it.");
        }
    }

    private void RunModules(object sender, RoutedEventArgs e)
    {
        if (_modules.Count == 0)
        {
            informationStack.Items.Add("No modules available.");

            return;
        }

        informationStack.Items.Add($"Starting at: {DateTime.Now.ToShortTimeString()}");

        for (var i = 0; i < _modules.Count; i++)
        {
            var module = _modules[i];
            module.Execute();
            informationStack.Items.Add($"{nameof(module)} #{i} started");
        }

        informationStack.Items.Add($"All modules completed.\nEnd time at {DateTime.Now.ToShortTimeString()}");
    }

    private void DeleteModule(object sender, RoutedEventArgs e)
    {
        if (listBoxModuleOrder.Items.Count == 0)
            return;

        listBoxModuleOrder.Items.RemoveAt(_lastSelectedModule);
        _modules.RemoveAt(_lastSelectedModule);
        _windows.RemoveAt(_lastSelectedModule);
    }

    private void InspectModule(object sender, RoutedEventArgs e)
    {
        if (listBoxModuleOrder.Items.Count == 0 || _lastSelectedModule > listBoxModuleOrder.Items.Count)
            return;
        if (Enum.Parse(typeof(ModuleEnum.ModulesEnum), listBoxModuleOrder.SelectedItem.ToString()!.Replace(" ", "")) is
            ModuleEnum.ModulesEnum parsedValue)
            _orderModule = parsedValue;

        if (_orderModule != null)
            OpenModule(_orderModule, _windows[listBoxModuleOrder.SelectedIndex]);
    }
}