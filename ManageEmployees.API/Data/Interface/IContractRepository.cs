using System.Diagnostics.Contracts;
using ManageEmployees.API.Models.Entities;

namespace ManageEmployees.API.Data.Interface
{
    public interface IContractRepository : IEntityBaseRepository<Models.Entities.Contract>
    {
    }
}
