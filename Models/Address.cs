using System.Collections.Generic;

namespace FoodDeliveryService.Models {
    public class Address {

        public long AddressId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public IEnumerable<Food> Foods { get; set; }
    }
}
