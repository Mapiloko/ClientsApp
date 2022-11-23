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
        private readonly DatabaseContext _context;


        public ClientRepository(DatabaseContext context)
        {
            _context = context;
        }
        public async Task<List<Client>> GetClients()
        {
            var _clients =  await _context.Clients.ToListAsync();
            return _clients;
        }

        public async Task<Client> GetClientById(int id)
        {
             var client = await _context.Clients.FirstOrDefaultAsync(x => x.Id == id );
             return client;
        }

        public async Task AddClient(Client client)
        {
            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();
            
        }
    }
}