using System.Net.Http;
using BlazorTests.Client.Shared;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorTests.Client
{
    public abstract class ComponentBase : BlazorComponent
    {
        protected string Title { get; set; }

        [Inject]
        protected IUriHelper UriHelper { get; set; }
    }
}