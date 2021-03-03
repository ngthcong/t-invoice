using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TInvoiceWeb.Data
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        [MaxLength(255)]
        public string PONumber { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Total { get; set; }
        public double InvoiceBillable {get;set;}
        [MaxLength(255)]
        public string SharedServiceType { get; set; }
        [MaxLength(255)]
        public string SharedServiceBillables { get; set; }
        [MaxLength(255)]
        public string ShareServiceLaborCost { get; set; }
        public double OfDCBillables { get; set; }
        public double DCOffshoreLaborCost { get; set; }
        public double CurrentRate { get; set; }
        public double InvoicedOffshoreLaborCost { get; set; }
        public double OnsiteCost { get; set; }
        [MaxLength(255)]
        public string TaxAndEquipment { get; set; }
        [MaxLength(255)]
        public string GST { get; set; }
        [MaxLength(255)]
        public string OtherCost { get; set; }
        [MaxLength(255)]
        public string Currency { get; set; }
        [MaxLength(255)]
        public string InvoicedAmount { get; set; }
        public string ReceivedAmount { get; set; }
        public DateTime ReceivedDate { get; set; }
        [MaxLength(255)]
        public string BankOfPayment { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
        [MaxLength(255)]
        public string Sender { get; set; }
        public string Status { get; set; }
        [MaxLength(255)]
        public string LatestEffectiveDay { get; set; }
        public DateTime ExpireDate { get; set; }
        [MaxLength(255)]
        public string ReminderDate { get; set; }
        public int EmpId { get; set; }
        public int ProjectId { get; set; }
        public int TmaBankId { get; set; }
        public string Note { get;set; }
        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }
        [ForeignKey("TmaBankId")]
        public virtual TmaBank TmaBank { get; set; }
    }
}
