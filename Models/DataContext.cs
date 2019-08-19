using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryService.Models {
    public class DataContext : DbContext{
public DataContext(DbContextOptions<DataContext> opts)
    : base(opts){}
    public DbSet<Food> Foods {get; set;}
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Rating> Ratings { get; set; }
    //This is our delete method using modelbuilder. When we delete, we also deleted related info
    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Food>().HasMany<Rating>(m => m.Ratings)
            .WithOne(r => r.Food).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Food>().HasOne<Address>(m => m.Address)
            .WithMany(s => s.Foods).OnDelete(DeleteBehavior.SetNull);
        }
    }
}