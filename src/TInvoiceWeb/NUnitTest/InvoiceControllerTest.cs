using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using TInvoiceWeb.Controllers;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;

namespace NUnitTest
{
    public class InvoiceControllerTest
    {
        private Mock<IInvoiceService> _inVoiceMock;
        private Mock<IInvoiceRepository> _inVoiceRepositoryMock;
        private InvoiceController InvoiceController;

        [SetUp]
        public void SetUp()
        {
            _inVoiceMock = new Mock<IInvoiceService>();
            _inVoiceRepositoryMock = new Mock<IInvoiceRepository>();
            InvoiceController = new InvoiceController(_inVoiceMock.Object);
        }

        [Test]
        public void GetInvoiceTest()
        {
            Invoice invoice = new Invoice()
            {
                InvoiceId = 1
            };
            _inVoiceMock.Setup(i => i.GetInvoice(1)).Returns(invoice);
            var result = InvoiceController.GetInvoice(1);
            var OkResult = (ObjectResult)result;
            _inVoiceMock.Verify(i => i.GetInvoice(1), Times.Once());
            Assert.AreEqual(200, OkResult.StatusCode);
        }

        [Test]
        public void CreateInvoiceTest()
        {
            Invoice invoice = new Invoice()
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
                Note = "Nothing"
            };

            _inVoiceMock.Setup(i => i.CreateInvoice(invoice)).Returns(invoice);
            var result = InvoiceController.CreateInvoice(invoice);
            var OkResult = (ObjectResult)result;
            _inVoiceMock.Verify(i => i.CreateInvoice(invoice), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual(200, OkResult.StatusCode);
        }

        [Test]
        public void ModifyInvoiceTest()
        {
            Invoice invoice = new Invoice()
            {
                PONumber = "111",
                InvoiceNumber = "1234561237",
                InvoiceDate = DateTime.Parse("11/11/2020 12:32:00 AM"),
                Total = double.Parse("26.5"),
                InvoiceBillable = double.Parse("56.5"),
                SharedServiceType = "SharedServiceType6",
                SharedServiceBillables = "SharedServiceBilldables6",
                ShareServiceLaborCost = "ShareServiceLaborCost6",
                OfDCBillables = double.Parse("36.5"),
                DCOffshoreLaborCost = double.Parse("16.2"),
                CurrentRate = double.Parse("36.5"),
                InvoicedOffshoreLaborCost = double.Parse("66.5"),
                OnsiteCost = double.Parse("56.01"),
                TaxAndEquipment = "TaxAndEquipment6",
                GST = "GST6",
                OtherCost = "OtherCost6",
                Currency = "Currency6",
                InvoicedAmount = "InvoicedAmount6",
                ReceivedAmount = "ReceivedAmount6",
                ReceivedDate = DateTime.Parse("05/06/2020 12:30:11 AM"),
                BankOfPayment = "Sacombank6",
                Description = "Description6",
                Sender = "Sender6",
                Status = "Status6",
                LatestEffectiveDay = "LatestEffectiveDay6",
                ExpireDate = DateTime.Parse("09/09/2020 12:30:11 AM"),
                ReminderDate = "ReminderDate6",
                EmpId = int.Parse("1"),
                ProjectId = int.Parse("1"),
                TmaBankId = int.Parse("1"),
                Note = "Nothing"
            };

            _inVoiceMock.Setup(i => i.UpdateInvoice(invoice)).Returns(invoice);
            var result = InvoiceController.ModifyInvoice(invoice);
            var okResult = (ObjectResult)result;
            _inVoiceMock.Verify(i => i.UpdateInvoice(invoice), Times.Once());
            Assert.IsNotNull(result);
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void DeleteInvoiceTest()
        {
            _inVoiceMock.Setup(i => i.DeleteInvoice(1)).Returns(true);
            var result = InvoiceController.DeleteInvoice(1);
            var OkResult = (ObjectResult)result;
            _inVoiceMock.Verify(i => i.DeleteInvoice(1), Times.Once());
            Assert.AreEqual(200, OkResult.StatusCode);
        }

        [Test]
        public void ReportInvoiceTest()
        {
            _inVoiceMock.Setup(i => i.GenerateMonthlyExcel(2020, 09, "Report"));
            var result = InvoiceController.Report(2020, 09, "Report");
            _inVoiceMock.Verify(i => i.GenerateMonthlyExcel(2020, 09, "Report"), Times.Once());
            Assert.AreEqual(200, ((StatusCodeResult)result).StatusCode);
        }
    }
}
