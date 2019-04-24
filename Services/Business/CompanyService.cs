
using BlazorTests.Data;
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

        public Task<CompanyEntity> GetCompanyEntity(int companyId)
        {
            return Task.FromResult(this.Repository.CompanyEntities.Where(o => o.Id == companyId).Single());
        }

        public async Task<IList<Company>> GetCompanies()
        {
            return await GetCompanies(this.Repository.CompanyEntities);
        }

        public async Task<Company> GetCompany(int companyId)
        {
            var companies = await GetCompanies(this.Repository.CompanyEntities.Where(o => o.Id == companyId).ToList());
            return companies[0];
        }

        private Task<IList<Company>> GetCompanies(IList<CompanyEntity> companyEntities)
        {
            IList<Company> companies = new List<Company>();
            foreach (var companyEntity in companyEntities)
            {
                var company = new Company();
                company.Id = companyEntity.Id;
                company.Name = companyEntity.Name;         
                if (companyEntity.ActivityId.HasValue)
                {
                    company.ActivityId = companyEntity.ActivityId;
                    company.ActivityText = this.Repository.ActivityEntities.Where(o => o.Id == companyEntity.ActivityId).Single().Text;
                }

                companies.Add(company);
            }

            return Task.FromResult(companies);
        }

        public async Task AddCompany(CompanyEntity companyEntity)
        {
            await Task.Factory.StartNew(() =>
            {
                var companyEntities = this.Repository.CompanyEntities;
                companyEntity.Id = companyEntities.Max(o => o.Id) + 1;
                this.Repository.CompanyEntities.Add(companyEntity);
            });
        }

        public async Task UpdateCompany(CompanyEntity companyEntity)
        {
            var existingCompanyEntity = await GetCompanyEntity(companyEntity.Id);
            existingCompanyEntity.Name = companyEntity.Name;
            existingCompanyEntity.ActivityId = companyEntity.ActivityId;
        }

        public async Task DeleteCompany(int companyId)
        {
            var companyEntity = await GetCompanyEntity(companyId);
            this.Repository.CompanyEntities.Remove(companyEntity);
        }

        #endregion
    }
}
