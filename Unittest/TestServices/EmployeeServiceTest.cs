using CORE.Dto;
using CORE.Services;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest.TestServices
{
    public class EmployeeServiceTest
    {
        private readonly FakeEmployeeRepository _repository;
        private readonly EmployeeService _service;

        public EmployeeServiceTest()
        {
            _repository = new FakeEmployeeRepository();
            _service = new EmployeeService(_repository);
        }

        [Fact]
        public async Task AddEmployeeAsync_ShouldAddEmployee()
        {
            var employeeDto = new EmployeeDto
            {
                Id = 1,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Password = "securepassword",
                IsAdmin = false,
                StoragePermission = true,
                OrderPermission = true,
                EmployeePermission = false,
                Company_Id = 100
            };

            await _service.AddEmployeeAsync(employeeDto);
            var result = await _service.GetEmployeeByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("John Doe", result!.Name);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ShouldReturnEmployee()
        {
            var employeeDto = new EmployeeDto
            {
                Id = 1,
                Name = "Jane Doe",
                Email = "jane.doe@example.com",
                Password = "securepassword",
                IsAdmin = true,
                StoragePermission = false,
                OrderPermission = true,
                EmployeePermission = true,
                Company_Id = 101
            };

            await _service.AddEmployeeAsync(employeeDto);
            var result = await _service.GetEmployeeByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Jane Doe", result!.Name);
        }

        [Fact]
        public async Task GetAllEmployeesAsync_ShouldReturnAllEmployees()
        {
            await _service.AddEmployeeAsync(new EmployeeDto
            {
                Id = 1,
                Name = "Alice",
                Email = "alice@example.com",
                Password = "securepassword",
                IsAdmin = false,
                StoragePermission = true,
                OrderPermission = false,
                EmployeePermission = true,
                Company_Id = 102
            });

            await _service.AddEmployeeAsync(new EmployeeDto
            {
                Id = 2,
                Name = "Bob",
                Email = "bob@example.com",
                Password = "securepassword",
                IsAdmin = true,
                StoragePermission = false,
                OrderPermission = true,
                EmployeePermission = false,
                Company_Id = 103
            });

            var result = await _service.GetAllEmployeesAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task DeleteEmployeeAsync_ShouldRemoveEmployee()
        {
            var employeeDto = new EmployeeDto
            {
                Id = 1,
                Name = "Charlie",
                Email = "charlie@example.com",
                Password = "securepassword",
                IsAdmin = false,
                StoragePermission = true,
                OrderPermission = true,
                EmployeePermission = false,
                Company_Id = 104
            };

            await _service.AddEmployeeAsync(employeeDto);

            await _service.DeleteEmployeeAsync(1);
            var result = await _service.GetEmployeeByIdAsync(1);

            Assert.Null(result);
        }
    }
}
