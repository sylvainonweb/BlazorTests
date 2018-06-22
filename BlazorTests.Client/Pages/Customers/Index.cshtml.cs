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

namespace BlazorTests.Client
{
    public class IndexComponent : BaseComponent
    {
        protected Customer[] Customers { get; set; }

        [Inject]
        protected CustomerService CustomerService { get; set; }

        protected override async Task OnInitAsync()
        {
            this.Title = "Clients";
            this.Customers = await CustomerService.GetCustomers();
        }
    
        protected async Task EditCustomer(int id)
        {
        }

        protected async Task DeleteCustomer(int customerId)
        {
            if (MessageBox.ShowDeletionConfirmation())
            {
                await CustomerService.DeleteCustomer(customerId);
                MessageBox.ShowAlert("Suppression effectué");
                this.Customers = await CustomerService.GetCustomers();
            }
        }       
    }
}