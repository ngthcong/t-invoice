using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;
using TInvoiceWeb.Helpers;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Models;
using TInvoiceWeb.Responses;

namespace TInvoiceWeb.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _repo;

        public InvoiceService(IInvoiceRepository repository)
        {
            _repo = repository;
            
        }
        public Invoice CreateInvoice(Invoice invoice)
        {
            _repo.CreateInvoice(invoice);
            _repo.SaveChanges();
            return invoice;
        }

        public bool DeleteInvoice(int invId)
        {
           var invoice = _repo.GetInvoice(invId);
            if(invoice == null)
            {
                return false;
            }
            _repo.DeleteInvoice(invoice);
            _repo.SaveChanges();
            return true;
        }

        public void GenerateMonthlyExcel(int year, int month, string path)
        {
           List<ExcelModel> model =  _repo.CreateExcel(year, month);
            ExcelGenerator.CreateExcelFile(model, path);
        }
        
        
        public Invoice GetInvoice(int invId)
        {
            var invoice = _repo.GetInvoice(invId);
            if(invoice == null)
            {
                return  null;
            }
            return  invoice;
        }

        public Invoice UpdateInvoice(Invoice invoice)
        {
            var Invoice = _repo.GetInvoice(invoice.InvoiceId);
            if(Invoice == null)
            {
                return null;
            }
            Invoice.PONumber = invoice.PONumber;
            Invoice.InvoiceNumber = invoice.InvoiceNumber;
            Invoice.InvoiceDate = invoice.InvoiceDate;
            Invoice.InvoiceBillable = invoice.InvoiceBillable;
            Invoice.SharedServiceBillables = invoice.SharedServiceBillables;
            Invoice.ShareServiceLaborCost = invoice.ShareServiceLaborCost;
            Invoice.OfDCBillables = invoice.OfDCBillables;
            Invoice.CurrentRate = invoice.CurrentRate;
            Invoice.DCOffshoreLaborCost = invoice.DCOffshoreLaborCost;
            Invoice.InvoicedOffshoreLaborCost = invoice.InvoicedOffshoreLaborCost;
            Invoice.OnsiteCost = invoice.OnsiteCost;
            Invoice.TaxAndEquipment = invoice.TaxAndEquipment;
            Invoice.GST = invoice.GST;
            Invoice.Currency = invoice.Currency;
            Invoice.OtherCost = invoice.OtherCost;
            Invoice.InvoicedAmount = invoice.InvoicedAmount;
            Invoice.ReceivedAmount = invoice.ReceivedAmount;
            Invoice.ReceivedDate = invoice.ReceivedDate;
            Invoice.BankOfPayment = invoice.BankOfPayment;
            Invoice.Description = invoice.Description;
            Invoice.Sender = invoice.Sender;
            Invoice.Status = invoice.Status;
            Invoice.LatestEffectiveDay = invoice.LatestEffectiveDay;
            Invoice.ExpireDate = invoice.ExpireDate;
            Invoice.ReminderDate = invoice.ReminderDate;
            Invoice.EmpId = invoice.EmpId;
            Invoice.ProjectId = invoice.ProjectId;
            Invoice.TmaBankId = invoice.TmaBankId;
            Invoice.Note = invoice.Note;
            
            _repo.UpdateInvoice(Invoice);
            _repo.SaveChanges();
            return Invoice;
        }
    }
}
