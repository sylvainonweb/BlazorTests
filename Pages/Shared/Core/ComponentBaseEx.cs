﻿using Microsoft.AspNetCore.Components;
using BlazorTests.Services;

namespace BlazorTests.Pages
{
    public abstract class ComponentBaseEx : ComponentBase
    {
        [Inject]
        protected IUriHelper UriHelper { get; set; }

        [Inject]
        protected JsInteropService JsInteropService { get; set; }
    }
}