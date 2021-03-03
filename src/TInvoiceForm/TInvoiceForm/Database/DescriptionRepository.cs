using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TInvoiceForm.Database.Data;

namespace TInvoiceForm.Database
{
    public class DescriptionRepository : Repository<Description>
    {
        public DescriptionRepository(DbContext db) : base(db)
        {
        }
    }
}
