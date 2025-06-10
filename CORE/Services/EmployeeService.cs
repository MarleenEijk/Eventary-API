using CORE.Dto;
using CORE.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CORE.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _employeeRepository.GetAllAsync();
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(long id)
        {
            return await _employeeRepository.GetByIdAsync(id);
        }

        public async Task<EmployeeDto?> GetByEmailAsync(string email)
        {
            return await _employeeRepository.GetByEmailAsync(email);
        }

    }
}
