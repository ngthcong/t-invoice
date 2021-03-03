using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using NUnit.Framework;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Repositories;
using TInvoiceWeb.Services;

namespace TInvoiceNUnitTesting.ServicesNUnit
{
    class InvoiceServiceNUnit
    {
        private IInvoiceService _invoiceService;
        private TInvoiceDBContext _context;
        [SetUp]
        public void Setup()
        {

            //customerRepository = new Mock<ICustomerRepository>();
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var optionsBuilder = new DbContextOptionsBuilder<TInvoiceDBContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            _context = new TInvoiceDBContext(optionsBuilder.Options);
            _invoiceService = new InvoiceService(new InvoiceRepository(_context));

        }
        [Test] 
        public void TestCreateInvoice()
        {
            Invoice newInVoice = new Invoice()
            {
                PONumber = "001",
                InvoiceNumber = "123456987",
                InvoiceDate = DateTime.Parse("01/01/2020 00:00:00 AM"),
                Total = double.Parse("25.5"),
                InvoiceBillable = double.Parse("50.5"),
                SharedServiceType = "SharedServiceType",
                SharedServiceBillables = "SharedServiceBilldables",
                ShareServiceLaborCost = "ShareServiceLaborCost",
                OfDCBillables = double.Parse("32.5"),
                DCOffshoreLaborCost = double.Parse("10.2"),
                CurrentRate = double.Parse("36.5"),
                InvoicedOffshoreLaborCost = double.Parse("63.5"),
                OnsiteCost = double.Parse("52.01"),
                TaxAndEquipment = "TaxAndEquipment",
                GST = "GST",
                OtherCost = "OtherCost",
                Currency = "Currency",
                InvoicedAmount = "InvoicedAmount",
                ReceivedAmount = "ReceivedAmount",
                ReceivedDate = DateTime.Parse("05/06/2020 12:30:11 AM"),
                BankOfPayment = "Sacombank",
                Description = "Description",
                Sender = "Sender",
                Status = "Status",
                LatestEffectiveDay = "LatestEffectiveDay",
                ExpireDate = DateTime.Parse("08/07/2020 12:30:11 AM"),
                ReminderDate = "ReminderDate",
                EmpId = int.Parse("1"),
                ProjectId = int.Parse("1"),
                TmaBankId = int.Parse("1"),
                //Note = "Nothing"
            };
            Invoice inVoice = _invoiceService.CreateInvoice(newInVoice);
        }
    }
}
