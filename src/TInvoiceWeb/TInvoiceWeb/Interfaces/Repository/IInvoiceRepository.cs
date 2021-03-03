using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;
using TInvoiceWeb.Models;

namespace TInvoiceWeb.Interfaces
{
    public interface IInvoiceRepository
    {
        void CreateInvoice(Invoice invoice);

        void UpdateInvoice(Invoice invoice);

        void DeleteInvoice(Invoice invoice);
        Invoice GetInvoice(int invId);

        List<ExcelModel> CreateExcel(int year, int month);

        void SaveChanges();
    }
}
