using System;

namespace BlazorTests.Models
{
    public class ContactView
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public int? CivilityId { get; set; }
        public string CivilityText { get; set; }

        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
