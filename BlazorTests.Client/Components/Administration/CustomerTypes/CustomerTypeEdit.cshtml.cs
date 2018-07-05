using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTests.Client.Services;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;

namespace BlazorTests.Client
{
    public class CustomerTypeEditComponent : EditComponentBase
    {
        #region Services

        [Inject]
        protected AdministrationService AdministrationService { get; set; }

        #endregion

        #region Propriétés bindées

        protected string Text { get; set; }

        #endregion

        #region Initialisation

        protected override async Task OnParametersSetAsync()
        {
            if (IsNew())
            {
                this.Title = "Ajouter un type de client";             
            }
            else
            {
                this.Title = "Modifier type de client";

                CustomerType customerType = await AdministrationService.GetCustomerType(Id.Value);
                this.Text = customerType.Text;
            }
        }

        #endregion

        #region Sauvegarde

        protected override async Task Save()
        {
            CustomerType customerType = null;
            if (IsNew())
            {
                customerType = new CustomerType();         
            }
            else
            {
                customerType = await AdministrationService.GetCustomerType(Id.Value);
            }

            customerType.Text = this.Text;

            await AdministrationService.SaveCustomerType(customerType);
            UriHelper.NavigateTo("/Administration/CustomerType");
        }

        protected override void Close()
        {
            UriHelper.NavigateTo("/Administration/CustomerType");
        }

        #endregion
    }
}


