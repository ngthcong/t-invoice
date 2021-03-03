using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;

namespace TInvoiceWeb.Interfaces
{
    public interface ICustomerRepository
    {
        Customer GetCustomer(int cusid);

        Customer GetCustomerByEmail(string email);

        IEnumerable<Customer> GetAllCustomer(int offset, int limit);

        IEnumerable<Customer> GetAllCustomer(int offset);

        void CreateCustomer(Customer customer);

        void DeleteCustomer(Customer customer);

        void UpdateCustomer(Customer customer);

        void SaveChanges();
    }
}
