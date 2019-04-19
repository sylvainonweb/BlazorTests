using BlazorTests.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorTests.Components
{
    public abstract class CloseablePageComponentBase : PageComponentBase
    {
        protected virtual async Task Close()
        {
            await JsInteropService.ReturnToCallerPage();
        }
    }
}