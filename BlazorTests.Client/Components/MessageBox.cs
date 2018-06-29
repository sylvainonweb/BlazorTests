using System.Net.Http;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor.Browser.Interop;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorTests.Client
{
    public class MessageBox
    {
        public static bool ShowDeletionConfirmation()
        {
            return RegisteredFunction.Invoke<bool>("showDeletionConfirmation", string.Empty);
        }

        public static bool ShowAlert(string message)
        {
            return RegisteredFunction.Invoke<bool>("showAlert", message);
        }
    }
}