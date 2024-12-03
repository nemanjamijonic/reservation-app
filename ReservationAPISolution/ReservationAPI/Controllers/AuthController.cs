using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReservationAPI.Interfaces;
using ReservationAPI.Models.Dtos.Request;
using Serilog;

namespace ReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationRepository _authRepository;

        public AuthController(IAuthenticationRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            Log.Information("Register endpoint called for user: {Username}", registerDto.Username);

            try
            {
                var authResponse = await _authRepository.RegisterAsync(registerDto);
                Log.Information("User registered successfully in API: {Username}", registerDto.Username);
                return Ok(authResponse);
            }
            catch (InvalidOperationException ex)
            {
                Log.Warning("Registration failed in API for user: {Username}. Reason: {Reason}", registerDto.Username, ex.Message);
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error during registration in API for user: {Username}", registerDto.Username);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            Log.Information("Login endpoint called for user: {Username}", loginDto.Username);

            try
            {
                var authResponse = await _authRepository.LoginAsync(loginDto);
                if (authResponse == null)
                {
                    Log.Warning("Login failed in API for user: {Username}. Invalid credentials.", loginDto.Username);
                    return Unauthorized(new { message = "Invalid username or password." });
                }

                Log.Information("User logged in successfully in API: {Username}", loginDto.Username);
                return Ok(authResponse);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unexpected error during login in API for user: {Username}", loginDto.Username);
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred." });
            }
        }
    }
}
