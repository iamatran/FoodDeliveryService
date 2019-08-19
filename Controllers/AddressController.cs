using Microsoft.AspNetCore.Mvc;
using FoodDeliveryService.Models;
using FoodDeliveryService.Models.BindingTargets;
using System.Collections.Generic;

namespace FoodDeliveryService.Controllers
{
    [Route("api/addresses")]
    public class AddressController : Controller
    {
        private DataContext context;
        public AddressController(DataContext ctx)
        {
            context = ctx;
        }
        [HttpGet]
        public IEnumerable<Address> GetAddresses()
        {
            return context.Addresses;
        }
        [HttpPost]
        public IActionResult CreateAddress([FromBody]AddressData sdata)
        {
            if (ModelState.IsValid)
            {
                Address s = sdata.Address;
                context.Add(s);
                context.SaveChanges();
                return Ok(s.AddressId);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        public IActionResult ReplaceAddress(long id,
               [FromBody] AddressData sdata)
        {
            if (ModelState.IsValid)
            {
                Address s = sdata.Address;
                s.AddressId = id;
                context.Update(s);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}
