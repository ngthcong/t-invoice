using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;

namespace TInvoiceWeb.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            _repository.CreateCustomer(customer);
            _repository.SaveChanges();
            return customer;
        }

        public bool DeleteCustomer(int idCus)
        {
            var cus = _repository.GetCustomer(idCus);
            if (cus == null)
            {
                return false;
            }
            else
            {
                _repository.DeleteCustomer(cus);
                _repository.SaveChanges();
                return true;
            }
        }

        public ICollection<Customer> GetAllCustomer(int offset, int? limit = null)
        {
            if(limit == null)
                return _repository.GetAllCustomer(offset).ToList();
            if (limit > 0)
                return _repository.GetAllCustomer(offset, limit.Value).ToList();
            return Array.Empty<Customer>();
        }

        public Customer GetCustomer(int idCus)
        {
            var cus = _repository.GetCustomer(idCus);
            return cus;
        }

        public bool IsEmailExist(string email)
        {
            return _repository.GetCustomerByEmail(email) != null;
        }

        public Customer UpdateCustomer(Customer oldCustomer, Customer newCustomer)
        {
            oldCustomer.Email = newCustomer.Email;
            oldCustomer.Fullname = newCustomer.Fullname;
            oldCustomer.Address = newCustomer.Address;
            oldCustomer.Contact = newCustomer.Contact;
            oldCustomer.Note = newCustomer.Note;
            _repository.UpdateCustomer(oldCustomer);
            _repository.SaveChanges();
            return oldCustomer;
        }
    }
}
