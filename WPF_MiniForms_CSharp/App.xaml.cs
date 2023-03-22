namespace WPF_MiniForms_CSharp;

public partial class App : Application
{
    private readonly IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) => { ConfigureServices(services); })
            .Build();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<MainWindow>();
        services.AddSingleton<TemporaryFolder>();
        services.AddTransient<Base64>();
        services.AddTransient<EncodeRecord>();
        services.AddTransient<MailWindow>();
        services.AddTransient<WordTemplateService>();
        services.AddTransient<PdfConversion>();
        services.AddTransient<ConvertWindow>();
        services.AddTransient<TextReplaceWindow>();
        // Setup folder functionality.
        services.AddFolderModule();

        // Setup mail functionality.
        services.AddMailServices();

        // Setup Text functionality.
        services.AddTextModule();

        // Setup encryption.
        services.AddEncryptionModule();
    }

    protected override async void OnStartup(StartupEventArgs e)
    {
        await _host.StartAsync();
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
        base.OnStartup(e);
    }

    protected override async void OnExit(ExitEventArgs e)
    {
        await _host.StopAsync();
        base.OnExit(e);
    }
}