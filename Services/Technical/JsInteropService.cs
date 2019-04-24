

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorTests.Services
{
    public class JsInteropService : ComponentBase
    {
        /// <summary>
        /// ATTENTION : JSRuntime n'est pas en l'état "injectable" dans une classe autre qu'un composant. 
        /// => on définit la propriété dans le 1er composant de l'application à savoir MainLayout
        /// </summary>
        //public static IJSRuntime JSRuntime { get; set; }

        [Inject]
        public static IJSRuntime JSRuntime { get; set; }

        public static async Task ReturnToCallerPage()
        {
            await JSRuntime.InvokeAsync<string>("JavascriptFunctions.returnToCallerPage");
        }

        public static async Task ShowAlert(string message)
        {
            await JSRuntime.InvokeAsync<string>("JavascriptFunctions.showAlert", message);
        }

        public static async Task InitTable(string tableId)
        {
            await JSRuntime.InvokeAsync<string>("JavascriptFunctions.initTable", tableId);
        }
    }
}