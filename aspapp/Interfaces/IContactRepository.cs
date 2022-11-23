using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.DTO.Contact;
using AspApp.Models;

namespace AspApp.Interfaces
{
    public interface IContactRepository
    {
        Task<List<ContactDto>> GetContacts();
        Task<Contact> GetContactById(string id);
        Task<Contact> AddContact(ContactCreationDto contact);
    }
}