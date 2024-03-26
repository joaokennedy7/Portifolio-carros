using Microsoft.EntityFrameworkCore;
using PortifolioCarros.API.Entities;

namespace PortifolioCarros.API.Persistence.SqlServer
{
    public class PortifolioContext(DbContextOptions<PortifolioContext> options) : DbContext(options)
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Picture> Picture { get; set; }
    }
}
