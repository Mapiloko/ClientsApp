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
        private readonly IMapper _mapper;
        private readonly IClientRepository _repo;

        public ClientController(IClientRepository repo, DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<ClientDto>>> Get()
        {
            // var client =  await _context.UserClients.ToListAsync();
            var clients =  await _repo.GetClients();

            return _mapper.Map<List<ClientDto>>(clients);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ClientDto>> Get(int id)
        {
            
            var client =  await _repo.GetClientById(id);
            if(client == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClientDto>(client);
        }

        [HttpPost]
         public async Task<IActionResult> Post([FromBody] ClientCreationDto clientCreationDto)
         {
            var client = _mapper.Map<Client>(clientCreationDto);

            await _repo.AddClient(client);

           return Ok(client);
         }

         [HttpPut("{id:int}")]
         public async Task<ActionResult> Put(int id, [FromBody] ClientCreationDto clientCreationDto)
         {
            var client = _mapper.Map<Client>(clientCreationDto);
            client.Id = id;

            _context.Entry(client).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
         }

         [HttpDelete("{id:int}")]
         public async Task<IActionResult> Delete(int id)
         {
            var client = await _context.UserClients.FirstOrDefaultAsync(x => x.Id == id);

            if(client == null)
            {
                return NotFound();
            }
            _context.Remove(client);
            await _context.SaveChangesAsync();
            return Ok(client);
         }

        
    }
}