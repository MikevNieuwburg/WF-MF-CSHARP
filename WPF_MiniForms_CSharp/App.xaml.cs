using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Windows;
using WPF_MiniForms_CSharp.Core;
using WPF_MiniForms_CSharp.EncryptionModule;
using WPF_MiniForms_CSharp.FolderModule;
using WPF_MiniForms_CSharp.MailModule;
using WPF_MiniForms_CSharp.Models.Functions;
using WPF_MiniForms_CSharp.Models.Helper;
using WPF_MiniForms_CSharp.Models.Interfaces;
using WPF_MiniForms_CSharp.Models.Modules;
using WPF_MiniForms_CSharp.Views;

namespace WPF_MiniForms_CSharp
{
    public partial class App : Application
    {
        private readonly IHost _host;
        public App()
        {
            //var b_host = Host.CreateApplicationBuilder();
            //b_host.Services.AddScoped

            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);
                })
                .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<MainWindow>();
            services.AddSingleton<ModuleUserControl>();

            services.AddTransient<FolderService>();
            services.AddTransient<FolderPicker>();
            services.AddTransient<MailCompose>();
            services.AddTransient<MailService>();
            services.AddTransient<Modules>();

            // Setup encryption
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
}
