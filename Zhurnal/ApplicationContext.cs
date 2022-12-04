using Microsoft.EntityFrameworkCore;

namespace Zhurnal
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Users> Users { get; set; } = null;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Kundelik;Username=postgres;Password=mercy07;Search Path=public");
        }
    }
}
