using Microsoft.EntityFrameworkCore;
using Pattern;

namespace DataBank;

public class DBConnectionContext : DbContext
           {
    public DbSet<Users> User { get; set; }  
    public DbSet<Game> Games { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalItem> RentalItems { get; set; }
    public DbSet<Fine> Fines { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Category>Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlite("Data Source=database.db");
    }
}