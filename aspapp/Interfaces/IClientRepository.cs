using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;
using AspApp.DTO.Client;


namespace AspApp.Interfaces
{
    public interface IClientRepository
    {
        Task<List<ClientDto>> GetClients();
        Task<Client> GetClientById(string id);
        Task<Client> AddClient(ClientCreationDto genre);
    }
}