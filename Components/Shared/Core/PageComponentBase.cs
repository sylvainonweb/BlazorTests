using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;
using BlazorTests.Services;

namespace BlazorTests.Components
{
    public abstract class PageComponentBase : ComponentBaseEx
    {
        public string Title { get; set; }
    }
}