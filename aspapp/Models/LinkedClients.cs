using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;



namespace AspApp.Models
{
    public class LinkedClients
    {
       public string? ContactId {get; set;}
       public string? ClientId {get; set;}

    }
}