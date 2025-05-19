using Carpooling_Students.Model;
using Microsoft.EntityFrameworkCore;

public class CarpoolContext : DbContext
{
    public DbSet<Person> Personen { get; set; }
    public DbSet<Routen> Routen { get; set; }
    public DbSet<Fahrt> Fahrten { get; set; }
    public DbSet<Autofahrt> Autofahrten { get; set; }
    public DbSet<AlternativeFahrt> AlternativeFahrten { get; set; }
    public DbSet<AutofahrtPassagier> AutofahrtPassagiere { get; set; }
    public DbSet<Shop> Shops { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=./carpool.db;");
    }
}
