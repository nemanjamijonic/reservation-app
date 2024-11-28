using ReservationAPI.Models.Domain;
using ReservationAPI.Models.Dtos.Request;

namespace ReservationAPI.Interfaces
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetRestaurantsAsync();
        Task<Restaurant> CreateRestaurantAsync(CreateRestaurantDto createRestaurantDto);
    }
}
