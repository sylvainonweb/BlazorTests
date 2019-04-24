using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Components.Shared.Core
{
    /// <summary>
    /// On pourrait utiliser Required mais lors de la validation, le message reprend le nom de la propriété et pas un libellé "français"
    /// </summary>
    public class RequiredExAttribute : Attribute
    {
        public string Label { get; set; }

        public RequiredExAttribute(string label)
        {
            this.Label = label;
        }
    }
}
