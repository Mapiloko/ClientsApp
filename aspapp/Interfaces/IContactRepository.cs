using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;

namespace AspApp.Interfaces
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContacts();
        Task<Contact> GetContactById(int id);
        Task AddContact(Contact contact);
    }
}