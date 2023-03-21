using System;
using System.Text;

namespace WPF_MiniForms_CSharp.Models.Helper;

public class Base64
{
    public string Encrypt(string text)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(text));
    }

    public string Decrypt(string base64)
    {
        string placeholder;
        try
        {
            placeholder = Encoding.UTF8.GetString(Convert.FromBase64String(base64));
        }
        catch (Exception e)
        {
            throw new Exception("File doesn't contain a suitable Base64 string.", e.InnerException);
        }

        return placeholder;
    }
}