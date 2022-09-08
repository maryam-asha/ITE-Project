using AutoMapper;
using ITE_Project.Dto.Course_LT;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles
{

    public class Course_LTProfile : Profile
    {
        public Course_LTProfile()
        {
            //Course_LTDto
            CreateMap<Course_LTDto, Course_LTEntity>();
            CreateMap<Course_LTEntity, Course_LTDto>();
          
            //  CreateMap<Course_LTEntity, Course_LTDto>();

            //AddCourse_LTDto
            // CreateMap<AddCourse_LTDto, Course_LTEntity>();

            CreateMap<Course_LTEntity, AddCourse_LTDto>();


            //UpdateCourse_LTDto
           // CreateMap<UpdateCourse_LTDto, Course_LTEntity>();

            CreateMap<Course_LTEntity, UpdateCourse_LTDto>();
        }

    }
 }

