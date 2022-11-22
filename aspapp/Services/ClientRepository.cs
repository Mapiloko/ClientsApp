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
    public class ClientRepository: IClientRepository
    {
        // private List<Contact> _contacts;
        private readonly DatabaseContext _context;


        public ClientRepository(DatabaseContext context)
        {
            _context = context;
            // _clients = new List<Client>()
            // {
            //     new Client(){Id = 1, Name = "Action"},
            //     new Client(){Id = 2, Name = "Comedy"}
            // };
        }
        public async Task<List<Client>> GetClients()
        {
            var _clients =  await _context.UserClients.ToListAsync();
            return _clients;
        }

        public async Task<Client> GetClientById(int id)
        {
             var client = await _context.UserClients.FirstOrDefaultAsync(x => x.Id == id );
             return client;
        }

        public async Task AddClient(Client client)
        {
            _context.UserClients.Add(client);

            await _context.SaveChangesAsync();
            // client.Id = _clients.Max(x => x.Id) + 1;
            // _clients.Add(client);
        }
    }
}