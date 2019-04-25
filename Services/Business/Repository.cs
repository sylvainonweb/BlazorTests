using Microsoft.AspNetCore.Hosting;
using BlazorTests.Data;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Services
{
    public class Repository
    {
        private IWebHostEnvironment WebHostEnvironment { get; set; }

        public Repository(IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
        }

        private IList<ContactEntity> contactEntities = null;
        public IList<ContactEntity> ContactEntities
        {
            get
            {
                return GetList<ContactEntity>("Data/json/contacts.json", ref contactEntities);
            }
        }

        private IList<CompanyEntity> companyEntities = null;
        public IList<CompanyEntity> CompanyEntities
        {
            get
            {
                return GetList<CompanyEntity>("Data/json/companies.json", ref companyEntities);
            }
        }

        private IList<CivilityEntity> civilityEntities = null;
        public IList<CivilityEntity> CivilityEntities
        {
            get
            {
                return  GetList<CivilityEntity>("Data/json/civilities.json", ref civilityEntities);
            }
        }

        private IList<ActivityEntity> activityEntities = null;
        public IList<ActivityEntity> ActivityEntities
        {
            get
            {
                return GetList<ActivityEntity>("Data/json/activities.json", ref activityEntities);
            }
        }

        private IList<Parameter> parameters = null;
        public IList<Parameter> Parameters
        {
            get
            {
                return GetList<Parameter>("Data/json/parameters.json", ref parameters);
            }
        }

        private IList<ParameterValue> parameterValues = null;
        public IList<ParameterValue> ParameterValues
        {
            get
            {
                return GetList<ParameterValue>("Data/json/parameters-values.json", ref parameterValues);
            }
        }

        public IList<T> GetList<T>(string filePath, ref IList<T> entities)
        {
            if (entities == null)
            {
                string fileContent = File.ReadAllText(Path.Combine(WebHostEnvironment.ContentRootPath, filePath));
                entities = JsonConvert.DeserializeObject<IList<T>>(fileContent);
            }

            return entities;
        }
    }
}
