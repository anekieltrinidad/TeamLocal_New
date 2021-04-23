using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TeamLocal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace TeamLocal.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Business> Businesses { get; set; }

        public DbSet<CategoryBusiness> CategoryBusinesses { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<TeamLocal.Models.ProjectRole> ProjectRole { get; set; }

        
    }
}