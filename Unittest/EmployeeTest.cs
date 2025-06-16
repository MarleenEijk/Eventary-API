using CORE.Dto;
using CORE.Models;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class EmployeeTest
    {
        private readonly FakeEmployeeRepository _repository;

        public EmployeeTest()
        {
            _repository = new FakeEmployeeRepository();
        }

        [Fact]
        public async Task AddEmployeeAsync_ShouldAddEmployee()
        {
            var employeeDto = new EmployeeDto
            {
                Id = 1,
                Name = "Test Employee",
                Email = "test@example.com",
                Password = "password123",
                IsAdmin = true,
                StoragePermission = true,
                OrderPermission = true,
                EmployeePermission = true,
                Company_Id = 1
            };

            await _repository.AddEmployeeAsync(employeeDto);
            var employees = await _repository.GetAllAsync();

            Assert.Single(employees);
            Assert.Equal("Test Employee", employees.First().Name);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ShouldReturnEmployee()
        {
            var employeeDto = new EmployeeDto
            {
                Id = 1,
                Name = "Test Employee",
                Email = "test@example.com",
                Password = "password123"
            };
            await _repository.AddEmployeeAsync(employeeDto);

            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Test Employee", result.Name);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_ShouldUpdateEmployee()
        {
            var employeeDto = new EmployeeDto
            {
                Id = 1,
                Name = "Test Employee",
                Email = "test@example.com",
                Password = "password123"
            };
            await _repository.AddEmployeeAsync(employeeDto);

            var updatedEmployee = new EmployeeDto
            {
                Id = 1,
                Name = "Updated Employee",
                Email = "updated@example.com",
                Password = "newpassword123"
            };
            await _repository.UpdateEmployeeAsync(updatedEmployee);

            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Updated Employee", result.Name);
        }

        [Fact]
        public async Task DeleteEmployeeAsync_ShouldRemoveEmployee()
        {
            var employeeDto = new EmployeeDto
            {
                Id = 1,
                Name = "Test Employee",
                Email = "test@example.com",
                Password = "password123"
            };
            await _repository.AddEmployeeAsync(employeeDto);

            await _repository.DeleteEmployeeAsync(1);
            var result = await _repository.GetByIdAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetEmployeeByIdAsync_ShouldReturnNull_WhenEmployeeDoesNotExist()
        {
            var result = await _repository.GetByIdAsync(999);
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateEmployeeAsync_ShouldThrowException_WhenEmployeeDoesNotExist()
        {
            var nonExistentEmployee = new EmployeeDto
            {
                Id = 999,
                Name = "Non-existent Employee",
                Email = "nonexistent@example.com",
                Password = "password123"
            };

            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _repository.UpdateEmployeeAsync(nonExistentEmployee);
            });

            Assert.Equal("Employee with id: 999 was not found.", exception.Message);
        }

        [Fact]
        public async Task DeleteEmployeeAsync_ShouldThrowException_WhenEmployeeDoesNotExist()
        {
            var exception = await Assert.ThrowsAsync<KeyNotFoundException>(async () =>
            {
                await _repository.DeleteEmployeeAsync(999);
            });

            Assert.Equal("Employee with id: 999 was not found.", exception.Message);
        }
    }
}
