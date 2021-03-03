using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;
using TInvoiceWeb.Responses;

namespace TInvoiceWeb.Interfaces
{
    public interface IInvoiceService
    {
        Invoice CreateInvoice(Invoice invoice);
        Invoice UpdateInvoice(Invoice invoice);
        bool DeleteInvoice(int invId);
        Invoice GetInvoice(int invId);

        void GenerateMonthlyExcel(int year, int month,string path);

       
    }
}
