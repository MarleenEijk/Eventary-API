using CORE.Interfaces;
using CORE.Models;
using Microsoft.EntityFrameworkCore;
using CORE.Dto;

namespace DAL.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;

        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _context.Employees.ToListAsync();
            return employees.Select(employee => new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                IsAdmin = employee.IsAdmin,
                StoragePermission = employee.StoragePermission,
                OrderPermission = employee.OrderPermission,
                EmployeePermission = employee.EmployeePermission,
                Company_Id = employee.Company_Id
            });
        }

        public async Task<EmployeeDto?> GetByIdAsync(long id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return null;
            }

            return new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                IsAdmin = employee.IsAdmin,
                StoragePermission = employee.StoragePermission,
                OrderPermission = employee.OrderPermission,
                EmployeePermission = employee.EmployeePermission,
                Company_Id = employee.Company_Id
            };
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

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            var existingEmployee = await _context.Employees.FindAsync(employeeDto.Id);
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

            _context.Employees.Update(existingEmployee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(long id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                throw new KeyNotFoundException($"Employee with id: {id} was not found.");
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }
    }
}
