using Microsoft.EntityFrameworkCore;

namespace SvinefarmAPI.Model
{
    public class PigFarmContext : DbContext
    {
        public DbSet<LightModel> Blogs { get; set; }
        public DbSet<TemperatureModel> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=1505;Database=ThePigFarm");

    }
}
