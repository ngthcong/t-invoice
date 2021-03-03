using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TInvoiceForm.Database.Data;

namespace TInvoiceForm.Database
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(DbContext db) : base(db)
        {
        }
    }
}
