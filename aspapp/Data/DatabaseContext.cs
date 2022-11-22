using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AspApp.Models;
using AspApp.Models;
using Microsoft.EntityFrameworkCore;
  // "DefaultConnection": "Server=.\\SQLEXPRESS;Database=Master;Encrypt=False;Trusted_Connection=True;"


namespace AspApp.Data
{
    public class DatabaseContext: DbContext
    {
        private readonly IConfiguration configuration;
        public DatabaseContext([NotNullAttribute] DbContextOptions options, IConfiguration configuration) : base (options)
        {
            this.configuration = configuration;

        }

        public DbSet<Contact> UserContacts {get; set;}
        public DbSet<Client> UserClients {get; set;}
        
    }
}