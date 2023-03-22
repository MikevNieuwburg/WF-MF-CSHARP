namespace WPF_MiniForms_CSharp.EncryptionModule;

public class Base64
{
    private const string NO_BASE64_STRING = "File doesn't contain a suitable Base64 string.";
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
            throw e switch
            {
                DecoderFallbackException decoderFallbackException => decoderFallbackException,
                ArgumentException argumentException => argumentException,
                FormatException formatException => formatException,
                _ => new Exception(NO_BASE64_STRING, e.InnerException),
            };
        }

        return placeholder;
    }
}