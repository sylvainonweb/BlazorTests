using Microsoft.AspNetCore.Components;
using BlazorTests.Services;
using System;

namespace BlazorTests.Core
{
    public abstract class ComponentBaseEx : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        [Inject]
        protected JsInteropService JsInteropService { get; set; }
    }
}