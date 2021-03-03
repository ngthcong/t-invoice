using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TInvoiceForm.Database.Data;

namespace TInvoiceForm.Database
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(DbContext db) : base(db)
        {
        }
    }
}
