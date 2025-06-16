using CORE.Dto;
using CORE.Interfaces;
using CORE.Models;

namespace Unittest.FakeRepositories
{
    public class FakeEmployeeRepository : IEmployeeRepository
    {
        private readonly List<Employee> _employees = new();

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employeeDtos = _employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Email = e.Email,
                Password = e.Password,
                IsAdmin = e.IsAdmin,
                StoragePermission = e.StoragePermission,
                OrderPermission = e.OrderPermission,
                EmployeePermission = e.EmployeePermission,
                Company_Id = e.Company_Id
            });
            return await Task.FromResult(employeeDtos);
        }

        public async Task<EmployeeDto?> GetByIdAsync(long id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return null;
            }

            return await Task.FromResult(new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Password = employee.Password,
                IsAdmin = employee.IsAdmin,
                StoragePermission = employee.StoragePermission,
                OrderPermission = employee.OrderPermission,
                EmployeePermission = employee.EmployeePermission,
                Company_Id = employee.Company_Id
            });
        }

        public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = new Employee
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Email = employeeDto.Email,
                Password = employeeDto.Password,
                IsAdmin = employeeDto.IsAdmin,
                StoragePermission = employeeDto.StoragePermission,
                OrderPermission = employeeDto.OrderPermission,
                EmployeePermission = employeeDto.EmployeePermission,
                Company_Id = employeeDto.Company_Id
            };

            _employees.Add(employee);
            await Task.CompletedTask;
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == employeeDto.Id);
            if (existingEmployee == null)
            {
                throw new KeyNotFoundException($"Employee with id: {employeeDto.Id} was not found.");
            }

            existingEmployee.Name = employeeDto.Name;
            existingEmployee.Email = employeeDto.Email;
            existingEmployee.Password = employeeDto.Password;
            existingEmployee.IsAdmin = employeeDto.IsAdmin;
            existingEmployee.StoragePermission = employeeDto.StoragePermission;
            existingEmployee.OrderPermission = employeeDto.OrderPermission;
            existingEmployee.EmployeePermission = employeeDto.EmployeePermission;
            existingEmployee.Company_Id = employeeDto.Company_Id;

            await Task.CompletedTask;
        }

        public async Task DeleteEmployeeAsync(long id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with id: {id} was not found.");
            }

            _employees.Remove(employee);
            await Task.CompletedTask;
        }
    }
}
