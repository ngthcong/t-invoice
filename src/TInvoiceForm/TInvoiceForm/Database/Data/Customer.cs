using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TInvoiceForm.Database.Data
{
    public class Customer
    {
        [Key]
        public int CusId { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Customer name is required")]
        public string Fullname { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Customer email is required"), EmailAddress(ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [MaxLength(255)]
        [Required(ErrorMessage = "Customer address is required")]
        public string Address { get; set; }

        [MaxLength(15)]
        [Required(ErrorMessage = "Customer contact is required")]
        public string Contact { get; set; }

        public string Note { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
