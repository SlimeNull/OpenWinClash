using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OpenWinClash.Utilities
{
    internal static class ServiceUtils
    {
        /// <summary>
        /// Get service or throw exception
        /// </summary>
        /// <typeparam name="TService"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static TService GetServiceOrThrow<TService>(this IServiceProvider serviceProvider) where TService : class
        {
            return serviceProvider.GetService<TService>() ?? throw new InvalidOperationException("Couldn't get service with specified type");
        }
    }
}
