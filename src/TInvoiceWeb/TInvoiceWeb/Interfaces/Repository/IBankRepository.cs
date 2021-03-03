using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;

namespace TInvoiceWeb.Interfaces
{
    public interface IBankRepository
    {
        TmaBank GetTMABank(int bankid);
        void CreateTMABank(TmaBank tmabank);
        void DeleteTMABank(TmaBank tmabank);
        void UpdateTMABank(TmaBank tmabank);
        void SaveChanges();
    }
}
