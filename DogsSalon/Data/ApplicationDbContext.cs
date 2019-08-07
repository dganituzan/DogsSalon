using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DogsSalon.Models;

namespace DogsSalon.Data
{
    public class ApplicationDbContext : IdentityDbContext<User,Role, string >
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> orders { get; set; }
    }
}
