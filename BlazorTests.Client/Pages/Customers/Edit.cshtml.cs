using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using BlazorTests.Client.Services;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor.Components;

namespace BlazorTests.Client
{
    public class EditComponent : BaseComponent
    {
        #region Services

        [Inject]
        protected CustomerService CustomerService { get; set; }

        #endregion

        #region Propriétés bindées

        [Parameter]
        private string Id { get; set; }

        public string Name { get; set; }
        public string FirstName { get; set; }
      
        #endregion

        #region Initialisation

         protected override async Task OnParametersSetAsync()
        {
            if (IsNew())
            {
                this.Title = "Ajouter un client";             
            }
            else
            {
                this.Title = "Modifier un client";

                Customer customer = await CustomerService.GetCustomer(int.Parse(Id));
                this.Name = customer.Name;
                this.FirstName = customer.FirstName;
            }
        }

        #endregion

        #region Sauvegarde
        protected async Task Save()
        {
            Customer customer = null;
            if (IsNew())
            {
                customer = new Customer();         
            }
            else
            {
                customer = await CustomerService.GetCustomer(int.Parse(Id));
            }

            customer.Name = this.Name;
            customer.FirstName = this.FirstName;

            await CustomerService.SaveCustomer(customer);
            UriHelper.NavigateTo("/");
        }

        #endregion

        private bool IsNew()
        {
            if (string.IsNullOrWhiteSpace(Id))
            {
                return true;
            }

            return false;
        }
    }
}


