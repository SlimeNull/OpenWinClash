using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using OpenWinClash.Utilities;

namespace OpenWinClash.Services
{
    internal class ApplicationHostedService : IHostedService
    {
        public ApplicationHostedService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public IServiceProvider ServiceProvider { get; }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return Task.FromCanceled(cancellationToken);

            if (Application.Current.MainWindow is not MainWindow window)
                window = ServiceProvider.GetServiceOrThrow<MainWindow>();

            window.Show();

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
                return Task.FromCanceled(cancellationToken);

            if (Application.Current.MainWindow is Window window)
                window.Close();

            return Task.CompletedTask;
        }
    }
}
