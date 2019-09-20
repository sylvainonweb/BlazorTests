using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorTests.Pages.Tests
{
    public class DropDownListItem
    {
        public int? Id { get; set; }
        public string Text { get; set; }
    }

    /// <summary>
    /// Nécessaire pour gérer les nullables
    /// </summary>
    public class DropDownListItemHelper
    {
        public static IList<DropDownListItem> Convert<T>(IList<T> data, Action<T, DropDownListItem> transformation, bool addEmptyLine = true)
        {
            IList<DropDownListItem> items = new List<DropDownListItem>();
            if (addEmptyLine)
            {
                items.Add(new DropDownListItem { Id = default(int?), Text = string.Empty });
            }

            foreach (T datum in data)
            {
                DropDownListItem item = new DropDownListItem();
                transformation.Invoke(datum, item);
                items.Add(item);
            }

            return items;
        }
    }
}
