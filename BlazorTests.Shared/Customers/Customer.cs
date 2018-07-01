using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorTests.Shared
{
    public class CustomerBase
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public int CustomerTypeId { get; set; }
    }

    public class Customer : CustomerBase
    {
        public int Id { get; set; }
        public string CustomerTypeText { get; set; }
    }

    public class EditableCustomer : CustomerBase
    {
        public int? Id { get; set; }
    }

    public class CustomerType
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }
}
