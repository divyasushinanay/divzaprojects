using Domain.Services.Auth;
using Domain.Services.Auth.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SkillTrackPro.API.Auth
{


    //[Route("api/[controller]")]
    //[ApiController]
    //public class AuthController : ControllerBase
    //{
    //    private readonly IAuthService _authService;

    //    public AuthController(IAuthService authService)
    //    {
    //        _authService = authService;
    //    }

    //[HttpPost("coach/send-otp")]
    //public async Task<IActionResult> SendOtp([FromBody] SendOtpDto dto)
    //{
    //    var result = await _authService.SendCoachOtp(dto.Email);
    //    return Ok(result);
    //}

    //[HttpPost("coach/verify-otp")]
    //public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto dto)
    //{
    //    var result = await _authService.VerifyCoachOtp(dto.Email, dto.Otp);
    //    return Ok(result);
    //}


    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        // ================================
        // 1️⃣ SEND OTP TO COACH EMAIL
        // ================================
        [HttpPost("coach/send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] SendOtpDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email))
                return BadRequest("Email is required");

            var result = await _authService.SendCoachOtp(dto.Email);
            return Ok(new { message = result });
        }

        // ================================
        // 2️⃣ VERIFY OTP & LOGIN COACH
        // ================================
        [HttpPost("coach/verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto dto)
        {
            if (string.IsNullOrEmpty(dto.Email) || string.IsNullOrEmpty(dto.Otp))
                return BadRequest("Email and OTP are required");

            var result = await _authService.VerifyCoachOtp(dto.Email, dto.Otp);

            return Ok(new { token = result });
        }
    }
}
    

