using System.Collections.Generic;


// This is our C# Model class to setup the DB Schema using Entity Framework Migration Feature
namespace FoodDeliveryService.Models{
    public class Food{
        public long FoodId{ get;set; }
        public string Image { get;set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Address Address { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}