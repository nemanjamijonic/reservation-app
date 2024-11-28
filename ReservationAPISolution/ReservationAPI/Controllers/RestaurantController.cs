using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Dtos.Request;

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantRepository _repository;

        public RestaurantController(IRestaurantRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            try
            {
                var restaurants = await _repository.GetRestaurantsAsync();
                return Ok(restaurants);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Name) || string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                return BadRequest("Name and PhoneNumber are required.");
            }

            var createdRestaurant = await _repository.CreateRestaurantAsync(request);

            if (createdRestaurant == null)
            {
                return StatusCode(500, "An error occurred while creating the restaurant.");
            }

            return Ok(createdRestaurant);
        }
    }
}
