using AutoMapper;
using ITE_Project.Dto.Learn_Track;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles
{
   public class Learn_TrackProfile :Profile
    {
        public Learn_TrackProfile()
        {
            //Learn_TrackDto
            CreateMap<Learn_TrackEntity, Learn_TrackDto>();


            //CreateMap<Learn_TrackDto, Learn_TrackEntity>();

            //AddLearn_TrackDto
            // CreateMap<Learn_TrackEntity, AddLearn_TrackDto>();

             CreateMap<AddLearn_TrackDto, Learn_TrackEntity>();
            CreateMap<Learn_TrackDto, Learn_TrackEntity>();

            //UpdateLearn_TrackDto
            // CreateMap<Learn_TrackEntity, UpdateLearn_TrackDto>();

            //CreateMap<UpdateLearn_TrackDto, Learn_TrackEntity>();

        }
    }
}
