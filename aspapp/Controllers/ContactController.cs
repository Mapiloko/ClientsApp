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
        public ContactController(IContactRepository repo, DatabaseContext context)
        {
            _context = context;
            _repo = repo;

        }

        [HttpGet]
        public async Task<ActionResult<List<ContactDto>>> Get()
        {
            var contacts =  await _repo.GetContacts();
            return contacts;
        }

        [HttpPost]
         public async Task<IActionResult> Post([FromBody] ContactCreationDto contactCreationDto)
         {
            var contact = await _repo.AddContact(contactCreationDto);

           return Ok(contact);
         }

    }
}