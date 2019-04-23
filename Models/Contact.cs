using System;

namespace BlazorTests.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public int? CompanyId { get; set; }
    }
}
