using CORE.Dto;
using CORE.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventary_API.Controllers
{
    [Authorize]
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

        [HttpGet("me")]
        [ProducesResponseType<EmployeeDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCurrentEmployeeAsync()
        {
            var email = User.FindFirst("email")?.Value;

            if (string.IsNullOrEmpty(email))
                return Unauthorized("No email claim in token.");

            var employee = await _employeeService.GetByEmailAsync(email);
            if (employee == null)
                return NotFound("Employee record not found for this email.");

            return Ok(employee);
        }

    }
}
