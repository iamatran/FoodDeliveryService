using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using FoodDeliveryService.Models;

//This seed data class will use entity frameworks migration feature to seed the database with these starter items

namespace FoodDeliveryService {

    public class SeedData {

        public static void SeedDatabase(DataContext context) {
            if (context.Database.GetMigrations().Count() > 0
                    && context.Database.GetPendingMigrations().Count() == 0
                    && context.Foods.Count() == 0) {
                var s1 = new Address {
                    Name = "123 Fake Street",
                    City = "San Jose", State = "CA"
                };
                var s2 = new Address {
                    Name = "456 Fake Avenue",
                    City = "Chicago", State = "IL"
                };
                var s3 = new Address {
                    Name = "789 Fake Road",
                    City = "New York", State = "NY"
                };

                context.Foods.AddRange(
                    new Food {
                        Image = "../../assets/images/burger.jpg",
                        Name = "1/3 lb. Classic Burger",
                        Description = "Lettuce, tomato, onions and pickles. USDA choice chuck. Choice of toasted white or wheat bun",
                        Category = "Bobs Burgers", Price = 6.29m, Address = s1,
                        Ratings = new List<Rating> {
                            new Rating { Stars = 4 }, new Rating { Stars = 3 }}
                    },
                    new Food {
                        Image = "../../assets/images/fries.jpg",
                        Name = "Freshly Cut Fries",
                        Description = "Hand Cut, Lightly Salted, lightly battered, golden fried russet potatoes",
                        Category = "Bobs Burgers", Price = 3.29m, Address = s1,
                        Ratings = new List<Rating> {
                            new Rating { Stars = 2 }, new Rating { Stars = 5 }}
                    },
                    new Food {
                        Image = "../../assets/images/works.jpg",
                        Name = "1/3 lb. The Works Burger",
                        Description = "Bacon, grilled onions, grilled mushrooms. Choice of toasted white or wheat bun",
                        Category = "Bobs Burgers", Price = 7.79m, Address = s1,
                        Ratings = new List<Rating> {
                            new Rating { Stars = 1 }, new Rating { Stars = 3 }}
                    },
                    new Food {
                        Image = "../../assets/images/chickensand.jpg",
                        Name = "The Original Chicken Sandwich",
                        Description = "Hand battered, perfectly seasoned chicken breast on a toasted white bun with pickles",
                        Category = "The Morning Grill", Price = 6.29m, Address = s2,
                        Ratings = new List<Rating> { new Rating { Stars = 3 } }
                    },
                    new Food {
                        Image = "../../assets/images/mushroom.jpg",
                        Name = "1/3 lb. Mushroom Swiss Burger",
                        Description = "Melted Swiss cheese and sauteed mushrooms. USDA choice chuck. Choice of toasted white or wheat bun",
                        Category = "The Morning Grill", Price = 7.29m, Address = s2,
                        Ratings = new List<Rating> { new Rating { Stars = 1 },
                            new Rating { Stars = 4 }, new Rating { Stars = 3 }}
                    },
                    new Food {
                        Image = "../../assets/images/chicken.jpg",
                        Name = "Golden Fried Chicken Strips",
                        Description = "Hand battered, golden fried chicken tenderloins. Comes with side of french fries",
                        Category = "The Morning Grill", Price = 6.29m, Address = s2,
                        Ratings = new List<Rating> { new Rating { Stars = 5 },
                            new Rating { Stars = 4 }}
                    },
                    new Food {
                        Image = "../../assets/images/bacon.jpg",
                        Name = "1/3 lb. Bacon BBQ Burger",
                        Description = "Bacon, cheddar, onion strings and BBQ sauce served on a toasted white bun with a side of fries",
                        Category = "Petes Cafe", Price = 7.99m, Address = s3,
                        Ratings = new List<Rating> { new Rating { Stars = 3 } }
                    },
                    new Food {
                        Image = "../../assets/images/salad.jpg",
                        Name = "Southwest Chicken Salad",
                        Description = "Grilled chicken breast on romaine, tomato, cucumber, onions, croutons and shredded cheddar, served with choice of dressing",
                        Category = "Petes Cafe", Price = 7.99m, Address = s3
                    },
                    new Food {
                        Image = "../../assets/images/shake.jpg",
                        Name = "Classic Milk Shake",
                        Description = "Made fresh with Blue Bell's ice cream, choice of Vanilla, Chocolate, or Strawberry",
                        Category = "Petes Cafe", Price = 4.29m, Address = s3
                    });
                context.SaveChanges();
            }
        }
    }
}