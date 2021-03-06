using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Rocky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Category { set; get; }
        public DbSet<ApplicationType> ApplicationType { set; get; }
        public DbSet<Product> Product { set; get; }
        public DbSet<ApplicationUser> ApplicationUser { set; get; }
    }
}
