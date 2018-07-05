using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTests.Client.Services;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;

namespace BlazorTests.Client
{
    public class CustomerEditComponent : EditComponentBase
    {
        #region Services

        [Inject]
        protected AdministrationService AdministrationService { get; set; }

        [Inject]
        protected CustomerService CustomerService { get; set; }

        #endregion

        #region Propriétés bindées

        protected string Name { get; set; }
        protected string FirstName { get; set; }
        protected int CustomerTypeId { get; set; }
        protected IList<CustomerType> CustomerTypes { get; set; } = new List<CustomerType>();

        #endregion

        #region Initialisation

        protected override async Task OnParametersSetAsync()
        {
            this.CustomerTypes = await AdministrationService.GetCustomerTypes();

            if (IsNew())
            {
                this.Title = "Ajouter un client";             
            }
            else
            {
                this.Title = "Modifier un client";

                Customer customer = await CustomerService.GetCustomer(Id.Value);
                this.Name = customer.Name;
                this.FirstName = customer.FirstName;
                this.CustomerTypeId = customer.CustomerTypeId;
            }
        }

        #endregion

        #region Sauvegarde

        protected override async Task Save()
        {
            Customer customer = null;
            if (IsNew())
            {
                customer = new Customer();         
            }
            else
            {
                customer = await CustomerService.GetCustomer(Id.Value);
            }

            customer.Name = this.Name;
            customer.FirstName = this.FirstName;
            customer.CustomerTypeId = this.CustomerTypeId;

            await CustomerService.SaveCustomer(customer);
            UriHelper.NavigateTo("/Customer");
        }

        protected override void Close()
        {
            UriHelper.NavigateTo("/Customer");
        }

        #endregion
    }
}


