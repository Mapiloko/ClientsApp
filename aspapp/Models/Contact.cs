using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;

namespace AspApp.Models
{
    public class Contact
    {
       [Key]
        [Required]
        public string? key {get; set;}
        [Required]
        public string? Name {get; set;}
        [Required]
        public string? SurName {get; set;}
        [Required]
        [EmailAddress]
        public string? Email {get; set;}
    }
}