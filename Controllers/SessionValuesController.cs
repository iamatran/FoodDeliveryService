using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FoodDeliveryService.Models;

namespace FoodDeliveryService.Controllers
{
    [Route("/api/session")]
    public class SessionValuesController : Controller
    {
        //retreives the carts session data
        [HttpGet("cart")]
        public IActionResult GetCart()
        {
            return Ok(HttpContext.Session.GetString("cart"));
        }
        //This will convert the JSON session data and store it in the database
        [HttpPost("cart")]
        public void StoreCart([FromBody] FoodSelection[] foods)
        {
            var jsonData = JsonConvert.SerializeObject(foods);
            HttpContext.Session.SetString("cart", jsonData);
        }
    }
}
