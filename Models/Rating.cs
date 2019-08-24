// This is our C# Model class to setup the DB Schema using Entity Framework Migration Feature

namespace FoodDeliveryService.Models {

    public class Rating {

        public long RatingId { get; set; }
        public int Stars { get; set; }
        public Food Food { get; set; }
    }
}
