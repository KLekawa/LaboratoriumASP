using Microsoft.EntityFrameworkCore;

namespace Lab0.Models;

public class AppDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Organization> Organizations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite(@"Data Source=e:\data\Contacts.db");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var wsei = new Organization { Id = 100, Name = "WSEI", Address = "Św. Filipa 17, Kraków" };
        modelBuilder.Entity<Organization>().HasData(wsei);
        modelBuilder.Entity<Contact>()
            .HasData(
                new Contact(){Id = 1, Email = "adam@email.com", Name = "Adam"},
                new Contact(){Id = 2, Email = "ewa@email.com", Name = "Ewa"}
            );
    }
}