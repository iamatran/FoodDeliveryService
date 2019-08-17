using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FoodDeliveryService.Models;

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
        	return context.Foods.Find(id);
    	}

    }
}
