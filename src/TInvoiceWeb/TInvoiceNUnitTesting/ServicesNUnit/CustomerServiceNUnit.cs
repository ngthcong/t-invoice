using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using TInvoiceWeb.Services;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Repositories;
using Moq;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using DocumentFormat.OpenXml.InkML;
using System.Linq;

namespace TInvoiceNUnitTesting.ServicesNUnit
{
    class CustomerServiceNUnit
    {
        private ICustomerService _customerService;
        private TInvoiceDBContext _context;
        private int customerID = -1;
        [SetUp]
        public void Setup()
        {

            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<TInvoiceDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            _context = new TInvoiceDBContext(optionsBuilder.Options);

            _customerService = new CustomerService(new CustomerRepository(_context));

        }
        [TearDown]
        public void ClearAll()
        {
            if (customerID > 0)
            {
                bool delCus = _customerService.DeleteCustomer(customerID);
                Assert.IsTrue(delCus);
                customerID = -1;
            }

        }

        [Test]
        public void TestCreateCustomer()
        {
            Customer value = new Customer()
            {
                Address = "house",
                Fullname = "Jack Mart",
                Contact = "+045678",
                Email = "Jack@gmail.com",
                Note = "This is testing for NUnit"
            };
            Customer cus = _customerService.CreateCustomer(value);
            int cusId = cus.CusId;
            customerID = cusId;
            Customer getCus = _customerService.GetCustomer(cusId);
            Assert.AreEqual(value.Address, getCus.Address);
            Assert.AreEqual(value.Fullname, getCus.Fullname);
            Assert.AreEqual(value.Contact, getCus.Contact);
            Assert.AreEqual(value.Email, getCus.Email);
            Assert.AreEqual(value.Note, getCus.Note);
        }
        [Test]
        public void TestDeleteCustomer()
        {
            Customer value = new Customer()
            {
                Address = "Champ de Mars, 5 Avenue Anatole France, 75007 Paris",
                Fullname = "Marrie",
                Contact = "+567654321",
                Email = "MarrieLi@gmail.com",
                Note = "2 quaterly"
            };
            //Delete created user
            Customer cus = _customerService.CreateCustomer(value);
            int cusId = cus.CusId;
            bool delCus = _customerService.DeleteCustomer(cusId);
            Assert.IsTrue(delCus);

            //Verify value is deleted
            Customer getCus = _customerService.GetCustomer(cusId);
            Assert.IsNull(getCus);

            //Delete invalid user
            delCus = _customerService.DeleteCustomer(cusId);
            Assert.IsFalse(delCus);
        }
        [Test]
        public void TestUpdateCustomer()
        {
            Customer value = new Customer()
            {
                Address = "1450 Pennsylvania Avenue",
                Fullname = "John",
                Contact = "+467215",
                Email = "John@gmail.com",
                Note = ""
            };
            Customer cus = _customerService.CreateCustomer(value);
            int cusId = cus.CusId;
            customerID = cusId;

            //Update Address only
            Customer updateValue = new Customer()
            {
                CusId = cusId,
                Address = "2 Phra Chan Alley, Phra Borom Maha Ratchawang, Phra Nakhon, Bangkok",
                Fullname = "John",
                Contact = "+467215",
                Email = "Bi@gmail.com",
                Note = ""
            };
            Customer upDate = _customerService.UpdateCustomer(value, updateValue);
            Customer getCus = _customerService.GetCustomer(cusId);
            Assert.AreEqual(updateValue.Address, getCus.Address);
            Assert.AreEqual(updateValue.Fullname, getCus.Fullname);
            Assert.AreEqual(updateValue.Contact, getCus.Contact);
            Assert.AreEqual(updateValue.Email, getCus.Email);
            Assert.AreEqual(updateValue.Note, getCus.Note);

            //Update Fullname only
            Customer updateValue1 = new Customer()
            {
                CusId = cusId,
                Address = "2 Phra Chan Alley, Phra Borom Maha Ratchawang, Phra Nakhon, Bangkok",
                Fullname = "Nhung",
                Contact = "+467215",
                Email = "Nhung@gmail.com",
                Note = ""
            };
            Customer upDate1 = _customerService.UpdateCustomer(upDate, updateValue1);
            getCus = _customerService.GetCustomer(cusId);
            Assert.AreEqual(updateValue1.Address, getCus.Address);
            Assert.AreEqual(updateValue1.Fullname, getCus.Fullname);
            Assert.AreEqual(updateValue1.Contact, getCus.Contact);
            Assert.AreEqual(updateValue1.Email, getCus.Email);
            Assert.AreEqual(updateValue1.Note, getCus.Note);

            //Update Contact only
            Customer updateValue2 = new Customer()
            {
                CusId = cusId,
                Address = "2 Phra Chan Alley, Phra Borom Maha Ratchawang, Phra Nakhon, Bangkok",
                Fullname = "Nhung",
                Contact = "0349554433",
                Email = "Test@gmail.com",
                Note = ""
            };
            Customer upDate2 = _customerService.UpdateCustomer(upDate1, updateValue2);
            getCus = _customerService.GetCustomer(cusId);
            Assert.AreEqual(updateValue2.Address, getCus.Address);
            Assert.AreEqual(updateValue2.Fullname, getCus.Fullname);
            Assert.AreEqual(updateValue2.Contact, getCus.Contact);
            Assert.AreEqual(updateValue2.Email, getCus.Email);
            Assert.AreEqual(updateValue2.Note, getCus.Note);

            //Update Email only
            Customer updateValue3 = new Customer()
            {
                CusId = cusId,
                Address = "2 Phra Chan Alley, Phra Borom Maha Ratchawang, Phra Nakhon, Bangkok",
                Fullname = "Nhung",
                Contact = "0349554433",
                Email = "dhongnhung@gmail.com",
                Note = ""
            };
            Customer upDate3 = _customerService.UpdateCustomer(upDate2, updateValue3);
            getCus = _customerService.GetCustomer(cusId);
            Assert.AreEqual(updateValue3.Address, getCus.Address);
            Assert.AreEqual(updateValue3.Fullname, getCus.Fullname);
            Assert.AreEqual(updateValue3.Contact, getCus.Contact);
            Assert.AreEqual(updateValue3.Email, getCus.Email);
            Assert.AreEqual(updateValue3.Note, getCus.Note);

            //Update Note only
            Customer updateValue4 = new Customer()
            {
                CusId = cusId,
                Address = "2 Phra Chan Alley, Phra Borom Maha Ratchawang, Phra Nakhon, Bangkok",
                Fullname = "Nhung",
                Contact = "0349554433",
                Email = "abc@gmail.com",
                Note = "This is testing for NUnit."
            };
            Customer upDate4 = _customerService.UpdateCustomer(upDate3, updateValue4);
            getCus = _customerService.GetCustomer(cusId);
            Assert.AreEqual(updateValue4.Address, getCus.Address);
            Assert.AreEqual(updateValue4.Fullname, getCus.Fullname);
            Assert.AreEqual(updateValue4.Contact, getCus.Contact);
            Assert.AreEqual(updateValue4.Email, getCus.Email);
            Assert.AreEqual(updateValue4.Note, getCus.Note);

            //Update all values
            Customer updateValue5 = new Customer()
            {
                CusId = cusId,
                Address = "Kyobashi MID Bldg., 13-10, Kyobashi 2-chome, Chuo-ku, Tokyo",
                Fullname = "Josida",
                Contact = "+3543521",
                Email = "Josida@12345test.com",
                Note = "Impossible is just an opinion."
            };
            Customer upDate5 = _customerService.UpdateCustomer(upDate4, updateValue5);
            getCus = _customerService.GetCustomer(cusId);
            Assert.AreEqual(updateValue5.Address, getCus.Address);
            Assert.AreEqual(updateValue5.Fullname, getCus.Fullname);
            Assert.AreEqual(updateValue5.Contact, getCus.Contact);
            Assert.AreEqual(updateValue5.Email, getCus.Email);
            Assert.AreEqual(updateValue5.Note, getCus.Note);
        }
    }
}
