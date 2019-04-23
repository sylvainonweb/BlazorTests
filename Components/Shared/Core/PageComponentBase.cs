using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;
using BlazorTests.Services;
using System.Threading.Tasks;

namespace BlazorTests.Components
{
    public abstract class PageComponentBase : ComponentBaseEx
    {
        public string Title { get; set; }

        protected async Task ReturnToCallerPage()
        {
            await JsInteropService.ReturnToCallerPage();
        }
    }
}