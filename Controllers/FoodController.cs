using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodDeliveryService.Models;
using Microsoft.EntityFrameworkCore;


namespace FoodDeliveryService.Controllers
{
    [Route("api/foods")]
    public class FoodController : Controller
    {
        private DataContext context;
        public FoodController(DataContext ctx){
            context = ctx;
        }

        [HttpGet("{id}")]                   	
    	public Food GetFood(long id)
    	{
            Food result = context.Foods
                    .Include(m => m.Address).ThenInclude(s=>s.Foods)
                    .Include(m => m.Ratings)
                    .FirstOrDefault(m => m.FoodId == id);
            if (result != null)
            {
                if (result.Address != null)
                {
                    result.Address.Foods = result.Address.Foods.Select(s=>
                    new Food{
                        FoodId = s.FoodId,
                        Name = s.Name,
                        Category = s.Category,
                        Description = s.Description,
                        Price = s.Price
                    });
                }
                if (result.Ratings != null)
                {
                    foreach (Rating r in result.Ratings)
                    {
                        r.Food = null;
                    }
                }
            }
            return result;
    	}

        [HttpGet]
        public IEnumerable<Food> GetFoods(string category, string search,
                                            bool related = false)
        {
            IQueryable<Food> query = context.Foods;
            if (!string.IsNullOrWhiteSpace(category))
            {
                string catLower = category.ToLower();
                query = query.Where(m => m.Category.ToLower().Contains(catLower));
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                string searchLower = search.ToLower();
                query = query.Where(m => m.Name.ToLower().Contains(searchLower)
                || m.Description.ToLower().Contains(searchLower));
            }

            if (related)
            {
                query = query.Include(m => m.Address).Include(m => m.Ratings);
                List<Food> data = query.ToList();
                data.ForEach(m =>
                {
                    if (m.Address != null)
                    {
                        m.Address.Foods = null;
                    }
                    if (m.Ratings != null)
                    {
                        m.Ratings.ForEach(r => r.Food = null);
                    }
                });
                return data;
            }
            else
            {
                return query;
            }
        }

    }
}
