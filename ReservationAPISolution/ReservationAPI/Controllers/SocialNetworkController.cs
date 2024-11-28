using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Domain;
using ReservationAPI.Models.Dtos.Request;

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialNetworkController : ControllerBase
    {
        private readonly ISocialNetworkRepository _repository;

        public SocialNetworkController(ISocialNetworkRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateSocialNetwork([FromBody] CreateSocialNetworkDto createSocialNetwork)
        {
            if (string.IsNullOrWhiteSpace(createSocialNetwork.Name) || string.IsNullOrWhiteSpace(createSocialNetwork.Link))
            {
                return BadRequest("Name and Link are required.");
            }

            var result = await _repository.CreateNewSocialNetworkAsync(createSocialNetwork);

            if (result != null)
            {
                return Ok("Social network created successfully.");
            }

            return StatusCode(500, "An error occurred while creating the social network.");
        }

    }
}
