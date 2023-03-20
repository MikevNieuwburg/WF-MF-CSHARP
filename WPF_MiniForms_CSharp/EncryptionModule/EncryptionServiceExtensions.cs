using Microsoft.Extensions.DependencyInjection;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Helper;

namespace WPF_MiniForms_CSharp.EncryptionModule
{
    public static class EncryptionServiceExtensions
    {
        public static IServiceCollection AddEncryptionModule(this IServiceCollection services)
        {
            services.AddTransient<IEncryption, AesEncryption>();
            services.AddTransient<EncryptionService>();
            services.AddTransient<Encryption>();
            services.AddTransient<CryptoObject>();
            return services;
        }
    }
}
