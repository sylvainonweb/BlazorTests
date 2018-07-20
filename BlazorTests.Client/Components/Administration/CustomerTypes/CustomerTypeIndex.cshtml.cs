using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using BlazorTests.Client.Services;
using BlazorTests.Client.Controls;

namespace BlazorTests.Client
{
    public class CustomerTypeIndexComponent : ComponentBase
    {
        #region Services

        [Inject]
        protected AdministrationService AdministrationService { get; set; }

        #endregion

        #region Propriétés bindées

        protected IList<CustomerType> CustomerTypes { get; set; } = new List<CustomerType>();

        #endregion

        #region Initialisation

        protected override async Task OnInitAsync()
        {
            this.Title = "Types de client";
            await LoadCustomerTypes();
        }
        
        #endregion

        #region  Gestion des types de clients

        protected void AddCustomerType()
        {
            UriHelper.NavigateTo($"/Administration/CustomerType/Edit");
        }

        protected void EditCustomerType(int id)
        {
            UriHelper.NavigateTo($"/Administration/CustomerType/Edit/{id}");
        }

        protected async Task DeleteCustomerType(int customerTypeId)
        {
            if (MessageBox.ShowDeletionConfirmation())
            {
                await AdministrationService.DeleteCustomerType(customerTypeId);
                MessageBox.ShowAlert("Suppression effectuée");

                LoadCustomerTypes();
            }
        }

        protected async Task LoadCustomerTypes()
        {
            this.CustomerTypes = await AdministrationService.GetCustomerTypes();
            StateHasChanged();
        }

        #endregion
    }
}
