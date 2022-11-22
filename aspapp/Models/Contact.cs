using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;

namespace AspApp.Models
{
    public class Contact
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? SurName {get; set;}
        public string? Email {get; set;}
        public int? LinkedClients {get; set;}
        public ICollection<Client> Clients {get; set;}

    }
}