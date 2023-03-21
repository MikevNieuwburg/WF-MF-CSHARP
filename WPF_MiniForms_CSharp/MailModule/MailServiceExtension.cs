using Microsoft.Extensions.DependencyInjection;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Records;

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