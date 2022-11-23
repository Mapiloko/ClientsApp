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
        public string? key {get; set;}
        public string? Name {get; set;}
        public string? SurName {get; set;}
        public string? Email {get; set;}
    }
}