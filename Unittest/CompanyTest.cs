using CORE.Dto;
using Unittest.FakeRepositories;
using Xunit;

namespace Unittest
{
    public class CompanyTest
    {
        private readonly FakeCompanyRepository _repository;

        public CompanyTest()
        {
            _repository = new FakeCompanyRepository();
        }

        [Fact]
        public async Task AddCompanyAsync_ShouldAddCompany()
        {
            var companyDto = new CompanyDto
            {
                Id = 1,
                Name = "Test Company"
            };

            await _repository.AddCompanyAsync(companyDto);
            var companies = await _repository.GetAllAsync();

            Assert.Single(companies);
            Assert.Equal("Test Company", companies.First().Name);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnCompany()
        {
            var companyDto = new CompanyDto
            {
                Id = 1,
                Name = "Test Company"
            };
            await _repository.AddCompanyAsync(companyDto);

            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Test Company", result.Name);
        }

        [Fact]
        public async Task UpdateCompanyAsync_ShouldUpdateCompany()
        {
            var companyDto = new CompanyDto
            {
                Id = 1,
                Name = "Test Company"
            };
            await _repository.AddCompanyAsync(companyDto);

            var updatedCompanyDto = new CompanyDto
            {
                Id = 1,
                Name = "Updated Company"
            };

            await _repository.UpdateCompanyAsync(updatedCompanyDto);
            var result = await _repository.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal("Updated Company", result.Name);
        }

        [Fact]
        public async Task DeleteCompanyAsync_ShouldRemoveCompany()
        {
            var companyDto = new CompanyDto
            {
                Id = 1,
                Name = "Test Company"
            };
            await _repository.AddCompanyAsync(companyDto);

            await _repository.DeleteCompanyAsync(1);
            var result = await _repository.GetByIdAsync(1);

            Assert.Null(result);
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenNoCompaniesAdded()
        {
            var companies = await _repository.GetAllAsync();

            Assert.Empty(companies);
        }

        [Fact]
        public async Task GetByIdAsync_ShouldReturnNull_WhenCompanyDoesNotExist()
        {
            var result = await _repository.GetByIdAsync(999);

            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateCompanyAsync_ShouldThrowException_WhenCompanyDoesNotExist()
        {
            var companyDto = new CompanyDto
            {
                Id = 999,
                Name = "Nonexistent Company"
            };

            await Assert.ThrowsAsync<Exception>(() => _repository.UpdateCompanyAsync(companyDto));
        }

        [Fact]
        public async Task DeleteCompanyAsync_ShouldThrowException_WhenCompanyDoesNotExist()
        {
            await Assert.ThrowsAsync<Exception>(() => _repository.DeleteCompanyAsync(999));
        }
    }
}
