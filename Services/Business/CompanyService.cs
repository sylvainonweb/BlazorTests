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
        private IWebHostEnvironment WebHostEnvironment { get; set; }

        public CompanyService(IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
        }

        public Task<IList<Company>> GetCompaniesAsync()
        {
            return Task.FromResult(this.Companies);
        }

        public Company GetCompany(int companyId)
        {
            return this.Companies.Where(o => o.Id == companyId).Single();
        }

        public void AddCompany(Company company)
        {
            var companies = this.Companies;
            company.Id = companies.Max(o => o.Id) + 1;
            this.Companies.Add(company);
        }

        public void UpdateCompany(Company company)
        {
            var existingCompany = GetCompany(company.Id);
            existingCompany.Name = company.Name;
        }

        public void DeleteCompany(int companyId)
        {
            var company = this.Companies.Where(o => o.Id == companyId).Single();
            this.Companies.Remove(company);
        }

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
    }
}
