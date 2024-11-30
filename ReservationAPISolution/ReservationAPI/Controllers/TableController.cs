using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Dtos.Request;

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly ITableRepository _repository;

        public TableController(ITableRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTable([FromBody] CreateTableDto request)
        {
            try
            {
                var createdTable = await _repository.CreateTableAsync(request);
                return Ok(createdTable);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}
