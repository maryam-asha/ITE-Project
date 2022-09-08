using AutoMapper;
using ITE_Project.Dto.Scholarship;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles
{
   public class ScholarshipProfile :Profile
    {
        public ScholarshipProfile() {
            //ScholarshipDto
            CreateMap<ScholarshipEntity, ScholarshipDto>();
            CreateMap<ScholarshipDto, ScholarshipEntity>();
            //AddScholarshipDto
            CreateMap<AddScholarshipDto, ScholarshipEntity>();
            //UpdateScholarshipDto
            //CreateMap<UpdateScholarshipDto, ScholarshipEntity>();

           
        }
    }
}
