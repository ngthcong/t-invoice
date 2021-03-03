using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;
using TInvoiceWeb.Models;

namespace TInvoiceWeb.Interfaces
{
    public interface IUserRepository
    {
        Employee GetUser(int id);
        IEnumerable<Employee> GetAllUsers(int offset, int limit);
        IEnumerable<Employee> GetAllUsers();
        void CreateUser(Employee employee);
        void DeleteUser(Employee employee);
        void UpdateUser(Employee employee);
        int GetUserRole(int id);
        Employee GetUserByEmail(string email);
        bool CheckUserEmail(string email, int id);
        bool CheckUserEmail(string email);
        Employee LoginUser(AuthenticateRequest model);
        void SaveChanges();
    }
}
