using AutoMapper;
using Domain;
using Model.Dto;
using Model.Dto.Files;
using Model.Dto.Location;
using Model.Dto.Users;
using Model.Requests;

namespace Model.Others
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Location, LocationDto>().ReverseMap();
            CreateMap<Location, LocationUpsertRequest>().ReverseMap();
            CreateMap<Location, LocationInsertRequest>().ReverseMap();
            CreateMap<Location, LocationSearchRequest>().ReverseMap();
            CreateMap<ApplicationUser, ApplicationUserRequest>().ReverseMap();
            CreateMap<ApplicationUser, LoginModel>().ReverseMap();
            CreateMap<Register, RegisterModel>().ReverseMap();
            CreateMap<ApplicationUser, UsersDto>().ReverseMap();
            CreateMap<ApplicationUser, UserPatchDto>().ReverseMap();

            CreateMap<ApplicationUser, UserUpsertRequest>().ReverseMap();

            CreateMap<ApplicationUser, UsersDto>().ReverseMap();
            CreateMap<ApplicationUserNames, ApplicationUser>().ReverseMap();


            CreateMap<FileDto, File>().ReverseMap();
            CreateMap<FileUpsert, File>().ReverseMap();
            CreateMap<FileInsert, File>().ReverseMap();

          

           
            CreateMap<UserBasic, ApplicationUser>().ReverseMap();
            CreateMap<UserProfile, ApplicationUser>().ReverseMap();
            CreateMap<LocationBasic, Location>().ReverseMap();
            CreateMap<FileBasic, File>().ReverseMap();
        }
    }
}
