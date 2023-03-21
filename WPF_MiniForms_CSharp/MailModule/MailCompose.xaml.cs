using System.Windows;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Records;

namespace WPF_MiniForms_CSharp.MailModule;

public partial class MailCompose : Window
{
    public MailService Service;
    public ComposeMail Mail { get; set; }
    public MailWindow Window;

    public MailCompose(MailService service)
    {
        InitializeComponent();
        Service = service;
        ReopenWindow(Window);
    }

    private void ReopenWindow(MailWindow window)
    {
        receiver.Text = window?.Receiver;
        carboncopy.Text = window?.CC;
        blindcopy.Text = window?.BCC;
        header.Text = window?.Header;
        message.Text = window?.Message;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var receivers = receiver.Text;
        var cc = carboncopy.Text;
        var bcc = blindcopy.Text;
        var title = header.Text;
        var msg = message.Text;
        Mail = new ComposeMail(title, msg, receivers, cc, bcc);
        Window = new MailWindow(Header: title, Message: msg, Receiver: receivers, CC: cc, BCC: bcc);
        DialogResult = true;
    }
}
