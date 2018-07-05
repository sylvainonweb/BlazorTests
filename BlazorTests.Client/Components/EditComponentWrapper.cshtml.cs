using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using System.Net.Http;
using Microsoft.AspNetCore.Blazor.Services;
using BlazorTests.Client.Services;
using BlazorTests.Client.Shared;

namespace BlazorTests.Client
{
    public class EditComponentWrapperComponent : BlazorComponent
    {
        #region Propriétés bindées

        [Parameter]
        protected RenderFragment ChildContent { get; set; }

        [Parameter]
        protected string Title { get; set; }

        [Parameter]
        private Action SaveAction { get; set; }

        [Parameter]
        private Action CloseAction { get; set; }

        #endregion

        #region  Sauvegarde / Femreture

        protected void Save()
        {
            SaveAction.Invoke();
        }

        protected void Close()
        {
            CloseAction.Invoke();
        }

        #endregion
    }
}
