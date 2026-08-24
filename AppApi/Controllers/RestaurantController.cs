using BAL.Model;
using BAL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        RestaurantService service;

        public RestaurantController( RestaurantService service)
        {
            this.service = service;
            
        }



        [HttpGet("All_Restaurants")]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = service.GetAllRestaurants();
            return Ok(restaurants);
        }
        [HttpGet("Restaurant/{id}")]
        public IActionResult GetRestaurantById(int id)
        {
            var restaurant = service.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return Ok(restaurant);
        }
        [HttpPost("AddRestaurant")]
        public IActionResult AddRestaurant( RestaurantModel restaurantModel)
        {
           var data=service.AddRestaurant(restaurantModel);
            return Ok(data);
        }
        [HttpPut("UpdateRestaurant")]
        public IActionResult UpdateRestaurant( RestaurantModel restaurantModel)
        {
           var data=service.UpdateRestaurant(restaurantModel);
            return Ok(data);
        }
        [HttpDelete("DeleteRestaurant/{id}")]
        public IActionResult DeleteRestaurant(int id)
        {
            var data=service.DeleteRestaurant(id);
            return Ok(data);
        }
    }
}
