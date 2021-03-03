using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TInvoiceWeb.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ShortExpiration { get; set; }
        public int LongExpiration { get; set; }
        public int MaxLimit { get; set; }
    }
}
