using Microsoft.AspNetCore.Hosting;
using BlazorTests.Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Services
{
    public class ContactService : ServiceBase
    {
        #region Initialisation

        public ContactService(Repository repository) : base(repository)
        {
        }

        #endregion

        #region Gestion des contacts

        public Task<ContactEntity> GetContactEntity(int contactId)
        {
            return Task.FromResult(this.Repository.ContactEntities.Where(o => o.Id == contactId).Single());
        }

        public async Task<IList<Contact>> GetContacts()
        {
            return await GetContacts(this.Repository.ContactEntities);
        }  

        public async Task<Contact> GetContact(int contactId)
        {
            var contactViews = await GetContacts(this.Repository.ContactEntities.Where(o => o.Id == contactId).ToList());
            return contactViews[0];
        }

        private Task<IList<Contact>> GetContacts(IList<ContactEntity> contactEntities)
        {
            IList<Contact> contacts = new List<Contact>();
            foreach (var contactEntity in contactEntities)
            {
                var contact = new Contact();
                contact.Id = contactEntity.Id;
                contact.LastName = contactEntity.LastName;
                contact.FirstName = contactEntity.FirstName;
                contact.BirthDate = contactEntity.BirthDate;
                contact.Married = contactEntity.Married;
                if (contactEntity.CivilityId.HasValue)
                {
                    contact.CivilityId = contactEntity.CivilityId;
                    contact.CivilityText = this.Repository.CivilityEntities.Where(o => o.Id == contactEntity.CivilityId).Single().Text;
                }
                if (contactEntity.CompanyId.HasValue)
                {
                    contact.CompanyId = contactEntity.CompanyId;
                    contact.CompanyName = this.Repository.CompanyEntities.Where(o => o.Id == contactEntity.CompanyId).Single().Name;
                }

                contacts.Add(contact);
            }

            return Task.FromResult(contacts);
        }

        public async Task AddContact(ContactEntity contactEntity)
        {
            await Task.Factory.StartNew(() =>
            {
                var contactEntities = this.Repository.ContactEntities;
                contactEntity.Id = contactEntities.Max(o => o.Id) + 1;
                this.Repository.ContactEntities.Add(contactEntity);
            });
        }

        public async Task UpdateContact(ContactEntity contactEntity)
        {
            var existingContactEntity = await GetContactEntity(contactEntity.Id);
            existingContactEntity.LastName = contactEntity.LastName;
            existingContactEntity.FirstName = contactEntity.FirstName;
            existingContactEntity.CivilityId = contactEntity.CivilityId;
            existingContactEntity.BirthDate = contactEntity.BirthDate;
            existingContactEntity.Married = contactEntity.Married;
        }

        public async Task DeleteContact(int contactId)
        {
            await Task.Factory.StartNew(() =>
            {
                var contactEntity = this.Repository.ContactEntities.Where(o => o.Id == contactId).Single();
                this.Repository.ContactEntities.Remove(contactEntity);
            });
        }

        #endregion

        #region Gestion des contacts d'une société

        public async Task<IList<Contact>> GetCompanyContacts(int companyId)
        {
            return await GetContacts(this.Repository.ContactEntities.Where(o => o.CompanyId == companyId).ToList());
        }

        public async Task<IList<Contact>> GetUnassignedCompanyContacts(string searchFilter, int companyId)
        {
            if (string.IsNullOrWhiteSpace(searchFilter))
            {
                IList<Contact> contacts = new List<Contact>();
                return await Task.FromResult(contacts);
            }

            return await GetContacts(this.Repository.ContactEntities
                .Where(o => string.Concat(o.LastName, " ", o.FirstName).ToLower().Contains(searchFilter.ToLower()))
                .Where(o => o.CompanyId == null)
                .ToList());
        }

        public async Task AddContactToCompany(int contactId, int companyId)
        {
            var existingContactEntity = await GetContactEntity(contactId);
            existingContactEntity.CompanyId = companyId;
        }

        public async Task RemoveContactFromCompany(int contactId, int companyId /* Ne sert à rien mais plus logique */)
        {
            var existingContactEntity = await GetContactEntity(contactId);
            existingContactEntity.CompanyId = null;
        }        

        #endregion
    }
}
