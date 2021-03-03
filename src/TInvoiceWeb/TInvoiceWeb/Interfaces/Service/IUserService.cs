using System.Collections.Generic;
using TInvoiceWeb.Data;
using TInvoiceWeb.Models;
using TInvoiceWeb.Responses;

namespace TInvoiceWeb.Interfaces
{
    public interface IUserService
    {
        Employee GetUser(int id);
        IEnumerable<Employee> GetAllUsers(int offset, int limit);
        IEnumerable<Employee> GetAllUsers();
        Employee CreateUser(Employee employee);
        void DeleteUser(Employee employee);
        Employee GetUserByEmail(string email);
        bool CheckUserEmail(string email);
        bool CheckUserEmail(string email, int id);
        bool CheckPassword(string password, string passwordIn, string salt);
        void UpdateUser(Employee newEmployee, Employee oldEmployee);
        public string Authenticate(int id, int level, bool remenber);

    }
}
