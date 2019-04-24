using Microsoft.AspNetCore.Hosting;
using BlazorTests.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Services.Business
{
    public class Repository
    {
        private IWebHostEnvironment WebHostEnvironment { get; set; }

        public Repository(IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
        }

        private IList<Contact> contacts = null;
        public IList<Contact> Contacts
        {
            get
            {
                if (contacts == null)
                {
                    string fileContent = File.ReadAllText(Path.Combine(WebHostEnvironment.WebRootPath, "data/crm/contacts.json"));
                    contacts = JsonConvert.DeserializeObject<IList<Contact>>(fileContent);
                }

                return contacts;
            }
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

        private IList<Civility> civilities = null;
        public IList<Civility> Civilities
        {
            get
            {
                if (civilities == null)
                {
                    string fileContent = File.ReadAllText(Path.Combine(WebHostEnvironment.WebRootPath, "data/crm/civilities.json"));
                    civilities = JsonConvert.DeserializeObject<IList<Civility>>(fileContent);
                }

                return civilities;
            }
        }
    }
}
