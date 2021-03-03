using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TInvoiceForm.Database.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required(ErrorMessage = "Project name is required")]
        [MaxLength(255)]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public bool Status { get; set; }
        public int CusId { get; set; }

        public string Note { get; set; }
        [ForeignKey("CusId")]
        public virtual Customer Customer { get; set; }
    }
}
