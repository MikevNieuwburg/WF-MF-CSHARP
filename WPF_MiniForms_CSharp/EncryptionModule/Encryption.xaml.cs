using System.Windows;

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
        const bool encrypt = true;
        CryptoObject = new EncodeRecord(encrypt, passwordField.Text, saltField.Text);
        Window = new EncryptionWindowObject(passwordField.Text, saltField.Text);
        DialogResult = true;
    }

    private void DecodeObject(object sender, RoutedEventArgs e)
    {
        const bool encrypt = false;
        CryptoObject = new EncodeRecord(encrypt, passwordField.Text, saltField.Text);
        Window = new EncryptionWindowObject(passwordField.Text, saltField.Text);
        DialogResult = true;
    }
}