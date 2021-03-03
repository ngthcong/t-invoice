using TInvoiceWeb.Data;
using TInvoiceWeb.Interfaces;
using TInvoiceWeb.Responses;

namespace TInvoiceWeb.Services
{
    public class RoleService : IRoleService
    {
        private readonly IUserRepository _repo;

        public RoleService(IUserRepository repository)
        {
            _repo = repository;
        }

        public int GetUserRole(int EmpId)
        {
            return _repo.GetUserRole(EmpId);
        }

    }
}
