using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.CompilerServices;
using System;
using TInvoiceForm.Database;
using TInvoiceForm.Database.Data;
using TInvoiceForm.Presenters;
using TInvoiceForm.Views;
using TInvoiceForm.Views.Interfaces;

namespace TInvoiceForm
{
    public class Startup
    {
        public static void Configure()
        {
            AddDBContext("Hello");
            ServiceLocator.Register<LoginPresenter, LoginPresenter>();
            ServiceLocator.Register<CustomerRepository>();
            ServiceLocator.Register<DescriptionRepository>();
            ServiceLocator.Register<EmployeeRepository>();
            ServiceLocator.Register<InvoiceRepository>();
            ServiceLocator.Register<ProjectRepository>();
            ServiceLocator.Register<TmaBankRepository>();
        }
        private static void AddDBContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TInvoiceDBContext>();
            ServiceLocator.Register(optionsBuilder.UseSqlServer(connectionString).Options);
            ServiceLocator.Register<DbContext, TInvoiceDBContext>();
        }
    }
}
