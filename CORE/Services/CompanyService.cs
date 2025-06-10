using CORE.Dto;
using CORE.Interfaces;

namespace CORE.Services
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompaniesAsync()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<CompanyDto?> GetCompanyByIdAsync(int id)
        {
            return await _companyRepository.GetByIdAsync(id);
        }

        public async Task<CompanyDto> AddCompanyAsync(CompanyDto companyDto)
        {
            if (string.IsNullOrWhiteSpace(companyDto.Name))
            {
                throw new ArgumentException("Company name cannot be empty.");
            }

            var existingCompany = await _companyRepository.GetByIdAsync(companyDto.Id);
            if (existingCompany != null)
            {
                throw new ArgumentException("A company with the same ID already exists.");
            }

            return await _companyRepository.AddCompanyAsync(companyDto);
        }

        public async Task<bool> UpdateCompanyAsync(CompanyDto companyDto)
        {
            if (string.IsNullOrWhiteSpace(companyDto.Name))
            {
                throw new ArgumentException("Company name cannot be empty.");
            }

            var existingCompany = await _companyRepository.GetByIdAsync(companyDto.Id);
            if (existingCompany == null)
            {
                throw new ArgumentException("Company not found.");
            }

            return true;
        }
        public async Task<bool> DeleteCompanyAsync(long id)
        {
            var existingCompany = await _companyRepository.GetByIdAsync(id);
            if (existingCompany == null)
            {
                throw new ArgumentException("Company not found.");
            }
            return true;
        }
    }
}
