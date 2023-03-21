using Microsoft.Extensions.DependencyInjection;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Helper;
using WPF_MiniForms_CSharp.Models.Modules;

namespace WPF_MiniForms_CSharp.FolderModule;

public static class FolderServiceExtension
{
    public static IServiceCollection AddFolderModule(this IServiceCollection services)
    {
        services.AddTransient<FolderService>();
        services.AddTransient<FolderPicker>();
        services.AddTransient<FolderFunctions>();
        services.AddTransient<FileContentHelper>();
        return services;
    }
}