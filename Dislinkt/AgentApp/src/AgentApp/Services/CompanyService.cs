using AgentApp.Models;
using Common;

namespace AgentApp.Services
{
    public class CompanyService
    {
        private readonly IRepository<Company> _companyRepository;
        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            IEnumerable<Company> companies = await _companyRepository.GetAllAsync();
            return companies;
        }

        public async Task<Company> GetCompanyById(Guid id)
        {
            Company company = await _companyRepository.GetAsync(company => company.Id.Equals(id));
            return company;
        }

        public async Task<Company> GetCompanyByName(String name)
        {
            Company company = await _companyRepository.GetAsync(company => company.Name.Equals(name));
            return company;
        }

        public async Task CreateCompany(Company company)
        {
            await _companyRepository.CreateAsync(company);
        }

        public async Task UpdateCompany(Company company)
        {
            await _companyRepository.UpdateAsync(company);
        }
    }
}