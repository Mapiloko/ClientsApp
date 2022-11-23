using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;
using Microsoft.EntityFrameworkCore;


namespace AspApp.Models
{
    public class LinkdContacts
    {
       public string? ClientId {get; set;}
       public string? ContactId {get; set;}

    }
}