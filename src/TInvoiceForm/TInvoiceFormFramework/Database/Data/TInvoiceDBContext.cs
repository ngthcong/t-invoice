using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TInvoiceFormFramework.Database.Data
{
    class TInvoiceDBContext :DbContext
    {
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TmaBank> TmaBanks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public TInvoiceDBContext(DbContextOptions<TInvoiceDBContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=TInvoiceDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
