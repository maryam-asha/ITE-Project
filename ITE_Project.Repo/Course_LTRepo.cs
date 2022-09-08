using ITE_Project.Dto.Course_LT;
using AutoMapper;
using ITE_Project.IRepo;
using ITE_Project.Repo.My_Exception;
using MyDbProject;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITE_Project.Dto.Course;
using Microsoft.EntityFrameworkCore;
using ITE_Project.Dto.Student_LT;

namespace ITE_Project.Repo
{
    public class Course_LTRepo : ICourse_LTRepo
    {

        private readonly MyDbContext myDbContext;
        private readonly IMapper mapper;
        public Course_LTRepo(MyDbContext myDbContext, IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }
        public void AddCourse_LT(AddCourse_LTDto addDto)
        {
            var result = mapper.Map<Course_LTEntity>(addDto);
            myDbContext.Course_LT.Add(result);
            myDbContext.SaveChanges();
            throw new SuccessException();
        }

        public void DeleteCourse_LT(int id)
        {
            var result = myDbContext.Course_LT.FirstOrDefault(x => x.CourseLTId == id);
            if (result != null)
            {
                myDbContext.Course_LT.Remove(result);
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public List<Course_LTDto> GetAllCourse_LT()
        {
            List<Course_LTDto> courseLT = new List<Course_LTDto>();
            var result = myDbContext.Courses.ToList();
            foreach (var item in result)
            {
                courseLT.Add(mapper.Map<Course_LTDto>(item));
            }
            return courseLT;
        }
       
        public Course_LTDto GetCourse_LTById(int id)
        {
            var res = myDbContext.Course_LT.FirstOrDefault(x => x.CourseLTId == id);
            if (res == null)
            {
                throw new NotFoundException();
            }
            else
            {
                var result = mapper.Map<Course_LTDto>(res);
                return result;
            }
        }

      

        public void UpdateCourse_LT(Course_LTDto Updatedto)
        {
            var res = mapper.Map<Course_LTEntity>(Updatedto);
            myDbContext.Course_LT.Update(res);
            myDbContext.SaveChanges();
        }
    }
}
