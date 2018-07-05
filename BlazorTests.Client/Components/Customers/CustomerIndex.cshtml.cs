using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor.Services;
using BlazorTests.Client.Services;
using BlazorTests.Client.Shared;

namespace BlazorTests.Client
{
    public class CustomerIndexComponent : ComponentBase
    {
        #region Services

        [Inject]
        protected CustomerService CustomerService { get; set; }

        #endregion

        #region Propriétés bindées

        protected IList<Customer> Customers { get; set; } = new List<Customer>();
        protected IList<CustomerType> CustomerTypes { get; set; } = new List<CustomerType>();
        protected int CustomerTypeId { get; set; }

        #endregion

        #region Initialisation

        protected override async Task OnInitAsync()
        {
            this.Title = "Clients";
            this.CustomerTypes = await CustomerService.GetCustomerTypes();
            await LoadCustomers();
        }

        protected async Task LoadCustomers()
        {
            this.Customers = await CustomerService.GetCustomers(GetNullableInt(this.CustomerTypeId));
        }

        #endregion

        #region  Gestion des clients

        protected void AddCustomer()
        {
            UriHelper.NavigateTo($"/customer/edit");
        }

        protected void EditCustomer(int id)
        {
            UriHelper.NavigateTo($"/customer/edit/{id}");
        }

        protected async Task DeleteCustomer(int customerId)
        {
            if (MessageBox.ShowDeletionConfirmation())
            {
                await CustomerService.DeleteCustomer(customerId);
                MessageBox.ShowAlert("Suppression effectuée");
                this.Customers = await CustomerService.GetCustomers(GetNullableInt(this.CustomerTypeId));
            }
        }

        #endregion
    }
}
