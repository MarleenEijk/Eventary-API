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

        public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            await _employeeRepository.AddEmployeeAsync(employeeDto);
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            await _employeeRepository.UpdateEmployeeAsync(employeeDto);
        }

        public async Task DeleteEmployeeAsync(long id)
        {
            await _employeeRepository.DeleteEmployeeAsync(id);
        }
    }
}
