using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TInvoiceWeb.Controllers
{
    public class AdministratorController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public AdministratorController (RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
    }
}
