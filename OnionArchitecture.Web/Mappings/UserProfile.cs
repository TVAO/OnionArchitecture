using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using OnionArchitecture.Data.DTO;
using OnionArchitecture.Repository.Models;
using OnionArchitecture.Web.ViewModels;

namespace OnionArchitecture.Web.Mappings
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserViewModel, UserDTO>().ReverseMap();
            CreateMap<UserViewModel, NewUserDTO>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
            //CreateMap<NewUserDTO, UserLoginViewModel>().ReverseMap()
            //    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.UserName));
        }

    }
}
