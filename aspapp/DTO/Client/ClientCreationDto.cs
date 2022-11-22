using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspApp.DTO.Client
{
    public class ClientCreationDto
    {
        public string? Name {get; set;}

        public int? LinkedContacts {get; set;}
        public string? Code {get; set;}

    }
}