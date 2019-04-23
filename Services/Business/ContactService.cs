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
    public class ContactService
    {
        #region Variables 

        private IWebHostEnvironment WebHostEnvironment { get; set; }

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

        #endregion

        #region Initialisation

        public ContactService(IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
        }

        #endregion

        #region Gestion des contacts

        public Task<IList<Contact>> GetContactsAsync()
        {
            return Task.FromResult(this.Contacts);
        }
  

        public Task<Contact> GetContact(int contactId)
        {
            return Task.FromResult(this.Contacts.Where(o => o.Id == contactId).Single());
        }

        public async Task AddContact(Contact contact)
        {
            await Task.Factory.StartNew(() =>
            {
                var contacts = this.Contacts;
                contact.Id = contacts.Max(o => o.Id) + 1;
                this.Contacts.Add(contact);
            });
        }

        public async Task UpdateContact(Contact contact)
        {
            var existingContact = await GetContact(contact.Id);
            existingContact.LastName = contact.LastName;
            existingContact.FirstName = contact.FirstName;
        }

        public async Task DeleteContact(int contactId)
        {
            await Task.Factory.StartNew(() =>
            {
                var contact = this.Contacts.Where(o => o.Id == contactId).Single();
                this.Contacts.Remove(contact);
            });
        }

        #endregion

        #region Gestion des contacts d'une société

        public Task<List<Contact>> GetCompanyContactsAsync(int companyId)
        {
            return Task.FromResult(
                this.Contacts.Where(o => o.CompanyId == companyId).ToList()
            );
        }

        public Task<List<Contact>> GetUnassignedCompanyContactsAsync(string searchFilter, int companyId)
        {
            if (string.IsNullOrWhiteSpace(searchFilter))
            {
                return Task.FromResult(new List<Contact>());
            }

            return Task.FromResult(
                this.Contacts
                    .Where(o => string.Concat(o.LastName, " ", o.FirstName).ToLower().Contains(searchFilter.ToLower()))
                    .Where(o => o.CompanyId == null).ToList()
            );
        }

        public async Task AddContactToCompany(int contactId, int companyId)
        {
            var existingContact = await GetContact(contactId);
            existingContact.CompanyId = companyId;
        }

        public async Task RemoveContactFromCompany(int contactId, int companyId /* Ne sert à rien mais plus logique */)
        {
            var existingContact = await GetContact(contactId);
            existingContact.CompanyId = null;
        }        

        #endregion
    }
}
