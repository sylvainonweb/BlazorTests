
using BlazorTests.Models;
using BlazorTests.Services.Business;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Services
{
    public class CompanyService : ServiceBase
    {
        #region Initialisation

        public CompanyService(Repository repository) : base(repository)
        {
        }

        #endregion

        #region Gestion des sociétés

        public Task<IList<Company>> GetCompaniesAsync()
        {
            return Task.FromResult(this.Repository.Companies);
        }

        public Task<Company> GetCompany(int companyId)
        {
            return Task.FromResult(this.Repository.Companies.Where(o => o.Id == companyId).Single());
        }

        public async Task AddCompany(Company company)
        {
            await Task.Factory.StartNew(() =>
            {
                var companies = this.Repository.Companies;
                company.Id = companies.Max(o => o.Id) + 1;
                this.Repository.Companies.Add(company);
            });
        }

        public async Task UpdateCompany(Company company)
        {
            var existingCompany = await GetCompany(company.Id);
            existingCompany.Name = company.Name;
        }

        public async Task DeleteCompany(int companyId)
        {
            await Task.Factory.StartNew(() =>
            {
                var company = this.Repository.Companies.Where(o => o.Id == companyId).Single();
                this.Repository.Companies.Remove(company);
            });
        }

        #endregion
    }
}
