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
        [ProducesResponseType<List<EmployeeDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            return await _employeeService.GetAllEmployeesAsync();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<EmployeeDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult?> GetEmployeeByIdAsync(long id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(employee);
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
