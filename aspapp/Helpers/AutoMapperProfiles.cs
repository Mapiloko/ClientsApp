using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;
using AspApp.DTO.Contact;
using AspApp.DTO.Client;
using AutoMapper;

namespace AspApp.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ContactDto,Contact>().ReverseMap();
            CreateMap<ContactCreationDto,Contact>();
            CreateMap<ClientDto,Client>().ReverseMap();
            CreateMap<ClientCreationDto,Client>();
        }        
    }
}