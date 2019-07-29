using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryService.Models {
    public class DataContext : DataContext{
        public DataContext(DbContextOptions<DataContext> opts) : base(opts){}
        public DbSet<Food> Foods {get; set;}
        public DbSet<Address> Addresses {get; set;}
        public DbSet<Restaurant> Restaurants {get; set;}
    }
}