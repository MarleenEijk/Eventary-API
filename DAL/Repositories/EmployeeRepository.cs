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
            var employees = await _context.employee.ToListAsync();
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
            var employee = await _context.employee.FindAsync(id);
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

        public async Task<EmployeeDto?> GetByEmailAsync(string email)
        {
            var employee = await _context.employee.FirstOrDefaultAsync(e => e.Email == email);
            if (employee == null)
                return null;

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

    }
}
