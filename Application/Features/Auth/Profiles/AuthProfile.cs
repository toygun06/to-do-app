using Application.Features.Auth.Command.Login;
using Application.Features.Auth.Command.Register;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Auth.Profiles
{
    public class AuthProfile : Profile
    {
        public AuthProfile() 
        {
            CreateMap<User, UserRegisterCommand>().ReverseMap();
            CreateMap<User, UserRegisterResponse>().ReverseMap();

            CreateMap<User, LoginResponse>().ReverseMap();
        }
    }
}
