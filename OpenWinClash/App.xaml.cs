using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using OpenWinClash.Models;
using OpenWinClash.Models.Clash.Configuration;
using OpenWinClash.Services;
using OpenWinClash.Utilities;
using OpenWinClash.ViewModels;

namespace OpenWinClash
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static readonly IHost host = Host.CreateDefaultBuilder()
            .ConfigureLogging((context, builder) =>
            {

            })
            .ConfigureServices((context, services) =>
            {
                // hosted service
                services
                    .AddHostedService<ApplicationHostedService>();

                // some components
                services
                    .AddSingleton(typeof(LazyService<>));     // 解决循环依赖的玩意儿

                // data
                services
                    .AddSingleton<AppGlobalData>();

                // UI
                services.AddSingleton<MainWindow>();
                services.AddSingleton<MainViewModel>();


                // logging
                services
                    .AddLogging(builder =>
                    {
                        builder.ClearProviders();
                        builder.AddNLog();
                    });

                // configuration
                services
                    .Configure<AppConfig>(o =>
                    {
                        context.Configuration.Bind(o);
                    });
            })
            .Build();

        protected override void OnStartup(StartupEventArgs e)
        {
#if DEBUG
            string yaml = File.ReadAllText("Test/TestClashConfig.yaml");
            ClashConfiguration clashConfiguration =
                YamlUtils.Deserializer.Deserialize<ClashConfiguration>(yaml);

            Debug.Print(clashConfiguration.ToString());
#endif

            host.Start();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            // not wait
            _ = host.StopAsync();
        }
    }
}
