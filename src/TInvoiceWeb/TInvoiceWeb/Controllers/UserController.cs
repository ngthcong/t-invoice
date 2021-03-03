using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TInvoiceWeb.Data;
using TInvoiceWeb.Helpers;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Models;

namespace TInvoiceWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        public UserController(IUserService userService, IRoleService roleService, ILogger<UserController> logger)
        {
            _userService = userService;
            _roleService = roleService;
            _logger = logger;
        }

        [HttpGet("{id}/role")]
        [Authorize]
        public ActionResult GetUserRole(int id)
        {
            _logger.LogDebug("User request user role: " + id);
            int res = _roleService.GetUserRole(id);
            return Ok(res);
        }

        [HttpPost]
        [Authorize]
        public ActionResult CreateUser(Employee employee)
        {
            if (_userService.CheckUserEmail(employee.Email))
                return Conflict(new { message = "Email already exist" });
            Employee res = _userService.CreateUser(employee);
            return Ok(res);
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetAllUser([FromQuery] int offset, [FromQuery] int limit)
        {
            if (offset < 0 || limit <= 0)
                return NoContent();
            var res = _userService.GetAllUsers(offset, limit);
            return Ok(res);

        }
        [HttpGet("{id}")]
        [Authorize]
        public ActionResult GetUser(int id)
        {
            Employee res = _userService.GetUser(id);
            if (res == null)
                return NotFound();
            return Ok(res);
        }
        [HttpDelete("{id}")]
        [Authorize]
        public ActionResult DeleteUser(int id)
        {
            Employee emp = _userService.GetUser(id);
            if (emp == null)
                return NotFound();
            _userService.DeleteUser(emp);
            return NoContent();
        }
        [HttpPut]
        [Authorize]
        public ActionResult UpdateUser(Employee newEmployee)
        {
            Employee oldEmployee = _userService.GetUser(newEmployee.EmpId);
            if (oldEmployee == null)
                return NotFound();
            if (oldEmployee.Email != newEmployee.Email && _userService.CheckUserEmail(newEmployee.Email, newEmployee.EmpId))
                return Conflict();
            _userService.UpdateUser(newEmployee, oldEmployee);
            return Ok();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            Employee emp = _userService.GetUserByEmail(model.Email);
            if (emp == null)
                return Unauthorized();
            if (!_userService.CheckPassword(emp.Password, model.Password, emp.Salt))
                return Unauthorized();
            var response = _userService.Authenticate(emp.EmpId, emp.Level, model.Remember);
            return Ok(new {access_token = response });
        }

    }
}
