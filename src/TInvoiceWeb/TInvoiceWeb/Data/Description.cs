using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TInvoiceWeb.Data
{
    public class Description
    {
        [Key]
        public int DesId { get; set; }
        public int ItemNumber { get; set; }
        [MaxLength(255)]
        public string Des { get; set; }
        public double PaymentAmount { get; set; }
        public int InvoiceId { get; set; }
        public string Note { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
    }
}
