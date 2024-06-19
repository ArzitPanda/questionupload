
using Microsoft.EntityFrameworkCore;
using questionupload.Data.Model;
using System;

namespace questionupload.Data
{

    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Accessibility> Accessibilities { get; set; }
        public DbSet<RoleAccessibility> RoleAccessibilities { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleAccessibility>()
                .HasKey(ra => new { ra.RoleId, ra.AccessibilityId });

            modelBuilder.Entity<RoleAccessibility>()
                .HasOne(ra => ra.Role)
                .WithMany(r => r.RoleAccessibilities)
                .HasForeignKey(ra => ra.RoleId);

            modelBuilder.Entity<RoleAccessibility>()
                .HasOne(ra => ra.Accessibility)
                .WithMany(a => a.RoleAccessibilities)
                .HasForeignKey(ra => ra.AccessibilityId);

            // Seeding initial data
            var adminRole = new Role { RoleId = 1, RoleName = "admin" };
            var adminAccessibility = new Accessibility { Id = 1, AccessibilityName = "all" };
            var adminUser = new User
            {
                Id = 1,
                Username = "admin",
                Password = "admin123",
                RoleId = adminRole.RoleId
            };
            var adminUserDetails = new UserDetails
            {
                UserId = adminUser.Id,
                Location = "Admin Location",
                Dob = new DateTime(1970, 1, 1),
                College = "Admin College",
                Qualification = "Admin Qualification"
            };
            var adminRoleAccessibility = new RoleAccessibility
            {
                RoleId = adminRole.RoleId,
                AccessibilityId = adminAccessibility.Id
            };

            modelBuilder.Entity<Role>().HasData(adminRole);
            modelBuilder.Entity<Accessibility>().HasData(adminAccessibility);
            modelBuilder.Entity<User>().HasData(adminUser);
            modelBuilder.Entity<UserDetails>().HasData(adminUserDetails);
            modelBuilder.Entity<RoleAccessibility>().HasData(adminRoleAccessibility);
        }
    }

}
