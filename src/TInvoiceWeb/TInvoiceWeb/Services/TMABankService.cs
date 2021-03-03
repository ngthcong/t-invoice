using Microsoft.AspNetCore.Mvc.Formatters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;

namespace TInvoiceWeb.Services
{
    public class TMABankService : ITMABankService
    {
        private readonly IBankRepository _repository;

        public TMABankService(IBankRepository repository)
        {
            _repository = repository;
        }

        public TmaBank CreateTmaBank(TmaBank tmaBank)
        {
            _repository.CreateTMABank(tmaBank);
            _repository.SaveChanges();
            return tmaBank;
        }

        public bool DeleteTmaBank(int bankid)
        {
            var tma = _repository.GetTMABank(bankid);
            if (null == tma)
            {
                return false;
            }
            else
            {
                _repository.DeleteTMABank(tma);
                _repository.SaveChanges();
            }
            return true;
        }

        public TmaBank GetTmaBank(int bankid)
        {
            var tma = _repository.GetTMABank(bankid);
            if (null == tma)
            {
                return null;
            }
            return tma;
        }

        public TmaBank UpdateTmaBank(TmaBank tmaBank)
        {
            _repository.UpdateTMABank(tmaBank);
            _repository.SaveChanges();
            return tmaBank;
        }
    }
}
