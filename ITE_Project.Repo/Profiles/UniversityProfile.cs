using AutoMapper;
using ITE_Project.Dto.University;
using ITE_Project.Dto.User;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles
{
   public class UniversityProfile :Profile
    {
        public UniversityProfile() {
            //UniversityDto
            CreateMap<UniversityEntity,UniversityDto >();
            CreateMap< UniversityDto, UniversityEntity>();
            //AddUniversityDto
            CreateMap<AddUniversityDto, UniversityEntity>();
            //UpdateUniversityDto
            CreateMap<UpdateUniversityDto, UniversityEntity>();






        }
    }
}
