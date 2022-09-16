using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthorizationMicroservice.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext() { }
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-A6G2G4CS\\DATABASES_DOTNET;Initial Catalog=PlacementSystem;Integrated Security=True");
            }

        }


        public DbSet<LoginDetail> LoginDetails { get; set; }
    }
}
