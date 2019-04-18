using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorTests.Models
{
    public class Parameter
    {
        //public int Id { get; set; }
        public string Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}
