

using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorTests.Helpers
{
    public static class JavascriptFunctions
    {
        public static Task<string> ShowAlert(IJSRuntime jsRuntime, string message)
        {
            return jsRuntime.InvokeAsync<string>("JavascriptFunctions.showAlert", message);
        }

        public static Task<string> InitTable(IJSRuntime jsRuntime, string tableId)
        {
            return jsRuntime.InvokeAsync<string>("JavascriptFunctions.initTable", tableId);
        }
    }
}