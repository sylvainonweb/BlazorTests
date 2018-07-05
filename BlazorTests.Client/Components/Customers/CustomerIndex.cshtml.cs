using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor;
using Microsoft.AspNetCore.Blazor.Components;
using BlazorTests.Client.Services;
using BlazorTests.Client.Shared;
using BlazorTests.Client.Controls.SelectList;

namespace BlazorTests.Client
{
    public class CustomerIndexComponent : ComponentBase
    {
        #region Services

        [Inject]
        protected AdministrationService AdministrationService { get; set; }

        [Inject]
        protected CustomerService CustomerService { get; set; }

        #endregion

        #region Propriétés bindées

        protected IList<Customer> Customers { get; set; } = new List<Customer>();
        protected IList<SelectListItem> CustomerTypes { get; set; } = new List<SelectListItem>();
        protected int CustomerTypeId { get; set; }

        #endregion

        #region Initialisation

        protected override async Task OnInitAsync()
        {
            this.Title = "Clients";
            this.CustomerTypes = SelectListItems.Convert(await AdministrationService.GetCustomerTypes(), (src, dest) =>
            {
                dest.Id = src.Id;
                dest.Text = src.Text;
            });
            await LoadCustomers();
        }

        #endregion

        #region  Gestion des clients

        protected void AddCustomer()
        {
            UriHelper.NavigateTo($"/Customer/Edit");
        }

        protected void EditCustomer(int id)
        {
            UriHelper.NavigateTo($"/Customer/Edit/{id}");
        }

        protected async Task DeleteCustomer(int customerId)
        {
            if (MessageBox.ShowDeletionConfirmation())
            {
                await CustomerService.DeleteCustomer(customerId);
                MessageBox.ShowAlert("Suppression effectuée");

                LoadCustomers();
            }
        }

        protected async Task LoadCustomers()
        {
            this.Customers = await CustomerService.GetCustomers(GetNullableInt(this.CustomerTypeId));
            StateHasChanged();
        }

        #endregion

        #region Evénements

        protected void OnCustomerTypeChanged(UIChangeEventArgs e)
        {
            System.Console.WriteLine($"e.Value = {e.Value.ToString()}");
            CustomerTypeId = int.Parse(e.Value.ToString());

            LoadCustomers();
        }

        #endregion
    }
}
