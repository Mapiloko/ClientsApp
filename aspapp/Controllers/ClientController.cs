using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Data;
using AspApp.DTO.Client;
using AspApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspApp.Interfaces;


namespace AspApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController: ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IClientRepository _repo;

        public ClientController(IClientRepository repo, DatabaseContext context)
        {
            _context = context;
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> Get()
        {
            var clients =  await _repo.GetClients();
            return clients;
        }

        [HttpPost]
         public async Task<IActionResult> Post([FromBody] ClientCreationDto clientCreationDto)
         {

            var client = await _repo.AddClient(clientCreationDto);

           return Ok(client);
         }        
    }
}