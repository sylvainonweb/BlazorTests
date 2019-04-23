using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Services;
using BlazorTests.Services;
using System;

namespace BlazorTests.Components.Shared
{
    public class NullableDateTimeConverter
    {
        private static DateTime NullValue = DateTime.MinValue;

        public static DateTime ConvertToDateTime(DateTime? value)
        {
            return value.GetValueOrDefault(NullValue);

        }

        public static DateTime? ConvertToNullableDateTime(DateTime value)
        {
            if (value == NullValue)
            {
                return null;
            }
            else
            {
                return value;
            }
        }
    }
}