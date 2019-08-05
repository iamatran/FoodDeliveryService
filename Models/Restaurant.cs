namespace FoodDeliveryService.Models{
    public class Restaurant{
        public string RestaurantId { get;set; }
        public string Name { get;set; }
        public string Category { get;set; }
        public string AddressId { get;set; }
        public string PictureId { get;set; }
        public Food Food { get; set; }
    }
}
