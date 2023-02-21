using Microsoft.EntityFrameworkCore;

namespace CopyCost.TS.WPF.Core.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Payment> Payments { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Customer> Customers { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Payment>()
            .HasOne(p => p.Category)
            .WithMany(p => p.Payments)
            .HasForeignKey(p => p.CategoryId);
        modelBuilder.Entity<Customer>()
            .HasMany(c=>c.Payments)
            .WithOne(p=>p.Customer)
            .HasForeignKey(p=>p.CustomerId);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=MyDb.db");
        base.OnConfiguring(optionsBuilder);
    }
}