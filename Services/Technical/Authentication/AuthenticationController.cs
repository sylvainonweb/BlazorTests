using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlazorTests.Services.Technical.Authentication
{
    /// <summary>
    /// L'authentification ne peut être géré depuis un composant Blazor.
    /// 
    /// En effet, si on place le code des fonctions Login et Logout dans un composant Blazor, l'erreur suivante est déclenchée
    ///     "The response headers cannot be modified because the response has already started"
    /// 
    /// Cette erreur est du au fait que les fonctions de SignInManager (PasswordSignInAsync et SignOutAsync) essaye de modifier
    /// l'entête de la requête HTTP afin d'ajouter/supprimer le cookie d'authentification. Or, Blazor côté serveur étant basé
    /// sur l'utilisation de SignalR et non de requêtes HTTP, il lui est impossible (actuellement) d'effectuer cette opération.
    /// 
    /// Pour contourner le problème, il faut
    /// * exposer les services Login et Logout depuis un controller
    /// * appeler ces services via http. 
    ///     Attention, l'utilisation de HttpClient.PostAsync ne fonctionne pas (je ne sais pas vraiment pourquoi)
    ///     Du coup, j'appelle les services via un submit form de type post comme indiqué dans le très bon article suivant
    ///     https://www.oqtane.org/Resources/Blog/PostId/527/exploring-authentication-in-blazor
    /// </summary>
    public class AuthenticationController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> SignInManager;

        public AuthenticationController(SignInManager<IdentityUser> signInManager)
        {
            this.SignInManager = signInManager;
        }

        [HttpPost("/login")]
        public async Task<IActionResult> Login([FromForm]string username, [FromForm] string password)
        {
            // Attention, la propriété PasswordHash de user ne doit pas être définie sinon SignInManager.PasswordSignInAsync retournera toujours 'Failed'
            var result = await SignInManager.PasswordSignInAsync(username, password, true, lockoutOnFailure: false);
            if (result == Microsoft.AspNetCore.Identity.SignInResult.Failed)
            {
                return Redirect("/login");
            }
            else
            {
                return Redirect("/");
            }
        }

        [HttpPost("/logout")]
        public async Task<IActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
