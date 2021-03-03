using System.Collections.Generic;
using System.Linq;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;

namespace TInvoiceWeb.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly TInvoiceDBContext _context;

        public CustomerRepository(TInvoiceDBContext context)
        {
            _context = context;
        }

        public void CreateCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
        }

        public Customer GetCustomer(int cusid)
        {
            return _context.Customers.Where(x => x.CusId == cusid).FirstOrDefault();
        }
        public void DeleteCustomer(Customer customer)
        {
            _context.Customers.Remove(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers.Where(x => x.Email.ToLower().Equals(email.ToLower())).FirstOrDefault();
        }

        public IEnumerable<Customer> GetAllCustomer(int offset, int limit)
        {
            return _context.Customers.Skip(offset).Take(limit).ToList();
        }

        public IEnumerable<Customer> GetAllCustomer(int offset)
        {
            return _context.Customers.Skip(offset).ToList();
        }
    }
}
