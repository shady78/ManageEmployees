using ManageEmployees.API.Data.Base;
using ManageEmployees.API.Data.Interface;
using ManageEmployees.API.Models.Entities;

namespace ManageEmployees.API.Data.Repositories
{
    public class EmployeeRepository : EntityBaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
