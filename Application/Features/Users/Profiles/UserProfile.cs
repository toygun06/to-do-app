using Application.Features.Users.Commands.SoftDelete;
using Application.Features.Users.Commands.Update;
using Application.Features.Users.Queries.GetById;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<User, UserSoftDeleteCommand>().ReverseMap();
            CreateMap<User, UserSoftDeleteResponse>().ReverseMap();

            CreateMap<User, UpdateUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserResponse>().ReverseMap();

            CreateMap<User, GetUserByIdQuery>().ReverseMap();
            CreateMap<User, GetUserByIdResponse>().ReverseMap();
        }
    }
}
