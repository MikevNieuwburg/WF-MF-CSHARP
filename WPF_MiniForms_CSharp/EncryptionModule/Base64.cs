using System;
using System.Text;
using System.Windows;

namespace WPF_MiniForms_CSharp.Models.Helper;

public class Base64
{
    public string Encrypt(string text) => Convert.ToBase64String(Encoding.UTF8.GetBytes(text));

    public string Decrypt(string base64)
    {
        string placeholder = "";
        try
        {
            placeholder = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
        catch (Exception e)
        {
            MessageBox.Show("", e.Message);
        }
        return placeholder;
    }

}
