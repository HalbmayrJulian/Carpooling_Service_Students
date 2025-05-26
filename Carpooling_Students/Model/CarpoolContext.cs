using Carpooling_Students.Model;
using Microsoft.EntityFrameworkCore;

public class CarpoolContext : DbContext
{
    public DbSet<Person> Personen { get; set; }
    public DbSet<Routen> Routen { get; set; }
    public DbSet<Fahrt> Fahrten { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Item> Items { get; set; }

    public CarpoolContext(DbContextOptions<CarpoolContext> options) : base(options)
    {
    }
}
