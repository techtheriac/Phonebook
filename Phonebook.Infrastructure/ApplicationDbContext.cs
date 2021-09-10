using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Phonebook.Domain.Configurations;
using Phonebook.Domain.Models;

namespace Phonebook.Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        private DbSet<Contact> Contacts { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<Contact>().HasData(
                new Contact {                   
                    FirstName = "Folake",
                    LastName = "Alabi",
                    Email = "folakealabi@gmail.com",
                    Phone = "09045689909",
                    ImageUrl = "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg",
                },
                new Contact
                {
                    FirstName = "James",
                    LastName = "Ariyo",
                    Email = "jamesariyo@gmail.com",
                    Phone = "09078976654",
                    ImageUrl = "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg",
                },
                new Contact
                {
                    FirstName = "Kolaq",
                    LastName = "Alagbo",
                    Email = "kolaqalagbo@gmail.com",
                    Phone = "09045689978",
                    ImageUrl = "https://res.cloudinary.com/techtheriac/image/upload/v1629663368/Products/hats/baseballyellow/other-03_yw2jht.jpg",
                }
              );
        }
        
    }
}
