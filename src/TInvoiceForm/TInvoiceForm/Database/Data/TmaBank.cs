using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TInvoiceForm.Database.Data
{
    public class TmaBank
    {
        [Key]
        public int BankId { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "Account name is required")]
        public string AccountName { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "Account number is required")]
        public string AccountNumber { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "Bank name is required")]
        public string BankName { get; set; }
        public string Note { get; set; }

        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
