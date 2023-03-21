using System.Windows;
using WPF_MiniForms_CSharp.Core;
using WPF_MiniForms_CSharp.Models.Functions;

namespace WPF_MiniForms_CSharp.EncryptionModule;

public partial class Encryption : Window
{
    public EncodeRecord? CryptoObject;
    public EncryptionService? Service;
    public EncryptionWindowObject? Window;

    public Encryption(EncryptionService service)
    {
        InitializeComponent();
        ResetWindow(Window!);
        Service = service;
    }

    private void ResetWindow(EncryptionWindowObject window)
    {
        passwordField.Text = window?.Password;
        saltField.Text = window?.Salt;
    }


    private void EncodeObject(object sender, RoutedEventArgs e)
    {
        bool Encrypt = true;
        CryptoObject = new EncodeRecord(Encrypt, passwordField.Text, saltField.Text);
        Window = new EncryptionWindowObject(passwordField.Text, saltField.Text);
        DialogResult = true;
    }

    private void DecodeObject(object sender, RoutedEventArgs e)
    {
        bool Encrypt = false;
        CryptoObject = new EncodeRecord(Encrypt, passwordField.Text, saltField.Text);
        Window = new EncryptionWindowObject(passwordField.Text, saltField.Text);
        DialogResult = true;
    }
}
