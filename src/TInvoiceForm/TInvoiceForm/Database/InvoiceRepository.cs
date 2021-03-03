using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TInvoiceForm.Database.Data;

namespace TInvoiceForm.Database
{
    public class InvoiceRepository : Repository<Invoice>
    {
        public InvoiceRepository(DbContext db) : base(db)
        {
        }
    }
}
