using CORE.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CORE.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(long id);
        Task<EmployeeDto?> GetByEmailAsync(string email);

    }
}
