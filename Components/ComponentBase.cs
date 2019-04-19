using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;
using BlazorTests.Services;

namespace BlazorTests.Components
{
    public abstract class ComponentBaseEx : ComponentBase
    {
        /// Afin que les composants de type Page est un titre
        public string Title { get; set; }

        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected JsInteropService JsInteropService { get; set; }
    }
}