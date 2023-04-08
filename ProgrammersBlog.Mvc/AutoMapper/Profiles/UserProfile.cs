using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LionsTimes.Entities.Concrete;
using LionsTimes.Entities.Dtos;

namespace LionsTimes.Mvc.AutoMapper.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserAddDto, User>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
