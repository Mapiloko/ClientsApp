using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;
using AspApp.Data;
using Microsoft.EntityFrameworkCore;
using AspApp.Interfaces;
using AutoMapper;
using AspApp.DTO.Client;

namespace AspApp.Services
{
    public class ClientRepository: IClientRepository
    {
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;

        public ClientRepository(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<ClientDto>> GetClients()
        {
            var _clients =  await _context.Clients.ToListAsync();
            var clientdtos =  _mapper.Map<List<ClientDto>>(_clients);
            foreach(ClientDto clientdto in clientdtos)
            {
                List<LinkdContacts> contacts = await _context.LinkdContacts.Where(x => x.ClientId == clientdto.key).ToListAsync() ;
                clientdto.LinkedContacts = contacts.Count;
            }
            return clientdtos;
        }

        public async Task<Client> GetClientById(string key)
        {
             var client = await _context.Clients.FirstOrDefaultAsync(x => x.key == key);
             return client;
        }

        public async Task<Client> AddClient(ClientCreationDto clientCreationDto)
        {
            var client = _mapper.Map<Client>(clientCreationDto);
            foreach(var contactId in clientCreationDto.Contacts)
            {
                LinkdContacts linkContacts = new LinkdContacts 
                {
                    ContactId = contactId,
                    ClientId= client.key
                };
                await _context.LinkdContacts.AddAsync(linkContacts);
            }

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return client;
            
        }
    }
}