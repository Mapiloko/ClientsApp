using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;
using AspApp.Data;
using Microsoft.EntityFrameworkCore;
using AspApp.Interfaces;

namespace AspApp.Services
{
    public class ContactRepository: IContactRepository
    {
        // private List<Contact> _contacts;
        private readonly DatabaseContext _context;


        public ContactRepository(DatabaseContext context)
        {
            _context = context;
            // _contacts = new List<Contact>()
            // {
            //     new Contact(){Id = 1, Name = "Action"},
            //     new Contact(){Id = 2, Name = "Comedy"}
            // };
        }
        public async Task<List<Contact>> GetContacts()
        {
            var _contacts =  await _context.UserContacts.ToListAsync();
            return _contacts;
        }

        public async Task<Contact> GetContactById(int id)
        {
            var _contact = await _context.UserContacts.FirstOrDefaultAsync(x => x.Id == id );
            return _contact;
        }

        public async Task AddContact(Contact contact)
        {
             _context.UserContacts.Add(contact);
             await _context.SaveChangesAsync();
        }
    }
}