﻿using System.Windows;

namespace WPF_MiniForms_CSharp.TextModule;

public partial class TextReplace : Window
{
    public TextService Service;
    public TextReplaceWindow Window;
    public TextReplace(TextService service)
    {
        InitializeComponent();
        Service = service;
        ResetWindow(Window);
    }

    private void ResetWindow(TextReplaceWindow window)
    {
        changeFrom.Text = window?.From;
        changeTo.Text = window?.To;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Service.TaskInput = new TextSettings(changeFrom.Text, changeTo.Text);
        Window = new TextReplaceWindow(From: changeFrom.Text, To: changeTo.Text);
        DialogResult = true;
        Close();
    }
}
