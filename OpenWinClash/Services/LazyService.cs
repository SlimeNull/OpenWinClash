using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWinClash.Utilities;

namespace OpenWinClash.Services
{
    public class LazyService<TService> where TService : class
    {
        public LazyService(IServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;

            laziedService = new Lazy<TService>(() => serviceProvider.GetServiceOrThrow<TService>());
        }

        private Lazy<TService> laziedService;


        public IServiceProvider ServiceProvider { get; }

        public TService Service => laziedService.Value;
    }
}
