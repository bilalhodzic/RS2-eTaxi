using AutoMapper;
using Domain;
using Model.Dto;
using Model.Dto.Favorites;
using Model.Dto.Files;
using Model.Dto.Location;
using Model.Dto.Order;
using Model.Dto.Rate;
using Model.Dto.Rating;
using Model.Dto.Users;
using Model.Dto.Vehicle;
using Model.Requests;
using Model.Requests.Favorites;
using Model.Requests.Orders;
using Model.Requests.Rate;
using Model.Requests.Rating;
using Model.Requests.Vehicle;

namespace Model.Others
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Locations
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Location, LocationUpsertRequest>().ReverseMap();
            CreateMap<Location, LocationInsertRequest>().ReverseMap();
            CreateMap<Location, LocationSearchRequest>().ReverseMap();
            CreateMap<LocationBasic, Location>().ReverseMap();

            //User
            CreateMap<ApplicationUser, ApplicationUserRequest>().ReverseMap();
            CreateMap<ApplicationUser, LoginModel>().ReverseMap();
            CreateMap<ApplicationUser, UsersDto>().ReverseMap();
            CreateMap<ApplicationUser, UserPatchDto>().ReverseMap();
            CreateMap<ApplicationUser, UserUpsertRequest>().ReverseMap();
            CreateMap<ApplicationUser, UsersDto>().ReverseMap();
            CreateMap<ApplicationUserNames, ApplicationUser>().ReverseMap();
            CreateMap<UserBasic, ApplicationUser>().ReverseMap();
            CreateMap<UserProfile, ApplicationUser>().ReverseMap();
            CreateMap<Register, RegisterModel>().ReverseMap();

            //Files
            CreateMap<FileDto, File>().ReverseMap();
            CreateMap<FileUpsert, File>().ReverseMap();
            CreateMap<FileInsert, File>().ReverseMap();
            CreateMap<FileBasic, File>().ReverseMap();

            //Notification
            CreateMap<NotificationDto, Notification>().ReverseMap();
            CreateMap<NotificationInsertRequest, Notification>().ReverseMap();

            //Favorites
            CreateMap<FavoritesDto, Favorite>().ReverseMap();
            CreateMap<FavoritesInsertRequest, Favorite>().ReverseMap();

            //Order
            CreateMap<OrderDto, Order>().ReverseMap();
            CreateMap<OrderInsertRequest, Order>().ReverseMap();
            CreateMap<OrderUpsertRequest, Order>().ReverseMap();

            //Rate
            CreateMap<RateDto, Rate>().ReverseMap();
            CreateMap<RateInsertRequest, Rate>().ReverseMap();

            //Rating
            CreateMap<RatingDto, Rating>().ReverseMap();
            CreateMap<RatingInsertRequest, Rating>().ReverseMap();

            //Vehicle
            CreateMap<VehicleDto, Vehicle>().ReverseMap();
            CreateMap<VehicleInsertRequest, Vehicle>().ReverseMap();
            CreateMap<VehicleUpsertRequest, Vehicle>().ReverseMap();

            //Vehicle Type
            CreateMap<VehicleTypeDto, VehicleType>().ReverseMap();
            CreateMap<VehicleTypeInsertRequest, VehicleType>().ReverseMap();


        }
    }
}
