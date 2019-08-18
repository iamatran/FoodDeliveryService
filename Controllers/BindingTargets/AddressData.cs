using System.ComponentModel.DataAnnotations;
namespace FoodDeliveryService.Models.BindingTargets
{
    public class AddressData
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string State { get; set; }
        public Address Address => new Address
        {
            Name = Name,
            City = City,
            State = State
        };
    }
}
