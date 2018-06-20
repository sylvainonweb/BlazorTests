using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorTests.Client.Services
{
    public class CustomerService : ServiceBase
    {
        public CustomerService(HttpClient httpClient)
        {
            this.HttpClient = httpClient;
        }

        public Task<Customer[]> GetCustomers()
        {
            return HttpClient.GetJsonAsync<Customer[]>("api/Customer/Customers");
        }
    }

    public abstract class ServiceBase
    {
        protected HttpClient HttpClient { get; set; }
    }
}
