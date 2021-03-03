using System.Linq;
using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces.Repository;

namespace TInvoiceWeb.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly TInvoiceDBContext _context;

        public ProjectRepository(TInvoiceDBContext invoiceDBContext)
        {
            _context = invoiceDBContext;
        }
        public Project CreateProject(Project project)
        {
            _context.Projects.Add(project);
            return project;
        }

        public void DeleteProject(Project project)
        {
            _context.Projects.Remove(project);
        }

        public Project GetProject(int projectId)
        {
            return _context.Projects.Where(x => x.ProjectId == projectId).FirstOrDefault();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            _context.Update(project);
        }
    }
}
