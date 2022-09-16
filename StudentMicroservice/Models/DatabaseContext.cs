using Microsoft.EntityFrameworkCore;


namespace StudentMicroservice.Models
{
    public class DatabaseContext : DbContext
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

        public DbSet<StudentDetails> StudentsDetails { get; set; }
    }
}
