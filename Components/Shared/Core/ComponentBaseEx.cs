using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;
using BlazorTests.Services;

namespace BlazorTests.Components
{
    public abstract class ComponentBaseEx : ComponentBase
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected JsInteropService JsInteropService { get; set; }
    }
}