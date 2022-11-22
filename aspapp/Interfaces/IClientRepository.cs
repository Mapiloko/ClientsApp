using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;

namespace AspApp.Interfaces
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClientById(int id);
        Task AddClient(Client genre);
    }
}