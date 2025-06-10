using CORE.Dto;
using CORE.Interfaces;
using CORE.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly AppDbContext _context;

        public CompanyRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CompanyDto>> GetAllAsync()
        {
            return await _context.company
                .Select(company => new CompanyDto
                {
                    Id = company.Id,
                    Name = company.Name
                })
                .ToListAsync();
        }

        public async Task<CompanyDto?> GetByIdAsync(long id)
        {
            var company = await _context.company.FindAsync(id);
            if (company == null) return null;

            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name
            };
        }

        public async Task<CompanyDto> AddCompanyAsync(CompanyDto companyDto)
        {
            var company = new Company
            {
                Name = companyDto.Name
            };

            _context.company.Add(company);
            await _context.SaveChangesAsync();

            return new CompanyDto
            {
                Id = company.Id,
                Name = company.Name
            };
        }

        public async Task<bool> UpdateCompanyAsync(CompanyDto companyDto)
        {
            var company = await _context.company.FindAsync(companyDto.Id);
            if (company == null) return false;

            company.Name = companyDto.Name;
            _context.company.Update(company);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteCompanyAsync(long id)
        {
            var company = await _context.company.FindAsync(id);
            if (company == null) return false;

            _context.company.Remove(company);
            await _context.SaveChangesAsync();

            return true;

        }
    }
}
