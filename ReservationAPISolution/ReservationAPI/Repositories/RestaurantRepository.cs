using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Domain;
using ReservationAPI.Models.Dtos.Request;
using Serilog;

namespace ReservationAPI.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly ReservationsDbContext _context;

        public RestaurantRepository(ReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            Log.Information("Fetching all restaurants...");

            var restaurants = await _context.Restaurants
                .Include(r => r.SocialNetworks)
                .Include(r => r.Tables)
                .Include(r => r.Reviews)
                .Where(r => !r.IsDeleted)
                .ToListAsync();

            Log.Information("Fetched {Count} restaurants.", restaurants.Count);

            return restaurants;
        }

        public async Task<Restaurant> CreateRestaurantAsync(CreateRestaurantDto request)
        {
            Log.Information("Attempting to create a new restaurant: {Name}", request.Name);

            var restaurant = new Restaurant
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                IsDeleted = false,
                OpenDate = request.OpenDate,
                CreatedAt = DateTime.UtcNow
            };

            try
            {
                await _context.Restaurants.AddAsync(restaurant);
                await _context.SaveChangesAsync();

                Log.Information("Successfully created restaurant: {Name} with ID {Id}", restaurant.Name, restaurant.Id);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to create restaurant: {Name}", request.Name);
                throw;
            }

            return restaurant;
        }
    }
}
