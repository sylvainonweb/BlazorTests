using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Components.Shared.Core
{
    public class RequiredExAttribute : Attribute
    {
        public string Label { get; set; }

        public RequiredExAttribute(string label)
        {
            this.Label = label;
        }
    }
}
