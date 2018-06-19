using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor.Services;

public class IndexPageModel : BlazorComponent
{
    [Inject]
    protected IUriHelper UriHelper { get; set; }
 
    [Inject]
    protected HttpClient HttpClient { get; set; }
 
    protected string Title { get; private set; }
    protected IList<Customer> Customers { get; set; }
 
    protected override async Task OnInitAsync()
    {
        this.Title = "Clients";
        await LoadCustomers();
    }
 
    protected async Task LoadCustomers()
    {
        this.Customers = await HttpClient.GetJsonAsync<Customer[]>("api/Customer/Customers");
    }
 }