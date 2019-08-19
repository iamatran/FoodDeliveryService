using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryService.Models.BindingTargets
{
    public class FoodData
    {
        //we're modifying the get and set methods to point to the properties in the food object
        [Required]
        public string Image { get => Food.Image; set => Food.Image = value; }
        [Required]
        public string Name { get => Food.Name; set => Food.Name = value; }
        [Required]
        public string Category { get => Food.Category; set => Food.Category = value; }
        [Required]
        public string Description { get => Food.Description; set => Food.Description = value; }
        [Range(1, int.MaxValue, ErrorMessage = "Price must be at least 1")]
        public decimal Price { get => Food.Price; set => Food.Price = value; }
        
        //This get is grabs the id, the ?? checks for null values
        //The set checks if it has a value, if not it will assign the address as null, or it will create a new instance of address
        public long? Address
        {
            get => Food.Address?.AddressId ?? null;
            set
            {
                if (!value.HasValue)
                {
                    Food.Address = null;
                }
                else
                {
                    if (Food.Address == null)
                    {
                        Food.Address = new Address();
                    }
                    Food.Address.AddressId = value.Value;
                }
            }
        }
        public Food Food { get; set; } = new Food();
    }
}
