using System.Linq;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;

namespace TInvoiceWeb.Repositories
{
    public class BankRepository :IBankRepository
    {
        private readonly TInvoiceDBContext _context;

        public BankRepository(TInvoiceDBContext invoiceDBContext)
        {
            _context = invoiceDBContext;
        }
        public void DeleteTMABank(TmaBank tmabank)
        {
            _context.TmaBanks.Remove(tmabank);
        }

        public void CreateTMABank(TmaBank tmabank)
        {
            _context.TmaBanks.Add(tmabank);
        }


        public TmaBank GetTMABank(int bankid)
        {
            return _context.TmaBanks.Where(x => x.BankId == bankid).FirstOrDefault();
        }




        public void UpdateTMABank(TmaBank tmabank)
        {
            _context.Update(tmabank);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
