using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using CarServiceApp_backend.Models;

namespace CarServiceApp_backend.Services
{
    public class ApplicationContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<UsersRole> Roles { get; set; }
    public ApplicationContext()
    {
        //Database.EnsureDeleted();
        //Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Ignore<Company>();
        modelBuilder.Entity<UsersRole>()
        .HasIndex(b => b.Name)
        .IsUnique().HasDatabaseName("Index_NamesRole");
        modelBuilder.Entity<User>()
        .HasIndex(b => b.Email)
        .IsUnique().HasDatabaseName("Index_EmailsUser");
    }
     
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=bvljmvwt670wbtkrd1bd-postgresql.services.clever-cloud.com;Port=5432;Database=bvljmvwt670wbtkrd1bd;Username=ukzplhnfcik1h61gcmfr;Password=UWwe6nNtVMLFYuhwCwNU");
    }
}
}