using System.Net.Http;
using System.Threading.Tasks;
using BlazorTests.Shared;
using Microsoft.AspNetCore.Blazor.Components;
using Microsoft.AspNetCore.Blazor.Services;

namespace BlazorTests.Client
{
    public abstract class EditComponentBase : ComponentBase
    {
        [Parameter]
        private string IdAsString { get; set; }

        public int? Id
        {
            get
            {
                if (string.IsNullOrWhiteSpace(IdAsString))
                {
                    return null;
                }

                return int.Parse(IdAsString);
            }
        }

        protected bool IsNew()
        {
            if (Id.HasValue == false)
            {
                return true;
            }

            return false;
        }

        protected abstract Task Save();
        protected abstract void Close();
    }
}