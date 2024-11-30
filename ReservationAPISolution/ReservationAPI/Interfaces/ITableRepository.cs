using ReservationAPI.Models.Domain;
using ReservationAPI.Models.Dtos.Request;
using ReservationAPI.Models.Dtos.Response;

namespace ReservationAPI.Interfaces
{
    public interface ITableRepository
    {
        Task<TableResponseDto> CreateTableAsync(CreateTableDto createTableDto);
    }
}
