using Markt10.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markt10.DataAccess.Data
{
    public class Markt10DbContext:IdentityDbContext
    {
        public Markt10DbContext(DbContextOptions<Markt10DbContext> options): base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Trademark> Trademarks { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Accessory> Accessories { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Housefold> Housefolds { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<TV> TVs { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
