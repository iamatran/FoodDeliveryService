namespace FoodItems.Models{
    public class Food{
        public long FoodId { get;set; }
        public long RestaurantId { get;set; }
        public string Name { get;set; }
        public string Description { get;set; }
        public float Price { get;set; }
        public string PictureId { get;set; }

        public Restaurant Restaurant { get;set; }

        public List<Rating> Ratings { get;set; }
    }
}
