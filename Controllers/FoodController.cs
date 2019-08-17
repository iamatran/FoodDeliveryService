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
                    .Include(m => m.Address)
                    .Include(m => m.Ratings)
                    .FirstOrDefault(m => m.FoodId == id);
            if (result != null)
            {
                if (result.Address != null)
                {
                    result.Address.Foods = null;
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

    }
}
