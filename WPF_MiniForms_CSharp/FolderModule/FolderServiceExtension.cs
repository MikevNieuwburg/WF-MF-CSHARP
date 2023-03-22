using Microsoft.Extensions.DependencyInjection;

namespace WPF_MiniForms_CSharp.FolderModule;

public static class FolderServiceExtension
{
    public static IServiceCollection AddFolderModule(this IServiceCollection services)
    {
        services.AddTransient<FolderService>();
        services.AddTransient<FolderPicker>();
        services.AddTransient<FolderFunctions>();
        return services;
    }
}