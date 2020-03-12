using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorTests.Data;
using BlazorTests.Services;
using System.Threading;
using EmbeddedBlazorContent;
using MatBlazor;
using System.Net.Http;
using BlazorTests.Services.Technical.Authentication;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace BlazorTests
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            // SBD : Syncfusion
            services.AddScoped<Syncfusion.EJ2.Blazor.SyncfusionBlazorService>();

            // SBD : Telerik
            services.AddTelerikBlazor();

            // SBD : Telerik
            services.AddScoped<MatToastConfiguration>();
            services.AddScoped<IMatToaster, MatToaster>();

            // SBD : Services techniques
            services.AddSingleton<JsInteropService>();
            services.AddScoped<ToastService>();
            services.AddAuthenticationServices();

            // SBD : Services métier
            services.AddSingleton<Repository>();
            services.AddSingleton<CompanyService>();
            services.AddSingleton<ContactService>();
            services.AddSingleton<ReferenceService>();

            services.AddSingleton<ParameterService>();

            // Afin d'afficher le détail des erreurs
            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider serviceProvider)
        {
            var userInitializer = (IdentityUserStoreInitializer)serviceProvider.GetService(typeof(IdentityUserStoreInitializer));
            userInitializer.CreateUsers();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Nécessaire pour MatBlazor
            app.UseEmbeddedBlazorContent(typeof(MatBlazor.BaseMatComponent).Assembly);

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            // Pour l'authentification
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");

                // Pour l'authentification
                endpoints.MapControllers();
            });
        }
    }

    public static class DependencyInjectionHelper
    {
        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie();

            // Nécessaire afin de pouvoir utiliser Identity pour la gestion des droits (voir AuthenticationController)
            services
              .AddIdentity<IdentityUser, IdentityRole>(
              option =>
              {
                  option.Password.RequireDigit = false;
                  option.Password.RequiredLength = 1;
                  option.Password.RequireNonAlphanumeric = false;
                  option.Password.RequireUppercase = false;
                  option.Password.RequireLowercase = false;
                  option.SignIn.RequireConfirmedEmail = false;
              })
              .AddUserStore<IdentityUserStore>()
              .AddRoleStore<IdentityRoleStore>();

            // Nécessaire pour pouvoir appeler les services web exposés par AuthenticationController
            services.AddScoped<HttpClient>(serviceProvider =>
            {
                var navigationManager = serviceProvider.GetRequiredService<NavigationManager>();
                var httpContextAccessor = serviceProvider.GetRequiredService<IHttpContextAccessor>();
                var authToken = httpContextAccessor.HttpContext.Request.Cookies[".AspNetCore.Identity.Application"];
                var client = new HttpClient(new HttpClientHandler { UseCookies = false });
                if (authToken != null)
                {
                    client.DefaultRequestHeaders.Add("Cookie", ".AspNetCore.Identity.Application=" + authToken);
                }
                client.BaseAddress = new Uri(navigationManager.BaseUri);
                return client;
            });

            services.AddScoped<IdentityUserStoreInitializer>();

            return services;
        }
    }
}
