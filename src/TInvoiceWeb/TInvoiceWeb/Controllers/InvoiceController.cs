using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;

namespace TInvoiceWeb.Controllers
{
    [Route("api/[controller]")]

    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService _invoiceService;

        public InvoiceController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }
        [HttpGet("{invId}")]
        public ActionResult GetInvoice(int invId)
        {
            return Ok(_invoiceService.GetInvoice(invId));
        }
        [HttpDelete("{invId}")]
        public ActionResult DeleteInvoice(int invId)
        {
            return Ok(_invoiceService.DeleteInvoice(invId));
        }
        [HttpPost]
        public ActionResult CreateInvoice(Invoice invoice)
        {
            return Ok(_invoiceService.CreateInvoice(invoice));
        }
        [HttpPut]
        public ActionResult ModifyInvoice(Invoice invoice)
        {
            return Ok(_invoiceService.UpdateInvoice(invoice));
        }
        [HttpPost("report")]
        public ActionResult Report(int year, int month, string path)
        {
            _invoiceService.GenerateMonthlyExcel(year,month,path);
            return Ok(new { message = "Report created at Storage\\" +path });
        }


    }
}
