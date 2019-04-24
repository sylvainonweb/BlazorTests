using BlazorTests.Components.Shared.Core;
using BlazorTests.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

namespace BlazorTests.Components
{
    public abstract class EditablePageComponentBase : DetailPageComponentBase
    {
        [Inject]
        public ToastService ToastService { get; set; }

        #region Gestion de la sauvegarde

        protected async Task Save()
        {
            IList<string> errors = CheckRequiredFields();
            if (errors.Count > 0)
            {
                ToastService.ShowToast(string.Join("\r\n", errors), ToastLevel.Error);
                //await JsInteropService.ShowAlert(string.Join("\r\n", errors));
            }
            else
            {
                await OnSave();
                await OnAfterSave();
            }

            return;
        }

        protected abstract Task OnSave();
        protected virtual Task OnAfterSave()
        {
            return Task.FromResult(0);
        }

        #endregion

        #region Gestion de l'annulation

        protected virtual async Task Cancel()
        {
            // Pour 2 méthodes (Cancel et OnCancel) ?
            // => pour être identique à Save et OnSave
            await OnCancel();
        }

        protected abstract Task OnCancel();

        #endregion

        #region Vérification des champs obligatoires

        protected IList<string> CheckRequiredFields()
        {
            IList<string> errors = new List<string>();

            PropertyInfo[] infos = this.GetType().GetProperties();
            if (infos != null)
            {
                foreach (var info in infos)
                {
                    var requiredAttribute = info.GetCustomAttribute(typeof(RequiredExAttribute), true) as RequiredExAttribute;
                    if (requiredAttribute != null)
                    {
                        object o = info.GetValue(this);
                        if (CheckRequiredField(o) == false)
                        {
                            errors.Add($"Le champ {requiredAttribute.Label} est obligatoire");
                        }
                    }
                }
            }

            return errors;
        }

        private bool CheckRequiredField(object value)
        {
            if (value == null)
            {
                return false;
            }
            else
            {
                // Dans le cas d'une cha�ne, on v�rifie aussi qu'elle n'est pas vide
                if (value is string && string.IsNullOrWhiteSpace((string)value))
                {
                    return false;
                }

                // Dans le cas d'une liste, on v�rifie aussi qu'elle contient un �l�ment
                if (value is IList && ((IList)value).Count == 0)
                {
                    return false;
                }
            }

            return true;
        }

        protected IList<string> GetPropertyInfos()
        {
            IList<string> propertyNames = new List<string>();

            PropertyInfo[] infos = this.GetType().GetProperties(BindingFlags.Instance);
            if (infos != null)
            {
                foreach (PropertyInfo info in infos)
                {
                    propertyNames.Add(info.Name);
                }
            }

            return propertyNames;
        }

        #endregion
    }
}