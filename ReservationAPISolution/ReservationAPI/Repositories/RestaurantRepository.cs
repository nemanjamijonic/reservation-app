using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Domain;
using ReservationAPI.Models.Dtos.Request;

namespace ReservationAPI.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ReservationsDbContext _context;

        public RestaurantRepository(ReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<Restaurant> CreateRestaurantAsync(CreateRestaurantDto request)
        {
            var restaurant = new Restaurant
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                OpenDate = request.OpenDate,
                CreatedAt = DateTime.UtcNow
            };

            _context.Set<Restaurant>().Add(restaurant);
            await _context.SaveChangesAsync();

            return restaurant;
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return await _context.Restaurants
                .Include(r => r.SocialNetworks) 
                .Where(r => !r.IsDeleted)
                .ToListAsync();
        }
    }
}
