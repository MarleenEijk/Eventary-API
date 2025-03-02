using CORE.Dto;
using CORE.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _employeeService.GetAllEmployeesAsync();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<EmployeeDto?> GetEmployeeByIdAsync(long id)
        {
            return await _employeeService.GetEmployeeByIdAsync(id);
        }

        //[HttpPost]
        //public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        //{
        //    await _employeeService.AddEmployeeAsync(employeeDto);
        //}

        //[HttpPut]
        //public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        //{
        //    await _employeeService.UpdateEmployeeAsync(employeeDto);
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //public async Task DeleteEmployeeAsync(long id)
        //{
        //    await _employeeService.DeleteEmployeeAsync(id);
        //}
    }
}
