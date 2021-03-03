using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TInvoiceForm.Database.Data;

namespace TInvoiceForm.Database
{
    public class TmaBankRepository : Repository<TmaBank>
    {
        public TmaBankRepository(DbContext db) : base(db)
        {
        }
    }
}
