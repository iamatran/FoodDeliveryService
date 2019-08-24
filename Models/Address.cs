using System.Collections.Generic;


// This is our C# Model class to setup the DB Schema using Entity Framework Migration Feature
namespace FoodDeliveryService.Models {
    public class Address {

        public long AddressId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public IEnumerable<Food> Foods { get; set; }
    }
}
