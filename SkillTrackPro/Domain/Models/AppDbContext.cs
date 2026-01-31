using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts) { }

        public DbSet<Academy> Academies { get; set; } = null!;
        public DbSet<Parent> Parents { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Coach> Coaches { get; set; } = null!;
        public DbSet<Attendance> Attendances { get; set; } = null!;
        public DbSet<Event> Events { get; set; } = null!;
        public DbSet<FeePayment> FeePayments { get; set; } = null!;
        public DbSet<PerformanceReview> PerformanceReviews { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // ================= STUDENT → PARENT =================
            builder.Entity<Student>()
                .HasOne(s => s.Parent)
                .WithMany()
                .HasForeignKey(s => s.ParentId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================= FEEPAYMENT → STUDENT =================
            builder.Entity<FeePayment>()
                .HasOne(fp => fp.Student)
                .WithMany()
                .HasForeignKey(fp => fp.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            // ================= FEEPAYMENT → PARENT =================
            builder.Entity<FeePayment>()
                .HasOne(fp => fp.Parent)
                .WithMany()
                .HasForeignKey(fp => fp.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ================= UNIQUE PAYMENT PER MONTH =================
            builder.Entity<FeePayment>()
                .HasIndex(p => new { p.StudentId, p.Year, p.Month })
                .IsUnique();

            // ================= ENUM STORAGE =================
            builder.Entity<FeePayment>()
                .Property(p => p.Status)
                .HasConversion<int>();

            // ================= DECIMAL SAFETY =================
            builder.Entity<FeePayment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            //         // ================= SEED DATA =================
            //
            //   
            builder.Entity<Academy>().HasData(
     new Academy
     {
         Id = Guid.NewGuid(),
         Username = "academyadmin",
         Email = "academy@mail.com",
         PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
         Name = "Main Academy"
     }
 );
        }
    }
}

