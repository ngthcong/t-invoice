using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;

namespace TInvoiceWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private const string IS_EMAIL_EXIST = " already exists. Choose a different email name";

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public ActionResult GetAllCustomer([FromQuery] int offset, [FromQuery] int? limit = null)
        {
            ICollection<Customer> res = _customerService.GetAllCustomer(offset, limit);
            if (res.Count == 0)
                return NoContent();
            return Ok(res);
        }

        [HttpGet("{cusid}")]
        public ActionResult GetCustomer(int cusid)
        {
            Customer res = _customerService.GetCustomer(cusid);
            if (res == null)
                return NotFound();
            return Ok(res);
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            bool checkEmail = _customerService.IsEmailExist(customer.Email);
            if (checkEmail)
                return Conflict(new { message = customer.Email + IS_EMAIL_EXIST});
            try
            {
                Customer res = _customerService.CreateCustomer(customer);
                return Ok(res);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{cusid}")]
        public ActionResult DeleteUser(int cusid)
        {
            var cus = _customerService.GetCustomer(cusid);
            if (cus == null)
                return NotFound();
            try
            {
                _customerService.DeleteCustomer(cusid);
                return Ok(new { message = "Customer deleted!" });
            }
            catch (DbUpdateException)
            {
                return StatusCode(500);
            }
            catch (DBConcurrencyException)
            {
                return NotFound();
            }
        }
        [HttpPut]
        public ActionResult UpdateUser(Customer newCustomer)
        {
            var oldCustomer = _customerService.GetCustomer(newCustomer.CusId);

            if (oldCustomer == null)
            {
                return NotFound();
            }

            if (newCustomer.Email != oldCustomer.Email)
            {
                bool cusEmail = _customerService.IsEmailExist(newCustomer.Email);

                if (cusEmail)
                    return Conflict(new { message = newCustomer.Email + IS_EMAIL_EXIST});
            }
            try
            {
                Customer res = _customerService.UpdateCustomer(oldCustomer, newCustomer);
                return Ok(res);
            }
            catch(DbUpdateException)
            {
                return StatusCode(500);
            }
            catch (DBConcurrencyException)
            {
                return NotFound();
            }
        }
    }
}
