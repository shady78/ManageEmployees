using ManageEmployees.API.Data.Base;
using ManageEmployees.API.Data.Interface;

namespace ManageEmployees.API.Data.Repositories
{
    public class ContractRepository : EntityBaseRepository<Models.Entities.Contract>, IContractRepository
    {
        public ContractRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
