using Microsoft.AspNetCore.Components;

namespace BlazorTests.Components
{
    public abstract class DetailPageComponentBase : PageComponentBase
    {
        [Parameter]
        protected string IdAsString { get; set; }

        protected int? Id
        {
            get
            {
                if (string.IsNullOrWhiteSpace(IdAsString))
                {
                    return null;
                }

                return int.Parse(IdAsString);
            }
            set
            {
                this.IdAsString = value != null ? value.ToString() : null;
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
    }
}