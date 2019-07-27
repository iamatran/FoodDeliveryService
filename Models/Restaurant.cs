using System.Collections.Generic;

namespace deliveryDb.Models{
    public class Restaurant{
        public long RestaurantId { get;set; }
        public string Name { get;set; }
        public string Category { get;set; }
        public long AddressId { get;set; }
        public long PictureId { get;set; }

        public IEnumerable<Food> Food { get; set; }
    }
}
