using CORE.Dto;
using CORE.Services;
using Microsoft.AspNetCore.Mvc;

namespace Eventary_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [ProducesResponseType<List<CompanyDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync()
        {
            return await _companyService.GetAllCompaniesAsync();
        }

        [HttpGet("{id}", Name = "GetCompanyById")]
        [ProducesResponseType<CompanyDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCompanyByIdAsync(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        [HttpPost]
        [ProducesResponseType<CompanyDto>(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddCompanyAsync([FromBody] CompanyDto companyDto)
        {
            if (companyDto == null || string.IsNullOrWhiteSpace(companyDto.Name))
            {
                return BadRequest("Invalid company data.");
            }

            try
            {
                var createdCompany = await _companyService.AddCompanyAsync(companyDto);
                return CreatedAtRoute("GetCompanyById", new { id = createdCompany.Id }, createdCompany);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCompanyAsync(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            if (company == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType<CompanyDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateCompanyAsync(int id, [FromBody] CompanyDto companyDto)
        {
            if (companyDto == null || string.IsNullOrWhiteSpace(companyDto.Name))
            {
                return BadRequest("Invalid company data.");
            }

            var existingCompany = await _companyService.GetCompanyByIdAsync(id);
            if (existingCompany == null)
            {
                return NotFound();
            }
            return Ok(existingCompany);
        }
    }
}
