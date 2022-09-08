using AutoMapper;
using ITE_Project.Dto.Student;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles
{
   public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            //StudentDto
            CreateMap<StudentEntity, StudentDto>();
            CreateMap< StudentDto, StudentEntity>();
            //AddStudentDto
            CreateMap<AddStudentDto, StudentEntity>();
            //UpdateStudentDto
            CreateMap<UpdateStudentDto, StudentEntity>();


        }
    }
}
