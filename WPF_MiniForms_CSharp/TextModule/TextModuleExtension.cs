using Microsoft.Extensions.DependencyInjection;

namespace WPF_MiniForms_CSharp.TextModule;

public static class TextModuleExtension
{
    public static IServiceCollection AddTextModule(this IServiceCollection services)
    {
        services.AddTransient<WordTemplate>();
        services.AddTransient<WordTemplateService>();
        services.AddTransient<ConvertComposer>();
        services.AddTransient<TextReplace>();
        services.AddTransient<TextService>();
        services.AddTransient<TextSettings>();
        return services;
    }
}
