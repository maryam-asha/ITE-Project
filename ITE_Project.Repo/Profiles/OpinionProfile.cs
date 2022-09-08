using AutoMapper;
using ITE_Project.Dto.Opinion;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles
{
   public class OpinionProfile :Profile
    {
        public OpinionProfile()
        {
            //OpinionDto
            CreateMap<OpinionEntity, OpinionDto>();

            
            //AddOpinionDto
            CreateMap<AddOpinionDto, OpinionEntity>();

            // //AddOpinionWithImageDto
            CreateMap<AddOpinionWithImageDto, OpinionEntity>();

            //UpdateOpinionDto
           CreateMap<OpinionDto, OpinionEntity>();

           
        }
    }
}
