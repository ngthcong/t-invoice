using System.Collections.Generic;
using System.Linq;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Models;

namespace TInvoiceWeb.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TInvoiceDBContext _context;

        public UserRepository(TInvoiceDBContext invoiceDBContext)
        {
            _context = invoiceDBContext;
        }
        public void DeleteUser(Employee employee)
        {
            _context.Employees.Remove(employee);
        }
        public void CreateUser(Employee employee)
        {
            _context.Employees.Add(employee);
        }

        public Employee GetUserByEmail(string email)
        {
            return _context.Employees.Where(i => i.Email.ToLower() == email.ToLower()).FirstOrDefault();
        }
        public bool CheckUserEmail(string email, int id)
        {
            return _context.Employees.Where(i => i.Email.ToLower() == email.ToLower() && i.EmpId == id).Any();
        }

        public int GetUserRole(int id)
        {
            return _context.Employees.Where(x => x.EmpId == id).Select(lv => lv.Level).FirstOrDefault();
        }
        public Employee GetUser(int id)
        {
            return _context.Employees.Where(i => i.EmpId == id).SingleOrDefault();
        }

        public Employee LoginUser(AuthenticateRequest model)
        {
            return _context.Employees.Where(i => i.Email == model.Email && i.Password == model.Password).SingleOrDefault();
        }
        public void UpdateUser(Employee employee)
        {
            _context.Update(employee);
        }



        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool CheckUserEmail(string email)
        {
            return _context.Employees.Where(i => i.Email.ToLower() == email.ToLower()).Any();
        }

        public IEnumerable<Employee> GetAllUsers(int offset, int limit)
        {  

            return _context.Employees.Skip(offset).Take(limit);;
        }

        public IEnumerable<Employee> GetAllUsers()
        {
            return _context.Employees;
        }

    }
}
