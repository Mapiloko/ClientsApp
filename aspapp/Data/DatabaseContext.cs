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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LinkedClients>().HasKey(x=> new {x.ContactId, x.ClientId});
            modelBuilder.Entity<LinkdContacts>().HasKey(x=> new {x.ClientId, x.ContactId});
        }

        public DbSet<Contact> Contacts {get; set;}
        public DbSet<Client> Clients {get; set;}
        public DbSet<LinkedClients> LinkedClients {get; set;}
        public DbSet<LinkdContacts> LinkdContacts {get; set;}
        
    }
}