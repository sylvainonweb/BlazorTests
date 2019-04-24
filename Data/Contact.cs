using System;

namespace BlazorTests.Data
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }

        public int? CivilityId { get; set; }
        public string CivilityText { get; set; }

        public int? CompanyId { get; set; }
        public string CompanyName { get; set; }

        public DateTime? BirthDate { get; set; }
        public bool Married { get; set; }
    }
}
