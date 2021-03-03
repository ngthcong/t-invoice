using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces.Repository;
using TInvoiceWeb.Interfaces.Service;

namespace TInvoiceWeb.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _repository;

        public ProjectService(IProjectRepository repository)
        {
            _repository = repository;
        }
        public Project CreateProject(Project project)
        {
            _repository.CreateProject(project);
            _repository.SaveChanges();
            return project;
        }

        public bool DeleteProject(int projectId)
        {
            var project = _repository.GetProject(projectId);
            if (project == null)
            {
                return false;
            }
            else
            {
                _repository.DeleteProject(project);
                _repository.SaveChanges();
                return true;
            }
        }

        public Project GetProject(int projectId)
        {
            var project = _repository.GetProject(projectId);
            if (project == null)
                return null;
            return project;
        }


        public Project UpdateProject(Project project)
        {
            var projectRetrived = _repository.GetProject(project.ProjectId);
            if (projectRetrived == null)
                return null;
            _repository.SaveChanges();
            _repository.UpdateProject(project);
            _repository.SaveChanges();
            return project;
        }
    }
}
