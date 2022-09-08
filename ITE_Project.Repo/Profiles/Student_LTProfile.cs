using AutoMapper;
using ITE_Project.Dto.Student_LT;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles
{
   public class Student_LTProfile:Profile
   {
        public Student_LTProfile() { 

        //Student_LTDto
        CreateMap<Student_LTEntity, Student_LTDto>();
         CreateMap<Student_LTDto, Student_LTEntity > ();

            //AddStudent_LTDto
            CreateMap<AddStudent_LTDto, Student_LTEntity>();

      //UpdateStudent_LTDto
            CreateMap<UpdateStudent_LTDto, Student_LTEntity>();
        }
    }
}
