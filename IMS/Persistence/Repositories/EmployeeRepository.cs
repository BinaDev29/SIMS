// Persistence/Repositories/EmployeeRepository.cs
using Application.Contracts;
using Domain.Models;
using Persistence;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(SIMSDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Employee> GetByUsername(string username)
        {
            return await _dbContext.Employees.FirstOrDefaultAsync(e => e.Username == username);
        }
    }
}