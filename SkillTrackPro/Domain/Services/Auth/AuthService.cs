


using Domain.Models;
using Domain.Services.Auth;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IEmailService _emailService;
    private readonly IJwtService _jwtService;

    public AuthService(AppDbContext context, IEmailService emailService, IJwtService jwtService)
    {
        _context = context;
        _emailService = emailService;
        _jwtService = jwtService;
    }

    // STEP 1 → Send OTP
    public async Task<string> SendCoachOtp(string email)
    {
        var coach = await _context.Coaches.FirstOrDefaultAsync(c => c.Email == email);

        if (coach == null)
            return "Coach not found";

        string otp = new Random().Next(100000, 999999).ToString();

        coach.OTP = otp;
        coach.OTPExpiry = DateTime.Now.AddMinutes(5);

        await _context.SaveChangesAsync();

        await _emailService.SendEmailAsync(coach.Email!, "Your OTP", $"Your login OTP is: {otp}");

        return "OTP sent successfully";
    }

    // STEP 2 → Verify OTP and return JWT
    public async Task<string> VerifyCoachOtp(string email, string otp)
    {
        var coach = await _context.Coaches.FirstOrDefaultAsync(c => c.Email == email);

        if (coach == null)
            return "Coach not found";

        if (coach.OTP != otp || coach.OTPExpiry < DateTime.Now)
            return "Invalid or expired OTP";

        string token = _jwtService.GenerateToken(
            coach.Id,
            coach.FullName,
            coach.Email!,
            "Coach"
        );

        return token;
    }
}

