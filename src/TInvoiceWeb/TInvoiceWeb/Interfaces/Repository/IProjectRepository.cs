using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;

namespace TInvoiceWeb.Interfaces.Repository
{
    public interface IProjectRepository
    {
        Project GetProject(int projectId);
        Project CreateProject(Project project);
        void DeleteProject(Project project);
        void UpdateProject(Project project);
        void SaveChanges();

    }
}
