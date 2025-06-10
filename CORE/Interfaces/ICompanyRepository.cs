using CORE.Dto;

namespace CORE.Interfaces
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyDto>> GetAllAsync();
        Task<CompanyDto?> GetByIdAsync(long id);
        Task<CompanyDto> AddCompanyAsync(CompanyDto companyDto);
        Task<bool> UpdateCompanyAsync(CompanyDto companyDto);
        Task<bool> DeleteCompanyAsync(long id);
    }
}

