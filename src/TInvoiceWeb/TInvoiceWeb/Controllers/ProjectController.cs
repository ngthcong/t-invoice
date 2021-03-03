using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces.Service;

namespace TInvoiceWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProjectService _projectService;

        public ProjectController(IWebHostEnvironment webHostEnvironment, IProjectService projectService)
        {
            _webHostEnvironment = webHostEnvironment;
            _projectService = projectService;
        }

        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            Project res = _projectService.CreateProject(project);
            if (res == null)
                return BadRequest(new { message = "Something wrong, please try again later" });
            return Ok(res);
        }
        [HttpGet("{projectId}")]
        public ActionResult GetProject(int projectId)
        {
            Project res = _projectService.GetProject(projectId);
            if (res == null)
                return BadRequest(new { message = "Project not found" });
            return Ok(res);
        }
        [HttpDelete("{projectId}")]
        public ActionResult DeleteProject(int projectId)
        {
            var res = _projectService.DeleteProject(projectId);
            if (res == false)
                return BadRequest(new { message = "Project not found" });
            return Ok(new { message = "Project deleted" });
        }
        [HttpPut]
        public ActionResult UpdateProject(Project project)
        {
            Project res = _projectService.UpdateProject(project);
            if (res == null)
                return BadRequest(new { message = "Project not found" });
            return Ok(res);
        }
    }
}
