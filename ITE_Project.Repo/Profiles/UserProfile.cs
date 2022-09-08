using AutoMapper;
using ITE_Project.Dto.User;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles
{
  public class UserProfile : Profile
    {
        public UserProfile() {
            //UserDto
            CreateMap<UserEntity, UserDto>();
         
            //AddUserDto
            CreateMap<AddUserDto, UserEntity>();
            CreateMap<UserDto, UserEntity>();

        }
    }
} 
