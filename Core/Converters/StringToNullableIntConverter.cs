using Microsoft.AspNetCore.Components;
using BlazorTests.Services;
using System;

namespace BlazorTests.Core.Converters
{
    public class StringToNullableIntConverter
    {
        private static string NullValue = string.Empty;

        public static int? ConvertToInt(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return null;
            }

            return int.Parse(value);
        }

        public static string ConvertToString(int? value)
        { 
            return value != null ? value.ToString() : null;
        }
    }
}