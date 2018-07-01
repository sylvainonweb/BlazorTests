﻿using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorTests.Client.Services;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Layouts;

namespace BlazorTests.Client
{
    public class CustomerEditComponent : EditComponentBase
    {
        #region Services

        [Inject]
        protected CustomerService CustomerService { get; set; }

        #endregion

        #region Propriétés bindées

        public string Name { get; set; }
        public string FirstName { get; set; }
        public int CustomerTypeId { get; set; }

        public CustomerType[] CustomerTypes { get; set; }

        #endregion

        #region Initialisation

        protected override async Task OnParametersSetAsync()
        {
            this.CustomerTypes = await CustomerService.GetCustomerTypes();

            if (IsNew())
            {
                this.Title = "Ajouter un client";             
            }
            else
            {
                this.Title = "Modifier un client";

                Customer customer = await CustomerService.GetCustomer(Id.Value);
                this.Name = customer.Name;
                this.FirstName = customer.FirstName;
            }
        }

        #endregion

        #region Sauvegarde

        protected override async Task Save()
        {
            Customer customer = null;
            if (IsNew())
            {
                customer = new Customer();         
            }
            else
            {
                customer = await CustomerService.GetCustomer(Id.Value);
            }

            customer.Name = this.Name;
            customer.FirstName = this.FirstName;
            customer.CustomerTypeId = this.CustomerTypeId;

            await CustomerService.SaveCustomer(customer);
            UriHelper.NavigateTo("/customer");
        }

        protected override void Close()
        {
            UriHelper.NavigateTo("/customer");
        }

        #endregion
    }
}


