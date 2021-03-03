using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TInvoiceWeb.Models
{
    public class ExcelModel
    {
        public int InvoiceId { get; set; }
        public string FullName { get; set; }
        public string ProjectName { get; set; }
        public string PONumber { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public double Total { get; set; }
        public double InvoiceBillable { get; set; }
        
        public string SharedServiceType { get; set; }
        
        public string SharedServiceBillables { get; set; }
        
        public string ShareServiceLaborCost { get; set; }
        public double OfDCBillables { get; set; }
        public double DCOffshoreLaborCost { get; set; }
        public double CurrentRate { get; set; }
        public double InvoicedOffshoreLaborCost { get; set; }
        public double OnsiteCost { get; set; }
        
        public string TaxAndEquipment { get; set; }
        
        public string GST { get; set; }
        
        public string OtherCost { get; set; }
        
        public string Currency { get; set; }
        
        public string InvoicedAmount { get; set; }
        public string ReceivedAmount { get; set; }
        public DateTime ReceivedDate { get; set; }
        
        public string BankOfPayment { get; set; }
        
        public string Description { get; set; }
        
        public string Sender { get; set; }
        public string Status { get; set; }
        
        public string LatestEffectiveDay { get; set; }
        public DateTime ExpireDate { get; set; }
        
        public string ReminderDate { get; set; }
    }
}
