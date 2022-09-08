using AutoMapper;
using ITE_Project.Dto.Course;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ITE_Project.Repo.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            //CourseDto
            CreateMap<CourseEntity, CourseDto>();
            CreateMap<CourseDto, CourseEntity>();
            CreateMap<AddCourseDto, CourseEntity>();

            //  CreateMap<CourseDto, CourseEntity>();

            //AddCourseDto
            //  CreateMap<CourseEntity, AddCourseDto>();


            //UpdateCourseDto
            // CreateMap<CourseEntity, UpdateCourseDto>();

            // CreateMap<UpdateCourseDto, CourseEntity>();
        }
    }
}
