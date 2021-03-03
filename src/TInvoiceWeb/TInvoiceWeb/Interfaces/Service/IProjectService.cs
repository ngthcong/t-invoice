using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TInvoiceWeb.Data;

namespace TInvoiceWeb.Interfaces.Service
{
    public interface IProjectService
    {
        Project GetProject(int projectId);
        Project CreateProject(Project project);
        bool DeleteProject(int projectId);
        Project UpdateProject(Project project);
       
    }
}
