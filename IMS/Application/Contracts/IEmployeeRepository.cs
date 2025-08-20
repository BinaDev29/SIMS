// Application/Contracts/IEmployeeRepository.cs
using Domain.Models;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<Employee> GetByUsername(string username);
    }
}