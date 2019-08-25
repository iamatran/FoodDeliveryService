using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// This is our C# Model class to setup the DB Schema using Entity Framework Migration Feature
namespace FoodDeliveryService.Models
{
    public class Order
    {
        [BindNever]
        public long OrderId { get; set; }
        [Required]
        public string Name { get; set; }
        public IEnumerable<CartLine> Foods { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public Payment Payment { get; set; }
        [BindNever]
        public bool Shipped { get; set; } = false;
    }
    public class Payment
    {
        [BindNever]
        public long PaymentId { get; set; }
        [Required]
        public string CardNumber { get; set; }
        [Required]
        public string CardExpiry { get; set; }
        [Required]
        public int CardSecurityCode { get; set; }
        [BindNever]
        public decimal Total { get; set; }
        [BindNever]
        public string AuthCode { get; set; }
    }
    public class CartLine
    {
        [BindNever]
        public long CartLineId { get; set; }
        [Required]
        public long FoodId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
