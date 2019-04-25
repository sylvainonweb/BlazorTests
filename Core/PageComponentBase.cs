using Microsoft.AspNetCore.Components;
using BlazorTests.Services;
using System.Threading.Tasks;

namespace BlazorTests.Core
{
    public abstract class PageComponentBase : ComponentBaseEx
    {
        public string Title { get; set; }

        protected async Task ReturnToCallerPage()
        {
            // Vu que cela utilise l'historique de navigation, cela ne peut pas fonctionner correctement.
            // Exemple : 
            // CompanyListView
            // Clic sur bouton Modifier => CompanyDetailView
            // Clic sur bouton Modifier => CompanyEditView
            // Clic Sur bouton Fermer   => CompanyDetailView
            // Clic Sur bouton Fermer   => CompanyEditView et pas CompanyListView
            // Une solution serait de passer en paramètre à la page la fonction à exécuter en cas de fermeture
            // => l'url pourrait alors changer selon l'appelant
            await JsInteropService.ReturnToCallerPage();
        }
    }
}