namespace FoodDeliveryService.Models
{
    public class FoodSelection
    {
        public long foodId { get; set; }
        public string name { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
}
