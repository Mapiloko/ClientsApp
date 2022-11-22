using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;
using AspApp.Data;
using AspApp.DTO.Contact;
using AspApp.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _repo;
        private readonly DatabaseContext _context;
        private readonly IMapper _mapper;
        public ContactController(IContactRepository repo, DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<ContactDto>>> Get()
        {
            // var client = _mapper.Map<Client>(clientCreationDto);
            // var genres =  await _context.UserContacts.ToListAsync();

            var contacts =  await _repo.GetContacts();

            return _mapper.Map<List<ContactDto>>(contacts);
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ContactDto>> Get(int id)
        {
            var genre = await _context.UserContacts.FirstOrDefaultAsync(x => x.Id == id );
            if(genre == null)
            {
                return NotFound();
            }
            return _mapper.Map<ContactDto>(genre);
        }

        [HttpPost]
         public ActionResult Post([FromBody] ContactCreationDto contactCreationDto)
         {
            var contact = _mapper.Map<Contact>(contactCreationDto);

            _repo.AddContact(contact);

           return NoContent();
         }

         [HttpPut("{id:int}")]
         public async Task<ActionResult> Put(int id, [FromBody] ContactCreationDto genreCreationDto)
         {
            var genre = _mapper.Map<Contact>(genreCreationDto);
            genre.Id = id;

            _context.Entry(genre).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            return NoContent();
         }

         [HttpDelete("{id:int}")]
         public async Task<ActionResult> Delete(int id)
         {
            var genre = await _context.UserContacts.FirstOrDefaultAsync(x => x.Id == id);

            if(genre == null)
            {
                return NotFound();
            }
            _context.Remove(genre);
            await _context.SaveChangesAsync();
            return NoContent();
         }

    }
}