using System.Windows;
using WPF_MiniForms_CSharp.Models.Functions;

namespace WPF_MiniForms_CSharp.MailModule;

public partial class MailCompose : Window
{
    private readonly MailService _service;

    public MailCompose(MailService service)
    {
        InitializeComponent();
        _service = service;
    }
}
