using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Services;

namespace TInvoiceWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TMABankController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ITMABankService _tmaBankService;

        public TMABankController(IWebHostEnvironment webHostEnvironment, ITMABankService tmaBankservice)
        {
            _webHostEnvironment = webHostEnvironment;
            _tmaBankService = tmaBankservice;
        }

        [HttpPost]
        public ActionResult CreateTMABank(TmaBank tmaBank)
        {
            TmaBank res = _tmaBankService.CreateTmaBank(tmaBank);
            if (res == null)
                return BadRequest(new { message = "Bank not created" });
            return Ok(res);
        }
        [HttpGet("{bankId}")]
        public ActionResult GetTMABank(int bankId)
        {
            TmaBank res = _tmaBankService.GetTmaBank(bankId);
            if (res == null)
                return BadRequest(new { message = "Bank not found" });
            return Ok(res);
        }
        [HttpDelete("{bankId}")]
        public ActionResult DeleteTMABank(int bankId)
        {
            var res = _tmaBankService.DeleteTmaBank(bankId);
            if (res == false)
                return BadRequest(new { message = "Bank not found" });

            return Ok(new { message = "Bank deleted" });
        }
        [HttpPut]
        public ActionResult UpdateTMABank(TmaBank tmaBank)
        {
            TmaBank res = _tmaBankService.UpdateTmaBank(tmaBank);
            if (res == null)
                return BadRequest(new { message = "Bank not found" });
            return Ok(res);
        }
    }
}
