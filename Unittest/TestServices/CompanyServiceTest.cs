using CORE.Dto;
using CORE.Services;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest.TestServices
{
    public class CompanyServiceTest
    {
        private readonly FakeCompanyRepository _repository;
        private readonly CompanyService _service;

        public CompanyServiceTest()
        {
            _repository = new FakeCompanyRepository();
            _service = new CompanyService(_repository);
        }

        [Fact]
        public async Task AddCompanyAsync_ShouldAddCompany()
        {
            var companyDto = new CompanyDto { Id = 1, Name = "TechCorp" };
            var result = await _service.AddCompanyAsync(companyDto);

            Assert.NotNull(result);
            Assert.Equal("TechCorp", result.Name);
        }

        [Fact]
        public async Task AddCompanyAsync_ShouldThrow_WhenDuplicateId()
        {
            var companyDto = new CompanyDto { Id = 1, Name = "TechCorp" };
            await _service.AddCompanyAsync(companyDto);

            var duplicate = new CompanyDto { Id = 1, Name = "AnotherCorp" };

            await Assert.ThrowsAsync<ArgumentException>(() => _service.AddCompanyAsync(duplicate));
        }

        [Fact]
        public async Task GetCompanyByIdAsync_ShouldReturnCompany()
        {
            var companyDto = new CompanyDto { Id = 1, Name = "TechCorp" };
            await _service.AddCompanyAsync(companyDto);

            var result = await _service.GetCompanyByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("TechCorp", result!.Name);
        }

        [Fact]
        public async Task GetAllCompaniesAsync_ShouldReturnAllCompanies()
        {
            await _service.AddCompanyAsync(new CompanyDto { Id = 1, Name = "TechCorp" });
            await _service.AddCompanyAsync(new CompanyDto { Id = 2, Name = "BizCorp" });

            var result = await _service.GetAllCompaniesAsync();

            Assert.Equal(2, result.Count());
        }

    }
}
