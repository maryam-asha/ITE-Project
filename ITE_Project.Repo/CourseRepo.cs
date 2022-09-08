 using MyDbProject;
using AutoMapper;
using ITE_Project.IRepo;
using System;
using MyTables.Entities;
using ITE_Project.Dto.Course;
using System.Linq;
using ITE_Project.Repo.My_Exception;
using System.Collections.Generic;
using MoreLinq;

namespace ITE_Project.Repo
{
    public class CourseRepo : ICourseRepo
    {
        private readonly MyDbContext myDbContext;
        private readonly IMapper mapper;
        public CourseRepo(MyDbContext myDbContext, IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }
        public void AddCourse(AddCourseDto addDto)
        {
            var result = mapper.Map<CourseEntity>(addDto);
            myDbContext.Courses.Add(result);
            myDbContext.SaveChanges();
           // throw new SuccessException();
        }

        public void DeleteCourse(int id)
        {
            var result = myDbContext.Courses.FirstOrDefault(x => x.CourseId == id);
            if (result != null)
            {
                myDbContext.Courses.Remove(result);
                myDbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }

          
        }

        public List<CourseDto> GetAllCourse2()
        {
            List<CourseDto> courses = new List<CourseDto>();
            var result = myDbContext.Courses.ToList();
            foreach (var item in result)
            {
                courses.Add(mapper.Map<CourseDto>(item));
            }
            return courses;
        }
        public List<CourseDto> GetAllCourse()
        {
            List<CourseDto> courses = new List<CourseDto>();
            var result = myDbContext.Courses.DistinctBy(x => x.CourseName).ToList();
            foreach (var item in result)
            {
                courses.Add(mapper.Map<CourseDto>(item));
            }
            return courses;
        }
        public CourseDto GetCourseById(int id)
        {
            var res = myDbContext.Courses.FirstOrDefault(x => x.CourseId == id);
            if (res == null)
            {
                throw new NotFoundException();
            }
            else
            {
                var result = mapper.Map<CourseDto>(res);
                return result;
            }
        }

        public int GetCourseCount()
        {
          return myDbContext.Courses.Count();
        }

        public void UpdateCourse(CourseDto Updatedto)
        {
           var res = mapper.Map<CourseEntity>(Updatedto);
            myDbContext.Courses.Update(res);
            myDbContext.SaveChanges();

        }
    }
}

