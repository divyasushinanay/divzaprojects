
using Domain.Helpers;
using Domain.Helpers;
using Domain.Models;
using Domain.Models;
using Domain.Services;
using Domain.Services.Academy;
using Domain.Services.Academy.Interface;
using Domain.Services.Attendance;
using Domain.Services.Attendance.Interface;
using Domain.Services.Auth;
using Domain.Services.Coaches;
using Domain.Services.Coaches.Interface;
using Domain.Services.Event;
using Domain.Services.Event.Interface;
using Domain.Services.Fees;
using Domain.Services.Fees.Interface;
using Domain.Services.Parent;
using Domain.Services.Parent.Interface;
using Domain.Services.Performance;
using Domain.Services.Performance.Interface;
using Domain.Services.Student;
using Domain.Services.Student.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Domain.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Register DbContext (ONLY here)
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(typeof(MappingProfile));
            
            // Register Repositories
            services.AddScoped<IAcademyRepository, AcademyRepository>();
            services.AddScoped<IParentRepository, ParentRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICoachRepository, CoachRepository>();
            services.AddScoped<IAttendanceRepository, AttendanceRepository>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IFeesRepository, FeesRepository>();
            services.AddScoped<IPerformanceRepository, PerformanceRepository>();


            // Register Services

            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IAcademyService, AcademyService>();
            services.AddScoped<IParentService, ParentService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<ICoachService, CoachService>();
            services.AddScoped<IAttendanceService, AttendanceService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IFeesService, FeesService>();
            services.AddScoped<IPerformanceService, PerformanceService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}
