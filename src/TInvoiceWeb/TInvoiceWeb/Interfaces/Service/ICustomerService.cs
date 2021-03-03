using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;

namespace TInvoiceWeb.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(int idCus);

        ICollection<Customer> GetAllCustomer(int offset, int? limit = null);

        bool IsEmailExist(string email);

        Customer CreateCustomer(Customer customer);

        bool DeleteCustomer(int idCus);

        Customer UpdateCustomer(Customer oldCustomer, Customer newCustomer);

     
    }
}
