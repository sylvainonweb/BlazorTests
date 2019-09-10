﻿using BlazorTests.Shared;
using Microsoft.AspNetCore.Components;
using BlazorTests.Core.Converters;

namespace BlazorTests.Core
{
    public abstract class DetailPageComponentBase : PageComponentBase
    {
        [Parameter]
        public string IdAsString { get; set; }

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