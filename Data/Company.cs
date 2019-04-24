using System;

namespace BlazorTests.Data
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? ActivityId { get; set; }
        public string ActivityText { get; set; }
    }
}
