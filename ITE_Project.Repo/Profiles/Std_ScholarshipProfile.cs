using AutoMapper;
using ITE_Project.Dto.Std_Scholarship;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles
{
    public class Std_ScholarshipProfile : Profile
    {
       public Std_ScholarshipProfile()
       {
            //Std_ScholarshipDto
            CreateMap<Std_ScholarshipEntity, Std_ScholarshipDto>();
            //AddStd_ScholarshipDto
            CreateMap<AddStd_ScholarshipDto, Std_ScholarshipEntity>();
           //UpdateStd_ScholarshipDto
            CreateMap<UpdateStd_ScholarshipDto, Std_ScholarshipEntity>();




        }
    }
}
