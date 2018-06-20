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

        protected void ConfirmDelete()
        {
            RegisteredFunction.Invoke<bool>("confirmDelete", "Suppression");
        }

        protected async Task DeleteCustomer()
        {
            //RegisteredFunction.Invoke<bool>("hideDeleteDialog");

            // await BooksClient.DeleteBook(DeleteId);
            // await LoadBooks(int.Parse(Page));
        }
    }
}