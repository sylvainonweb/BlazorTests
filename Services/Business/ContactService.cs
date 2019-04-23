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
        private IWebHostEnvironment WebHostEnvironment { get; set; }

        public ContactService(IWebHostEnvironment env)
        {
            this.WebHostEnvironment = env;
        }

        public Task<IList<Contact>> GetContactsAsync()
        {
            return Task.FromResult(this.Contacts);
        }

        public Contact GetContact(int contactId)
        {
            return this.Contacts.Where(o => o.Id == contactId).Single();
        }

        public void AddContact(Contact contact)
        {
            var contacts = this.Contacts;
            contact.Id = contacts.Max(o => o.Id) + 1;
            this.Contacts.Add(contact);
        }

        public void UpdateContact(Contact contact)
        {
            var existingContact = GetContact(contact.Id);
            existingContact.LastName = contact.LastName;
            existingContact.FirstName = contact.FirstName;
        }

        public void DeleteContact(int contactId)
        {
            var contact = this.Contacts.Where(o => o.Id == contactId).Single();
            this.Contacts.Remove(contact);
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
    }
}
