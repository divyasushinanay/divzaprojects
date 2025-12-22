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

            // Example constraints and relationships
            builder.Entity<Student>()
                 .HasOne(s => s.Parent)
                 .WithMany()            // Parent has NO Students list in your model
                 .HasForeignKey(s => s.ParentId)
                 .OnDelete(DeleteBehavior.Cascade);


            // Seed a default Admin (optional) — use hashed password in real app
            builder.Entity<Academy>().HasData(new Academy
            {
                Id = 1,
                Username = "admin@academy",
                PasswordHash = "change_me_hash", // replace with real hashed pw
                Name = "Academy Admin",
                Email = "admin@academy.com",
                ContactNumber = "+919000000000"
            });
        }
    }
}
