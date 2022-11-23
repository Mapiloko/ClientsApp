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
       public string? key {get; set;}
       public string? Name {get; set;}
       public string? Code {get; set;}

    }
}