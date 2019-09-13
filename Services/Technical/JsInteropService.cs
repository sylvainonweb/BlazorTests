

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace BlazorTests.Services
{
    /// <summary>
    /// Afin que cette classe fonctionne, il faut :
    /// 
    /// * ajouter les fonctions javascripts dans le fichier wwwroot\js\site.js
    /// 
    /// * ajouter la ligne suivante dans la partie body du fichier Pages\_Host.cshtml
    ///     <script type='text/javascript' src="js/site.js"></script>
    ///     
    /// * ajouter le code suivant dans Startup.ConfigureServices()
    ///     services.AddSingleton<JsInteropService>();
    ///     
    /// * ajouter le code suivant dans MainLayout
    /// 
    ///    @inject BlazorTests.Services.Technical.JsInteropService JsInteropService
    ///    @inject Microsoft.JSInterop.IJSRuntime JSRuntime
    /// 
    ///     @code {
    ///       protected override void OnInitialized()
    ///       {
    ///          // JSRuntime n'�tant pas injectable dans une classe qui n'est pas un composant,
    ///          // on utilise le 1er composant de l'application pour d�finir manuellement la propri�t�
    ///          // statique de JsInteropService.
    ///          BlazorTests.Services.Technical.JsInteropService.JSRuntime = JSRuntime;
    ///       }
    /// => Penser � ne pas utiliser une instance de classe vu que les m�thodes sont statiques
    /// 
    /// </summary>
    public class JsInteropService : ComponentBase
    {
        /// <summary>
        /// ATTENTION : JSRuntime n'est pas en l'�tat "injectable" dans une classe autre qu'un composant. 
        /// => on d�finit la propri�t� dans le 1er composant de l'application � savoir MainLayout
        /// </summary>
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