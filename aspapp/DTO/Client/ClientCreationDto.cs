using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspApp.DTO.Client
{
    public class ClientCreationDto
    {

        public string? key {get; set;}
        public string? Name {get; set;}

        public string? Code {get; set;}
        public IEnumerable<string>? Contacts {get; set;}


    }
}