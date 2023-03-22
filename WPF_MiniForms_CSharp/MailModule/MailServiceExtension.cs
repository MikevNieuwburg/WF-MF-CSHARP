namespace WPF_MiniForms_CSharp.MailModule;

public static class MailServiceExtension
{
    public static IServiceCollection AddMailServices(this IServiceCollection services)
    {
        services.AddTransient<MailService>();
        services.AddTransient<MailCompose>();
        services.AddTransient<ComposeMail>();
        return services;
    }
}