using CORE.Dto;

namespace CORE.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(long id);
        Task AddEmployeeAsync(EmployeeDto employeeDto);
    }
}
