using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
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
            return HttpClient.GetJsonAsync<Customer[]>("api/Customer");
        }

        public Task<Customer> GetCustomer(int customerId)
        {
            return HttpClient.GetJsonAsync<Customer>($"api/Customer/{customerId}");
        }

        public Task<HttpResponseMessage> DeleteCustomer(int customerId)
        {
            RegisteredFunction.Invoke<string>("alert", customerId);
            return HttpClient.DeleteAsync($"api/Customer/{customerId}");
        }
    }

    public abstract class ServiceBase
    {
        protected HttpClient HttpClient { get; set; }
    }
}
