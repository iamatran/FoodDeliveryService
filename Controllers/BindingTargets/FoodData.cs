using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryService.Models.BindingTargets
{
    public class FoodData
    {
        [Required]
        public string Image{ get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string Description { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be at least 1")]
        public decimal Price { get; set; }
        public long Address { get; set; }
        public Food Food => new Food
        {
            Name = Name,
            Category = Category,
            Description = Description,
            Price = Price,
            Address = Address == 0 ? null : new Address { AddressId = Address }
        };
    }
}
