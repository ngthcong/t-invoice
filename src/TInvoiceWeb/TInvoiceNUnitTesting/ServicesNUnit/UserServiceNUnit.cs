using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DocumentFormat.OpenXml.Office2010.PowerPoint;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NUnit.Framework;
using TInvoiceWeb.Data;
using TInvoiceWeb.Helpers;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Repositories;
using TInvoiceWeb.Services;

namespace TInvoiceNUnitTesting.ServicesNUnit
{
    class UserServiceNUnit
    {
        private IUserService _userService;
        private TInvoiceWeb.Data.TInvoiceDBContext _context;
        private readonly AppSettings _appSettings;
        private Employee deleteEmployee = new Employee();
        [SetUp]
        public void Setup()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<TInvoiceDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            var secret = configuration.GetSection("AppSettings")["Secret"];
            _context = new TInvoiceDBContext(optionsBuilder.Options);

            _userService = new UserService(new UserRepository(_context), Options.Create<AppSettings>(new AppSettings() { Secret = secret }));

        }
        [TearDown]
        public void ClearAll()
        {
             _userService.DeleteUser(deleteEmployee);
        }
        [Test]
        public void TestCreateUser()
        {
            Employee newEmployee = new Employee()
            {
                FullName = "Test",
                Email = "abcde123hj@gmail.com",
                Password = "1132435",
                Level = 1,
                Contact = "0349554442",
                Note = "NUnit testing 12345"
            };
            Employee employee = _userService.CreateUser(newEmployee);
            deleteEmployee = employee;
            int emId = employee.EmpId;

            // Test Get User
            Employee emInfo = _userService.GetUser(emId);
            Assert.AreEqual(emInfo.FullName, newEmployee.FullName);
            Assert.AreEqual(emInfo.Email, newEmployee.Email);
            Assert.AreEqual(emInfo.Password, newEmployee.Password);
            Assert.AreEqual(emInfo.Level, newEmployee.Level);
            Assert.AreEqual(emInfo.Contact, newEmployee.Contact);
            Assert.AreEqual(emInfo.Note, newEmployee.Note);
        }
        [Test]
        public void TestUpdateUser()
        {
            Employee newEmployee = new Employee()
            {
                FullName = "uSER123",
                Email = "User321@gmailg.com",
                Password = "123456789x@X",
                Level = 2,
                Contact = "0972768003",
                Note = ""
            };
            Employee employee = _userService.CreateUser(newEmployee);
            int emId = employee.EmpId;

            // Update Fullname only

            Employee updateValue = new Employee()
            {
                EmpId = emId,
                FullName = "xcbv",
                Email = "tea1435@gmail.com",
                Password = "123456789x@X",
                Level = 2,
                Contact = "0972768003",
                Note = ""
            };
            _userService.UpdateUser(newEmployee, updateValue);
            Employee emInfo = _userService.GetUser(emId);
            Assert.AreEqual(emInfo.FullName, updateValue.FullName);
            Assert.AreEqual(emInfo.Email, updateValue.Email);
            Assert.AreEqual(emInfo.Password, updateValue.Password);
            Assert.AreEqual(emInfo.Level, updateValue.Level);
            Assert.AreEqual(emInfo.Contact, updateValue.Contact);
            Assert.AreEqual(emInfo.Note, updateValue.Note);

            // Update Email only

            Employee updateValue1 = new Employee()
            {
                EmpId = emId,
                FullName = "xcbv",
                Email = "milk123@5675gmailetiis.com",
                Password = "123456789x@X",
                Level = 2,
                Contact = "0972768003",
                Note = ""
            };
            _userService.UpdateUser(updateValue, updateValue1);
            emInfo = _userService.GetUser(emId);
            Assert.AreEqual(emInfo.FullName, updateValue1.FullName);
            Assert.AreEqual(emInfo.Email, updateValue1.Email);
            Assert.AreEqual(emInfo.Password, updateValue1.Password);
            Assert.AreEqual(emInfo.Level, updateValue1.Level);
            Assert.AreEqual(emInfo.Contact, updateValue1.Contact);
            Assert.AreEqual(emInfo.Note, updateValue1.Note);

            // Update Password only

            Employee updateValue2 = new Employee()
            {
                EmpId = emId,
                FullName = "xcbv",
                Email = "Bi123@5675gmailetiis.com",
                Password = "Lmnbvcxz1@",
                Level = 2,
                Contact = "0972768003",
                Note = ""
            };
            _userService.UpdateUser(updateValue1,updateValue2);
            emInfo = _userService.GetUser(emId);
            Assert.AreEqual(emInfo.FullName, updateValue2.FullName);
            Assert.AreEqual(emInfo.Email, updateValue2.Email);
            Assert.AreEqual(emInfo.Password, updateValue2.Password);
            Assert.AreEqual(emInfo.Level, updateValue2.Level);
            Assert.AreEqual(emInfo.Contact, updateValue2.Contact);
            Assert.AreEqual(emInfo.Note, updateValue2.Note);

            // Update Level only

            Employee updateValue3 = new Employee()
            {
                EmpId = emId,
                FullName = "xcbv",
                Email = "milk123@5675gmailetiis.com",
                Password = "Lmnbvcxz1@",
                Level = 5,
                Contact = "0972768003",
                Note = ""
            };
            _userService.UpdateUser(updateValue2, updateValue3);
            emInfo = _userService.GetUser(emId);
            Assert.AreEqual(emInfo.FullName, updateValue3.FullName);
            Assert.AreEqual(emInfo.Email, updateValue3.Email);
            Assert.AreEqual(emInfo.Password, updateValue3.Password);
            Assert.AreEqual(emInfo.Level, updateValue3.Level);
            Assert.AreEqual(emInfo.Contact, updateValue3.Contact);
            Assert.AreEqual(emInfo.Note, updateValue3.Note);

            // Update Contact only

            Employee updateValue4 = new Employee()
            {
                EmpId = emId,
                FullName = "xcbv",
                Email = "dhongnhung@tam.com,vn",
                Password = "Lmnbvcxz1@",
                Level = 5,
                Contact = "0349554433",
                Note = ""
            };
            _userService.UpdateUser(updateValue3, updateValue4);
            emInfo = _userService.GetUser(emId);
            Assert.AreEqual(emInfo.FullName, updateValue4.FullName);
            Assert.AreEqual(emInfo.Email, updateValue4.Email);
            Assert.AreEqual(emInfo.Password, updateValue4.Password);
            Assert.AreEqual(emInfo.Level, updateValue4.Level);
            Assert.AreEqual(emInfo.Contact, updateValue4.Contact);
            Assert.AreEqual(emInfo.Note, updateValue4.Note);

            // Update Note only

            Employee updateValue5 = new Employee()
            {
                EmpId = emId,
                FullName = "xcbv",
                Email = "Bi123@5675gmailetiis.com",
                Password = "Lmnbvcxz1@",
                Level = 5,
                Contact = "0349554433",
                Note = "This is testing for User Service NUnit"
            };
            _userService.UpdateUser(updateValue4, updateValue5);
            emInfo = _userService.GetUser(emId);
            Assert.AreEqual(emInfo.FullName, updateValue5.FullName);
            Assert.AreEqual(emInfo.Email, updateValue5.Email);
            Assert.AreEqual(emInfo.Password, updateValue5.Password);
            Assert.AreEqual(emInfo.Level, updateValue5.Level);
            Assert.AreEqual(emInfo.Contact, updateValue5.Contact);
            Assert.AreEqual(emInfo.Note, updateValue5.Note);

            // Update all value

            Employee updateValue6 = new Employee()
            {
                EmpId = emId,
                FullName = "test",
                Email = "dhongnhung@tma.com.vn",
                Password = "123456789",
                Level = 3,
                Contact = "+84355355546",
                Note = "Update all values"
            };
            _userService.UpdateUser(updateValue4, updateValue6);
            emInfo = _userService.GetUser(emId);
            Assert.AreEqual(emInfo.FullName, updateValue6.FullName);
            Assert.AreEqual(emInfo.Email, updateValue6.Email);
            Assert.AreEqual(emInfo.Password, updateValue6.Password);
            Assert.AreEqual(emInfo.Level, updateValue6.Level);
            Assert.AreEqual(emInfo.Contact, updateValue6.Contact);
            Assert.AreEqual(emInfo.Note, updateValue6.Note);
        }
        [Test]
        public void TestDeleteUser()
        {
            Employee newEmployee = new Employee()
            {
                FullName = "Vina Tissue",
                Email = "vinatissue@gmail.com",
                Password = "Lmnbvcxz1@",
                Level = 2,
                Contact = "0972768003",
                Note = "testing"
            };
            Employee employee = _userService.CreateUser(newEmployee);
            int emId = employee.EmpId;

        }
        [Test]
        public void TestGenerateJwtToken()
        {
            Employee newEmployee = new Employee()
            {
                FullName = "Test Generate Jwt Token",
                Email = "token@gmail.com",
                Password = "1122334455",
                Level = 3,
                Contact = "04686851",
                Note = "NUnit testing for generate Jwt Token"
            };
            Employee employee = _userService.CreateUser(newEmployee);
            int emId = employee.EmpId;
        }
    }
}
