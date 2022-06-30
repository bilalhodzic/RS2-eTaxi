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
                IsActive = true,
                VerifiedAccount = true
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

            //FILE 

            modelBuilder.Entity<File>().HasData(new File
            {
                FileId=1,
                UserId=1,
                Url= "Resources/189400dc-e58e-42c6-9d77-6564969c2f66_car.png",

                FileName= "189400dc-e58e-42c6-9d77-6564969c2f66_car.png",
                OriginalName="car.png",
                Type="CarIcon"
            });

            modelBuilder.Entity<File>().HasData(new File
            {
                FileId = 2,
                UserId = 1,
                Url = "Resources/e96c66e4-929e-4369-9b93-2562062fbfa6_cady.png",

                FileName = "e96c66e4-929e-4369-9b93-2562062fbfa6_cady.png",
                OriginalName = "car.png",
                Type = "CarIcon"
            }); modelBuilder.Entity<File>().HasData(new File
            {
                FileId = 3,
                UserId = 1,
                Url = "Resources/321f8965-2139-4abe-b164-0d5cdd681516_SUV.png",

                FileName = "321f8965-2139-4abe-b164-0d5cdd681516_SUV.png",
                OriginalName = "SUV.png",
                Type = "CarIcon"
            }); modelBuilder.Entity<File>().HasData(new File
            {
                FileId = 4,
                UserId = 1,
                Url = "Resources/9e889e03-c086-408f-8647-9637292659b5_sedan.png",

                FileName = "9e889e03-c086-408f-8647-9637292659b5_sedan.png",
                OriginalName = "sedan.png",
                Type = "CarIcon"
            });

            modelBuilder.Entity<File>().HasData(new File
            {
                FileId = 5,
                UserId = 1,
                Url = "Resources/33ed6c0b-fee1-4ba9-a5e5-a4e59e775233_Bus.png",

                FileName = "33ed6c0b-fee1-4ba9-a5e5-a4e59e775233_Bus.png",
                OriginalName = "bus.png",
                Type = "CarIcon"
            });

            //files for vehicle
            modelBuilder.Entity<File>().HasData(new File
            {
                FileId = 6,
                UserId = 1,
                Url = "https://res.cloudinary.com/doswamdah/image/upload/v1656523885/rs2/skodasuperb_gluat1.png",

                FileName = "https://res.cloudinary.com/doswamdah/image/upload/v1656523885/rs2/skodasuperb_gluat1.png",
                OriginalName = "skoda.png",
                Type = "Car",
                VehicleId=6
            });

            modelBuilder.Entity<File>().HasData(new File
            {
                FileId = 7,
                UserId = 1,
                Url = "https://res.cloudinary.com/doswamdah/image/upload/v1656523883/rs2/audia8_gckbfh.png",

                FileName = "https://res.cloudinary.com/doswamdah/image/upload/v1656523883/rs2/audia8_gckbfh.png",
                OriginalName = "audi.png",
                Type = "Car",
                VehicleId = 5
            });
            modelBuilder.Entity<File>().HasData(new File
            {
                FileId = 8,
                UserId = 1,
                Url = "https://res.cloudinary.com/doswamdah/image/upload/v1656523879/rs2/golf_7_didjje.jpg",

                FileName = "https://res.cloudinary.com/doswamdah/image/upload/v1656523879/rs2/golf_7_didjje.jpg",
                OriginalName = "golf.png",
                Type = "Car",
                VehicleId = 4
            });

            //VehicleType

            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                VehicleTypeId = 1,
                Type="Hatchback",
                NumberOfSeats=5,
                FileId=1
            });

            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                VehicleTypeId = 2,
                Type = "Mini van",
                NumberOfSeats = 5,
                FileId=2,

            }); 
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                VehicleTypeId = 3,
                Type = "SUV",
                NumberOfSeats = 5,
                FileId=3,
            });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                VehicleTypeId = 4,
                Type = "Sedan",
                NumberOfSeats = 5,
                FileId=4,
            }); 
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                VehicleTypeId = 5,
                Type = "Bus",
                NumberOfSeats = 40,
                FileId=5,
            });

            //VEHICLES

            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 4,
                Name="Golf 7",
                UserDriverId = 0,
                CreatedTime = DateTime.Now,
                KmTraveled = 2345,
                LicenceNumber = "a455-65767",
                Year = 2019,
                AirCondition = true,
                CurrentLocationId = 1,
                TypeId = 1,
                AirBag=true,
                FuelType="Benzin",
                Transmission="Manual",
                Color="Siva",
                Brand="Golf",
            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 5,
                UserDriverId = 0,
                CreatedTime = DateTime.Now,
                KmTraveled = 13345,
                LicenceNumber = "a455-65768",
                Year = 2020,
                AirCondition = true,
                CurrentLocationId = 1,
                TypeId = 4,
                AirBag = true,
                FuelType = "Benzin",
                Transmission = "Automatic",
                Color = "Siva",
                Brand = "Audi",
                Name = "Audi A8",

            });
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 6,
                UserDriverId = 0,
                CreatedTime = DateTime.Now,
                KmTraveled = 13245,
                LicenceNumber = "a455-65769",
                Year = 2019,
                AirCondition = true,
                CurrentLocationId = 1,
                TypeId = 4,
                AirBag = true,
                FuelType = "Benzin",
                Transmission = "Manual",
                Color = "Crna",
                Brand = "Skoda",
                Name = "Skoda superb",
            });
         
        }
    }
}