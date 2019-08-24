using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodDeliveryService.Models;
using Microsoft.EntityFrameworkCore;
using FoodDeliveryService.Models.BindingTargets;
using Microsoft.AspNetCore.JsonPatch;

//This is the controller for our foods with some HTTP methods setup for our API

namespace FoodDeliveryService.Controllers
{
    [Route("api/foods")]
    public class FoodController : Controller
    {
        private DataContext context;
        public FoodController(DataContext ctx)
        {
            context = ctx;
        }

        [HttpGet("{id}")]
        public Food GetFood(long id)
        {

            Food result = context.Foods
                    .Include(m => m.Address).ThenInclude(s => s.Foods)
                    .Include(m => m.Ratings)
                    .FirstOrDefault(m => m.FoodId == id);
            //To avoid circular references, were going to check in order for null values and assign nulls accordingly
            if (result != null)
            {
                if (result.Address != null)
                {
                    result.Address.Foods = result.Address.Foods.Select(s =>
                    new Food
                    {
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
        public IActionResult GetFoods(string category, string search,
                                            bool related = false, bool metadata = false)
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
                return metadata ? CreateMetadata(data) : Ok(data);
            }
            else
            {
                return metadata ? CreateMetadata(query) : Ok(query);
            }
        }
        //This method will create metadata set to the sequence of food objects and the categories property is set using a query to grab the list of categories of restaurants
        private IActionResult CreateMetadata(IEnumerable<Food> foods)
        {
            return Ok(new
            {
                data = foods,
                categories = context.Foods.Select(m => m.Category)
            .Distinct().OrderBy(m => m)
            });
        }

        [HttpPost]
        public IActionResult CreateFood([FromBody] FoodData mdata)
        {
            if (ModelState.IsValid)
            {
                Food m = mdata.Food;
                if (m.Address != null && m.Address.AddressId != 0)
                {
                    context.Attach(m.Address);
                }
                context.Add(m);
                context.SaveChanges();
                return Ok(m.FoodId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPut("{id}")]
        public IActionResult ReplaceFood(long id, [FromBody] FoodData mData)
        {
            if (ModelState.IsValid)
            {
                Food m = mData.Food;
                m.FoodId = id;
                if (m.Address != null && m.Address.AddressId != 0)
                {
                    context.Attach(m.Address);
                }
                context.Update(m);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        //this patch attribute defines a long paremeter that identifies the food that is being modified and the adjacent patch document parameter that represents the Json patch document. We retreive a food object use the patch method yo update and create an updated food object that we also check if the object is valid
        [HttpPatch("{id}")]
        public IActionResult UpdateFood(long id,
            [FromBody]JsonPatchDocument<FoodData> patch)
        {
            Food food = context.Foods
            .Include(m => m.Address)
            .First(m => m.FoodId == id);
            FoodData mdata = new FoodData { Food = food };
            patch.ApplyTo(mdata, ModelState);
            if (ModelState.IsValid && TryValidateModel(mdata))
            {
                if (food.Address != null && food.Address.AddressId != 0)
                {
                    context.Attach(food.Address);
                }
                context.SaveChanges();
                return Ok(food);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        //our delete method, pasing in id
        [HttpDelete("{id}")]
        public IActionResult DeleteFood(long id)
        {
            context.Foods.Remove(new Food { FoodId = id });
            context.SaveChanges();
            return Ok(id);
        }


    }
}
