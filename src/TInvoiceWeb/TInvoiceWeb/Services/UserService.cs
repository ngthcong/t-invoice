using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TInvoiceWeb.Data;
using TInvoiceWeb.Helpers;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Models;
using TInvoiceWeb.Responses;

namespace TInvoiceWeb.Services
{

    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;
        private readonly AppSettings _appSettings;

        public UserService(IUserRepository repository, IOptions<AppSettings> appSettings)
        {
            _repo = repository;
            _appSettings = appSettings.Value;
        }

        public string Authenticate(int id, int level, bool remember)
        {
            int time = _appSettings.ShortExpiration;
            if (remember)
               time = _appSettings.LongExpiration;
            return generateJwtToken(id, level, time);
        }
        private string generateJwtToken(int id, int level, int time)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var toKenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", id.ToString()), new Claim(ClaimTypes.Role, level.ToString()) }),
                Expires = DateTime.UtcNow.AddSeconds(time),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = TokenHandler.CreateToken(toKenDescriptor);
            return TokenHandler.WriteToken(token);
        }

        public Employee CreateUser(Employee employee)
        {
            string SALT = Hashing.GetRandomSalt();
            employee.Salt = SALT;
            employee.Password = Hashing.HashingPassword(employee.Password, SALT);
            _repo.CreateUser(employee);
            _repo.SaveChanges();
            return employee;
        }


        public void DeleteUser(Employee employee)
        {
            _repo.DeleteUser(employee);
            _repo.SaveChanges();
        }

        public Employee GetUser(int empId)
        {
            var emp = _repo.GetUser(empId);
            if (emp == null)
                return null;
            return emp;
        }

        public void UpdateUser(Employee newEmployee, Employee oldEmployee)
        {
            string SALT = Hashing.GetRandomSalt();
            oldEmployee.Email = newEmployee.Email;
            oldEmployee.Contact = newEmployee.Contact;
            oldEmployee.FullName = newEmployee.FullName;
            oldEmployee.Level = newEmployee.Level;
            oldEmployee.Note = newEmployee.Note;
            oldEmployee.Salt = SALT;
            oldEmployee.Password = Hashing.HashingPassword(newEmployee.Password, SALT);
            _repo.UpdateUser(oldEmployee);
            _repo.SaveChanges();


        }
        public Employee GetUserByEmail(string email)
        {
            return _repo.GetUserByEmail(email);
        }

        public bool CheckUserEmail(string email, int id)
        {
            return _repo.CheckUserEmail(email, id);
        }
        public bool CheckUserEmail(string email)
        {
            return _repo.CheckUserEmail(email);
        }

        public bool CheckPassword(string password, string passwordIn, string salt)
        {
            return password == Hashing.HashingPassword(passwordIn, salt);
        }

        public IEnumerable<Employee> GetAllUsers(int offset, int limit)
        {
            if (limit > _appSettings.MaxLimit)
                limit = 20;
            return _repo.GetAllUsers(offset,limit);
        }

        public IEnumerable<Employee> GetAllUsers()
        {
            return _repo.GetAllUsers();
        }
    }
}
