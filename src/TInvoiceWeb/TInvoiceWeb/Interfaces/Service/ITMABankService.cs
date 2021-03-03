using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;

namespace TInvoiceWeb.Interfaces
{
    public interface ITMABankService
    {
        TmaBank GetTmaBank(int bankid);
        TmaBank CreateTmaBank(TmaBank tmaBank);
        bool DeleteTmaBank(int bankid);
        TmaBank UpdateTmaBank(TmaBank tmaBank);
       
    }
}
