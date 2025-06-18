using CORE.Dto;
using CORE.Interfaces;
using CORE.Models;

namespace Unittest.FakeRepositories
{
    public class FakeCompanyRepository : ICompanyRepository
    {
        private readonly List<Company> _companies = new();

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            var companyDtos = _companies.Select(c => new CompanyDto
            {
                Id = c.Id,
                Name = c.Name
            });
            return await Task.FromResult(companyDtos);
        }

        public async Task<CompanyDto?> GetByIdAsync(long id)
        {
            var company = _companies.FirstOrDefault(c => c.Id == id);
            if (company == null)
            {
                return null;
            }

            return await Task.FromResult(new CompanyDto
            {
                Id = company.Id,
                Name = company.Name
            });
        }

        public async Task<CompanyDto> AddCompanyAsync(CompanyDto companyDto)
        {
            var company = new Company
            {
                Id = companyDto.Id,
                Name = companyDto.Name
            };

            _companies.Add(company);

            return await Task.FromResult(companyDto);
        }

        public async Task<bool> UpdateCompanyAsync(CompanyDto companyDto)
        {
            var company = _companies.FirstOrDefault(c => c.Id == companyDto.Id);
            if (company == null)
            {
                throw new Exception("Company not found");
            }

            company.Name = companyDto.Name;

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteCompanyAsync(long id)
        {
            var company = _companies.FirstOrDefault(c => c.Id == id);
            if (company == null)
            {
                throw new Exception("Company not found");
            }

            _companies.Remove(company);
            return await Task.FromResult(true);
        }
    }
}
