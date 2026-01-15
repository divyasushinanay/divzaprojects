using Domain.Services.Auth;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Domain.Services.Auth.Dto;

namespace SkillTrackPro.API.Auth
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ========== COACH ==========
        [HttpPost("coach/send-otp")]
        public async Task<IActionResult> SendCoachOtp([FromBody] EmailRequest request)
        {
            var result = await _authService.SendCoachOtpAsync(request.Email);
            return Ok(new { message = result });
        }

        [HttpPost("coach/verify-otp")]
        public async Task<IActionResult> VerifyCoachOtp([FromBody] VerifyOtpRequestDto request)
        {
            var token = await _authService.VerifyCoachOtpAsync(request.Email, request.Otp);
            return Ok(new { message = "Login successful", token });
        }

        // ========== PARENT ==========
        [HttpPost("parent/send-otp")]
        public async Task<IActionResult> SendParentOtp([FromBody] EmailRequest request)
        {
            var result = await _authService.SendParentOtpAsync(request.Email);
            return Ok(new { message = result });
        }

        [HttpPost("parent/verify-otp")]
        public async Task<IActionResult> VerifyParentOtp([FromBody] VerifyOtpRequestDto request)
        {
            var token = await _authService.VerifyParentOtpAsync(request.Email, request.Otp);
            return Ok(new { message = "Login successful", token });
        }
    }
}





