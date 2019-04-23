﻿using BlazorTests.Components.Shared;
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
                return StringToNullableIntConverter.ConvertToInt(IdAsString);
            }
            set
            {
                this.IdAsString = StringToNullableIntConverter.ConvertToString(value);
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