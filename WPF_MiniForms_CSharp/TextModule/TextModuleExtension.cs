using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MiniForms_CSharp.TextModule
{
    public static class TextModuleExtension
    {
        public static IServiceCollection AddTextModule(this IServiceCollection services)
        {
            services.AddTransient<WordTemplate>();
            services.AddTransient<ConvertComposer>();
            services.AddTransient<TextReplace>();
            services.AddTransient<TextService>();
            services.AddTransient<TextSettings>();
            return services;
        }
    }
}
