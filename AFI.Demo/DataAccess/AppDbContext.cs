using Microsoft.EntityFrameworkCore;

namespace AFI.Demo.DataAccess;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => new { e.Id });
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.Surname).IsRequired();
            entity.Property(e => e.PolicyReference).IsRequired();
        });
    }
}
