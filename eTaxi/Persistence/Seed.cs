using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Model.Others;
using System;

namespace Persistence
{
    public static class Seed
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 1, Name = UserRoles.Admin, NormalizedName = UserRoles.Admin.ToUpper() });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 2, Name = UserRoles.Owner, NormalizedName = UserRoles.Owner.ToUpper() });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 4, Name = UserRoles.Worker, NormalizedName = UserRoles.Worker.ToUpper() });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 5, Name = UserRoles.User, NormalizedName = UserRoles.User.ToUpper() });


            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 1,
                UserName = "Admin",
                NormalizedUserName = "admin@admin.com".ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "qweasd"),
                SecurityStamp = string.Empty,
                UserType = UserRoles.Admin,
                IsActive = true
            });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 2,
                FirstName = "Vlasnik",
                LastName = "Fazlić",
                UserName = "fazla",
                NormalizedUserName = "fazla".ToUpper(),
                Email = "m.fazlic4@gmail.com",
                NormalizedEmail = "m.fazlic4@gmail.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "qweasd"),
                UserCreatedTime = DateTime.Now,
                UserType = UserRoles.Owner,
                IsActive = true
            });

            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 4,
                UserName = "Taksista",
                NormalizedUserName = "company".ToUpper(),
                Email = "company@company.com",
                NormalizedEmail = "company@company.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "qweasd"),
                SecurityStamp = string.Empty,
                UserCreatedTime = DateTime.Now,
                UserType = UserRoles.Worker,
                IsActive = true

            });
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser
            {
                Id = 5,
                UserName = "Korisnik",
                NormalizedUserName = "user@user.com".ToUpper(),
                Email = "user@user.com",
                NormalizedEmail = "user@user.com".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "qweasd"),
                SecurityStamp = string.Empty,
                UserType = UserRoles.User,
                IsActive = true
            });

            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 1, RoleId = 1 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 2, RoleId = 2 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 4, RoleId = 4 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 5, RoleId = 5 });
        }
    }
}