using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspApp.DTO.Contact
{
    public class ContactDto
    {
        public int Id {get; set;}
        public string? Name {get; set;}
        public string? SurName {get; set;}
        public string? Email {get; set;}
        public int? LinkedClients {get; set;}

    }
}