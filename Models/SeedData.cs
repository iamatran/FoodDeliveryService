using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using deliveryDb.Models;

namespace deliveryDb {

    public class SeedData {

        public static void SeedDatabase(DataContext context) {
            if (context.Database.GetMigrations().Count() > 0
                    && context.Database.GetPendingMigrations().Count() == 0
                    && context.Foods.Count() == 0) {
                var a1 = new Address {
                    Name = "Bob's Burgers",
                    Address1 = "123 Fake Street",
                    City = "San Jose", 
                    State = "CA",
                    ZipCode = "12345"
                };
                var a2 = new Address {
                    Name = "The Morning Grill",
                    Address1 = "456 Fake Street",
                    City = "Chicago", 
                    State = "IL",
                    ZipCode = "12345"
                };
                var a3 = new Address {
                    Name = "Pete's Cafe",
                    Address1 = "789 Fake Street",
                    City = "New York", 
                    State = "NY",
                    ZipCode = "12345"
                };

                context.Foods.AddRange(
                    new Food {
                        FoodId = 1,
                        RestaurantId = 1,
                        Name = "1/3 lb. Classic Burger",
                        Description = "Lettuce, tomato, onions and pickles. USDA choice chuck. Choice of toasted white or wheat bun.",
                        Price = 6.29, 
                        PictureId = 1
                    },
                    new Food {
                        FoodId = 2,
                        RestaurantId = 1,
                        Name = "Freshly Cut Fries",
                        Description = "Hand Cut, Lightly Salted, golden fried russet potatoes",
                        Price = 3.29, 
                        PictureId = 2
                    },
                    new Food {
                        FoodId = 3,
                        RestaurantId = 1,
                        Name = "1/3 lb. The Works Burger",
                        Description = "Bacon, grilled onions, grilled mushrooms. Choice of toasted white or wheat bun.",
                        Price = 7.79, 
                        PictureId = 3
                    },
                    new Food {
                        FoodId = 4,
                        RestaurantId = 2,
                        Name = "Original Chicken Sandwich",
                        Description = "Hand battered chicken breast on a toasted white bun.",
                        Price = 6.29, 
                        PictureId = 4
                    },
                    new Food {
                        FoodId = 5,
                        RestaurantId = 2,
                        Name = "1/3 lb. Mushroom Swiss Burger",
                        Description = "Melted Swiss cheese and sauteed mushrooms. USDA choice chuck. Choice of toasted white or wheat bun.",
                        Price = 7.29, 
                        PictureId = 5
                    },
                    new Food {
                        FoodId = 6,
                        RestaurantId = 2,
                        Name = "Chicken Strips",
                        Description = "Hand battered, golden fried chicken tenderloins.",
                        Price = 6.29, 
                        PictureId = 6
                    },
                    new Food {
                        FoodId = 7,
                        RestaurantId = 3,
                        Name = "1/3 lb. Bacon BBQ Burger",
                        Description = "Bacon, cheddar, onion strings and BBQ sauce.",
                        Price = 7.29, 
                        PictureId = 7
                    },
                    new Food {
                        FoodId = 8,
                        RestaurantId = 3,
                        Name = "Southwest Chicken Salad",
                        Description = "Grilled chicken breast on romaine, tomato, cucumber, onions, croutons and shredded cheddar, served with choice of dressing",
                        Price = 7.99, 
                        PictureId = 8
                    },
                    new Food {
                        FoodId = 9,
                        RestaurantId = 3,
                        Name = "Classic Shake",
                        Description = "Choice of Vanilla, Chocolate, or Strawberry",
                        Price = 4.29, 
                        PictureId = 9
                    });
                context.SaveChanges();
            }
        }
    }
}