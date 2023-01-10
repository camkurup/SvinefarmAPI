using Microsoft.EntityFrameworkCore;
using SvinefarmAPI.Model;

namespace SvinefarmAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("ThePigFarm"));
        }

        public DbSet<LightModel> LightLog { get; set; }
        public DbSet<TemperatureModel> TemperatureLog { get; set; }
    }
}
