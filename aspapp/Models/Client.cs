using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;


namespace AspApp.Models
{
    public class Client
    {
       public int Id {get; set;}
       public string? Name {get; set;}
       public string? Code {get; set;}

       public int? LinkedContacts {get; set;}

       public ICollection<Contact> Contacts {get; set;}

    }
}