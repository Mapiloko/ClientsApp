using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspApp.DTO.Contact
{
    public class ContactCreationDto
    {
        [Required]
        [StringLength(50)]
        public string? key {get; set;}
        public string? Name {get; set;}
        public string? SurName {get; set;}
        public string? Email {get; set;}
        public IEnumerable<string>? Clients {get; set;}

    }
}