using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TInvoiceForm.Database.Data;

namespace TInvoiceForm.Database
{
    public class ProjectRepository : Repository<Project>
    {
        public ProjectRepository(DbContext db) : base(db)
        {
        }
    }
}
