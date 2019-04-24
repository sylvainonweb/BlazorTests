using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorTests.Data
{
    public class CompanyEntity
    {
        // [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ActivityId { get; set; }
    }
}
