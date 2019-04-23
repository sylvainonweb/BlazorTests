using Microsoft.AspNetCore.Hosting;
using BlazorTests.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Services
{
    public class CompanyService
    {
        #region Variables

        private IWebHostEnvironment WebHostEnvironment { get; set; }

        private IList<Company> companies = null;
        public IList<Company> Companies
        {
            get
            {
                if (companies == null)
                {
                    string fileContent = File.ReadAllText(Path.Combine(WebHostEnvironment.WebRootPath, "data/crm/companies.json"));
                    companies = JsonConvert.DeserializeObject<IList<Company>>(fileContent);
                }

                return companies;
            }
        }

        #endregion

        #region Initialisation

        public CompanyService(IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
        }

        #endregion

        #region Gestion des sociétés

        public Task<IList<Company>> GetCompaniesAsync()
        {
            return Task.FromResult(this.Companies);
        }

        public Task<Company> GetCompany(int companyId)
        {
            return Task.FromResult(this.Companies.Where(o => o.Id == companyId).Single());
        }

        public async Task AddCompany(Company company)
        {
            await Task.Factory.StartNew(() =>
            {
                var companies = this.Companies;
                company.Id = companies.Max(o => o.Id) + 1;
                this.Companies.Add(company);
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
                var company = this.Companies.Where(o => o.Id == companyId).Single();
                this.Companies.Remove(company);
            });
        }

        #endregion
    }
}
