using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace TInvoiceForm
{
    public static class ServiceLocator
    {
        private static ServiceProvider ServiceProvider;
        private static ServiceCollection Services = new ServiceCollection();
        public static TService GetService<TService>()
        {
            if (ServiceProvider == null)
                ServiceProvider = Services.BuildServiceProvider();
            return (TService)ServiceProvider.GetService(typeof(TService));
        }
        public static object GetService(Type serviceType)
        {
            return ServiceProvider.GetService(serviceType);
        }
        public static void Register<TService, TImplementation>() where TService : class where TImplementation : class, TService
        {
            Services.AddSingleton<TService, TImplementation>();
            ServiceProvider = Services.BuildServiceProvider();
        }
        public static void Register(Type ServiceType)
        {
            Services.AddSingleton(ServiceType);
            ServiceProvider = Services.BuildServiceProvider();
        }
        public static void Register<TService>() where TService : class
        {
            Services.AddSingleton<TService, TService>();
            ServiceProvider = Services.BuildServiceProvider();
        }
        public static void Register<TService>(TService serviceInstance) where TService : class
        {
            Services.AddSingleton<TService>(serviceInstance);
            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
