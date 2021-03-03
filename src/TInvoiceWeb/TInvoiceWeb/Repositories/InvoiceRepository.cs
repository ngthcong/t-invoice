using System;
using System.Collections.Generic;
using System.Linq;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Models;

namespace TInvoiceWeb.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly TInvoiceDBContext _context;

        public InvoiceRepository(TInvoiceDBContext invoiceDBContext)
        {
            _context = invoiceDBContext;
        }
        public void CreateInvoice(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
        }
        public void CreateDescription(Description description)
        {
            _context.Descriptions.Add(description);
        }

        public Invoice GetInvoice(int invId)
        {
            return _context.Invoices.Where(i => i.InvoiceId == invId).SingleOrDefault();
        }
        public void UpdateInvoice(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
        }


        public void DeleteInvoice(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public List<ExcelModel> CreateExcel(int year, int month)
        {
            var firstDayOfMonth = new DateTime(year, month, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddTicks(-1);
            var form = from i in _context.Invoices
                       join e in _context.Employees on i.EmpId equals e.EmpId
                       join p in _context.Projects on i.ProjectId equals p.ProjectId
                       join c in _context.Customers on p.CusId equals c.CusId
                       where i.InvoiceDate < lastDayOfMonth &&
                                i.InvoiceDate > firstDayOfMonth
                       select new ExcelModel()
                       {
                           InvoiceId = i.InvoiceId,
                           FullName = c.Fullname,
                           ProjectName = p.ProjectName,
                           InvoiceNumber = i.InvoiceNumber,
                           PONumber = i.PONumber,
                           InvoiceDate = i.InvoiceDate,
                           InvoiceBillable = i.InvoiceBillable,
                           SharedServiceType = i.SharedServiceType,
                           SharedServiceBillables = i.SharedServiceBillables,
                           ShareServiceLaborCost = i.ShareServiceLaborCost,
                           OfDCBillables = i.OfDCBillables,
                           DCOffshoreLaborCost = i.DCOffshoreLaborCost,
                           CurrentRate = i.CurrentRate,
                           InvoicedOffshoreLaborCost = i.InvoicedOffshoreLaborCost,
                           OnsiteCost = i.OnsiteCost,
                           TaxAndEquipment = i.TaxAndEquipment,
                           GST = i.GST,
                           OtherCost = i.OtherCost,
                           Currency = i.Currency,
                           ReceivedAmount = i.ReceivedAmount,
                           InvoicedAmount = i.InvoicedAmount,
                           ReceivedDate = i.ReceivedDate,
                           BankOfPayment = i.BankOfPayment,
                           Description = i.Description,
                           Sender = i.Sender,
                           Status = i.Status,
                           LatestEffectiveDay = i.LatestEffectiveDay,
                           ExpireDate = i.ExpireDate,
                           ReminderDate = i.ReminderDate
                       };
            return form.ToList();
        }
    }
}
