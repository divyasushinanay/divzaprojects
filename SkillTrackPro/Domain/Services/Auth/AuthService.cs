


using Domain.Models;
using Domain.Services.Auth;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Macs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//public class AuthService : IAuthService
//{
//    private readonly AppDbContext _context;
//    private readonly IEmailService _emailService;
//    private readonly IJwtService _jwtService;

//    public AuthService(AppDbContext context, IEmailService emailService, IJwtService jwtService)
//    {
//        _context = context;
//        _emailService = emailService;
//        _jwtService = jwtService;
//    }

//    // STEP 1 → Send OTP
//    public async Task<string> SendCoachOtp(string email)
//    {
//        var coach = await _context.Coaches.FirstOrDefaultAsync(c => c.Email == email);

//        if (coach == null)
//            return "Coach not found";

//        string otp = new Random().Next(100000, 999999).ToString();

//        coach.OTP = otp;
//        coach.OTPExpiry = DateTime.Now.AddMinutes(5);

//        await _context.SaveChangesAsync();

//        await _emailService.SendEmailAsync(coach.Email!, "Your OTP", $"Your login OTP is: {otp}");

//        return "OTP sent successfully";
//    }

//    // STEP 2 → Verify OTP and return JWT
//    public async Task<string> VerifyCoachOtp(string email, string otp)
//    {
//        var coach = await _context.Coaches.FirstOrDefaultAsync(c => c.Email == email);

//        if (coach == null)
//            return "Coach not found";

//        if (coach.OTP != otp || coach.OTPExpiry < DateTime.Now)
//            return "Invalid or expired OTP";

//        string token = _jwtService.GenerateToken(
//            coach.Id,
//            coach.FullName,
//            coach.Email!,
//            "Coach"
//        );

//        return token;
//    }


//    public async Task<string> SendParentOtp(string email)
//    {
//        var parent = await _context.Parents.FirstOrDefaultAsync(p => p.Email == email);

//        if (parent == null)
//            return "Parent not found";

//        string otp = new Random().Next(100000, 999999).ToString();

//        parent.OTP = otp;
//        parent.OTPExpiry = DateTime.Now.AddMinutes(5);

//        await _context.SaveChangesAsync();

//        await _emailService.SendEmailAsync(
//            parent.Email!,
//            "Your OTP",
//            $"Your login OTP is: {otp}"
//        );

//        return "OTP sent successfully";
//    }

//    public async Task<string> VerifyParentOtp(string email, string otp)
//    {
//        var parent = await _context.Parents.FirstOrDefaultAsync(p => p.Email == email);

//        if (parent == null)
//            return "Parent not found";

//        if (parent.OTP != otp || parent.OTPExpiry < DateTime.Now)
//            return "Invalid or expired OTP";

//        return _jwtService.GenerateToken(
//            parent.Id,
//            parent.FullName,
//            parent.Email!,
//            "Parent"
//        );
//    }
//}

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IEmailService _emailService;
    private readonly IJwtService _jwtService;

    public AuthService(
        AppDbContext context,
        IEmailService emailService,
        IJwtService jwtService)
    {
        _context = context;
        _emailService = emailService;
        _jwtService = jwtService;
    }

    // =======================
    // COACH LOGIN
    // =======================

    public async Task<string> SendCoachOtpAsync(string email)
    {
        var coach = await _context.Coaches
            .FirstOrDefaultAsync(c => c.Email == email);

        if (coach == null)
            throw new Exception("Coach not found");

        string otp = new Random().Next(100000, 999999).ToString();

        coach.OTP = otp;
        coach.OTPExpiry = DateTime.UtcNow.AddMinutes(5);

        await _context.SaveChangesAsync();

        await _emailService.SendEmailAsync(
            coach.Email!,
            "Your OTP",
            $"Your login OTP is: {otp}");

        return "OTP sent successfully";
    }

    public async Task<string> VerifyCoachOtpAsync(string email, string otp)
    {
        var coach = await _context.Coaches
            .FirstOrDefaultAsync(c => c.Email == email);

        if (coach == null)
            throw new Exception("Coach not found");

        if (coach.OTP != otp || coach.OTPExpiry < DateTime.UtcNow)
            throw new Exception("Invalid or expired OTP");

        string token = _jwtService.GenerateToken(
            coach.Id,
            coach.FullName,
            coach.Email!,
            "Coach"
        );

        // ✅ Clear OTP after login
        coach.OTP = null;
        coach.OTPExpiry = null;

        await _context.SaveChangesAsync();

        return token;
    }

    // =======================
    // PARENT LOGIN
    // =======================

    public async Task<string> SendParentOtpAsync(string email)
    {
        var parent = await _context.Parents
            .FirstOrDefaultAsync(p => p.Email == email);

        if (parent == null)
            throw new Exception("Parent not found");

        string otp = new Random().Next(100000, 999999).ToString();

        parent.OTP = otp;
        parent.OTPExpiry = DateTime.UtcNow.AddMinutes(5);

        await _context.SaveChangesAsync();

        await _emailService.SendEmailAsync(
            parent.Email!,
            "Your OTP",
            $"Your login OTP is: {otp}");

        return "OTP sent successfully";
    }

    public async Task<string> VerifyParentOtpAsync(string email, string otp)
    {
        var parent = await _context.Parents
            .FirstOrDefaultAsync(p => p.Email == email);

        if (parent == null)
            throw new Exception("Parent not found");

        if (parent.OTP != otp || parent.OTPExpiry < DateTime.UtcNow)
            throw new Exception("Invalid or expired OTP");

        string token = _jwtService.GenerateToken(
            parent.Id,
            parent.FullName,
            parent.Email!,
            "Parent"
        );

        parent.OTP = null;
        parent.OTPExpiry = null;

        await _context.SaveChangesAsync();

        return token;
    }
}



