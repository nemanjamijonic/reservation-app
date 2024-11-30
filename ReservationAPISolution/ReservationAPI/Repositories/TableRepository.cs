using Microsoft.EntityFrameworkCore;
using ReservationAPI.Data;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Domain;
using ReservationAPI.Models.Dtos.Request;
using ReservationAPI.Models.Dtos.Response;

namespace ReservationAPI.Repositories
{
    public class TableRepository : ITableRepository
    {
        private readonly ReservationsDbContext _context;

        public TableRepository(ReservationsDbContext context)
        {
            _context = context;
        }

        public async Task<TableResponseDto> CreateTableAsync(CreateTableDto createTableDto)
        {
            var restaurant = await _context.Restaurants.FirstOrDefaultAsync(r => r.Id == createTableDto.RestaurantId);
            if (restaurant == null)
            {
                throw new Exception("Restaurant with the given ID does not exist.");
            }

            var table = new Table
            {
                RestaurantId = createTableDto.RestaurantId,
                Capacity = createTableDto.Capacity,
                Restaurant = restaurant,
                CreatedAt = DateTime.UtcNow,
                IsReserved = false,
                IsDeleted = false,
            };

            await _context.AddAsync(table);
            await _context.SaveChangesAsync();

            var tableResponse = new TableResponseDto
            {
                RestaurantId = table.RestaurantId,
                Capacity = table.Capacity,
                Restaurant = restaurant,
                CreatedAt = table.CreatedAt,
                IsReserved = table.IsReserved,
            };

            return tableResponse;

        }
    }
}
