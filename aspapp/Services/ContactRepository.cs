using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;
using AspApp.Data;
using Microsoft.EntityFrameworkCore;
using AspApp.Interfaces;
using AutoMapper;
using AspApp.DTO.Contact;

namespace AspApp.Services
{
    public class ContactRepository: IContactRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;



        public ContactRepository(DatabaseContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<List<ContactDto>> GetContacts()
        {
            var _contacts =  await _context.Contacts.ToListAsync();

            var contactdtos =  _mapper.Map<List<ContactDto>>(_contacts);
            foreach(ContactDto clientdto in contactdtos)
            {
                List<LinkedClients> clients = await _context.LinkedClients.Where(x => x.ContactId == clientdto.key).ToListAsync() ;
                clientdto.LinkedClients = clients.Count;
            }
            return contactdtos;
        }

        public async Task<Contact> GetContactById(string key)
        {
            var _contact = await _context.Contacts.FirstOrDefaultAsync(x => x.key == key );
            return _contact;
        }

        public async Task<Contact> AddContact(ContactCreationDto contactCreationDto)
        {
            var contact = _mapper.Map<Contact>(contactCreationDto);
            foreach(var clientId in contactCreationDto.Clients)
            {
                LinkedClients linkContacts = new LinkedClients 
                {
                    ContactId = contact.key,
                    ClientId= clientId
                };
                await _context.LinkedClients.AddAsync(linkContacts);
            }

            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact;
        }
    }
}