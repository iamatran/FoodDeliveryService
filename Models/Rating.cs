namespace FoodDeliveryService.Models {

    public class Rating {

        public long RatingId { get; set; }
        public int Stars { get; set; }
        public Food Food { get; set; }
    }
}
