using ecomm.Models;
using Microsoft.EntityFrameworkCore;

namespace ecomm.Data
{
    public class EcommContext : DbContext
    {
        public EcommContext() 
        {
            
        }
        public EcommContext(DbContextOptions<EcommContext> options) : base(options) 
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\Local;database=Ecomm;Encrypt=True;TrustServerCertificate=True;");

        }

        public DbSet<Category> Categories { get; set; }
    }
}
