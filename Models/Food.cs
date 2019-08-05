namespace FoodDeliveryService.Models{
    public class Food{
        public long FoodId { get;set; }
        public long RestaurantId { get;set; }
        public string Name { get;set; }
        public string Description { get;set; }
        public double Price { get;set; }
        public long PictureId { get;set; }

    }
}
