using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;


namespace AspApp.Models
{
    public class Client
    {
       [Key]
       [Required]
       public string? key {get; set;}
       [Required]
       public string? Name {get; set;}
       [Required]
       public string? Code {get; set;}

    }
}