using Microsoft.AspNetCore.Hosting;
using BlazorTests.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlazorTests.Services.Business;

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

        public async Task<IList<ContactView>> GetContactsForList()
        {
            return await GetContactViews(this.Repository.Contacts);
        }  

        public Task<Contact> GetContactForEdit(int contactId)
        {
            return Task.FromResult(this.Repository.Contacts.Where(o => o.Id == contactId).Single());
        }

        public async Task<ContactView> GetContactForDetail(int contactId)
        {
            var contactViews = await GetContactViews(this.Repository.Contacts.Where(o => o.Id == contactId).ToList());
            return contactViews[0];
        }

        private Task<IList<ContactView>> GetContactViews(IList<Contact> contacts)
        {
            IList<ContactView> contactViews = new List<ContactView>();
            foreach (var contact in contacts)
            {
                var contactView = new ContactView();
                contactView.Id = contact.Id;
                contactView.LastName = contact.LastName;
                contactView.FirstName = contact.FirstName;
                if (contact.CivilityId.HasValue)
                {
                    contactView.CivilityId = contact.CivilityId;
                    contactView.CivilityText = this.Repository.Civilities.Where(o => o.Id == contact.CivilityId).Single().Text;
                }
                if (contact.CompanyId.HasValue)
                {
                    contactView.CompanyId = contact.CompanyId;
                    contactView.CompanyName = this.Repository.Companies.Where(o => o.Id == contact.CompanyId).Single().Name;
                }

                contactViews.Add(contactView);
            }

            return Task.FromResult(contactViews);
        }

        public async Task AddContact(Contact contact)
        {
            await Task.Factory.StartNew(() =>
            {
                var contacts = this.Repository.Contacts;
                contact.Id = contacts.Max(o => o.Id) + 1;
                this.Repository.Contacts.Add(contact);
            });
        }

        public async Task UpdateContact(Contact contact)
        {
            var existingContact = await GetContactForEdit(contact.Id);
            existingContact.LastName = contact.LastName;
            existingContact.FirstName = contact.FirstName;
            existingContact.CivilityId = contact.CivilityId;
        }

        public async Task DeleteContact(int contactId)
        {
            await Task.Factory.StartNew(() =>
            {
                var contact = this.Repository.Contacts.Where(o => o.Id == contactId).Single();
                this.Repository.Contacts.Remove(contact);
            });
        }

        #endregion

        #region Gestion des contacts d'une société

        public async Task<IList<ContactView>> GetCompanyContacts(int companyId)
        {
            return await GetContactViews(this.Repository.Contacts.Where(o => o.CompanyId == companyId).ToList());
        }

        public async Task<IList<ContactView>> GetUnassignedCompanyContacts(string searchFilter, int companyId)
        {
            if (string.IsNullOrWhiteSpace(searchFilter))
            {
                IList<ContactView> contactsViews = new List<ContactView>();
                return await Task.FromResult(contactsViews);
            }

            return await GetContactViews(this.Repository.Contacts
                .Where(o => string.Concat(o.LastName, " ", o.FirstName).ToLower().Contains(searchFilter.ToLower()))
                .Where(o => o.CompanyId == null)
                .ToList());
        }

        public async Task AddContactToCompany(int contactId, int companyId)
        {
            var existingContact = await GetContactForEdit(contactId);
            existingContact.CompanyId = companyId;
        }

        public async Task RemoveContactFromCompany(int contactId, int companyId /* Ne sert à rien mais plus logique */)
        {
            var existingContact = await GetContactForEdit(contactId);
            existingContact.CompanyId = null;
        }        

        #endregion
    }
}
