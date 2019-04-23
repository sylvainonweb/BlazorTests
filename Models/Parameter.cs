using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorTests.Models
{
    public class Parameter
    {
        //[Required]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }
    }
}