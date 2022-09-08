using ITE_Project.Dto.Student_LT;
using ITE_Project.IRepo;
using AutoMapper;
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
using ITE_Project.Dto.Learn_Track;

namespace ITE_Project.Repo
{
    public class Student_LTRepo : IStudent_LTRepo
    {
        private readonly MyDbContext dbContext;
        private readonly IMapper mapper;
        public Student_LTRepo(MyDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public bool AddStudent_LT(AddStudent_LTDto addDto)
        {
            bool x = false;
            var res = dbContext.Student_LTs.FirstOrDefault(x => x.LearnTrackId == addDto.LearnTrackId && x.StudentId == addDto.StudentId);
            if (res == null) {
                var result = mapper.Map<Student_LTEntity>(addDto);
                dbContext.Student_LTs.Add(result);
                dbContext.SaveChanges();
                x = true;
            }
            return x;
          //  throw new SuccessException();
        }
        public List<CourseDto> getcourser(int id)
        {
            List<CourseDto> courses = new List<CourseDto>();
            var result = dbContext.Course_LT
                .Include(m => m.LearnTrack)
                .ThenInclude(m => m.Course_LT)
                .ThenInclude(m => m.Course)
                .Where(m => m.LearnTrackId == id).ToList();
            foreach (var item in result)
            {
                courses.Add(mapper.Map<CourseDto>(item.Course));
            }
            return courses;

        }
        public AddStudent_LTDto AddToUser(int id, string name)
        {
         var result = dbContext.Users.FirstOrDefault(m => m.Email == name);
           int x= result.Id;
           var res =dbContext.Students.FirstOrDefault(m => m.UserId == x);
            AddStudent_LTDto slt = new AddStudent_LTDto()
            {
                LearnTrackId = id,
                StudentId = res.StudentId,
                StartlearnTime = DateTime.Now
               
            };

            return slt;
        }
        public List<Student_LTDto> MyLT(string name)
        {
            var result = dbContext.Users.FirstOrDefault(m => m.Email == name);
            int x = result.Id;
            var res = dbContext.Students.FirstOrDefault(m => m.UserId == x);

            List<Student_LTDto> Lt = new List<Student_LTDto>();

            var resul = dbContext.Student_LTs
                .Include(m => m.Student)
                .Include(m =>m.LearnTrack)
                .Where(m => m.StudentId == res.StudentId).ToList();
            foreach (var item in resul)
            {
                Lt.Add(mapper.Map<Student_LTDto>(item));
            }
            return Lt;

        }

        public void DeleteStudent_LT(int id)
        {
            var result = dbContext.Student_LTs.FirstOrDefault(x => x.Student_LTId == id);
            if (result != null)
            {
                dbContext.Student_LTs.Remove(result);
                dbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }
       
        public List<Student_LTDto> GetAllStudent_LT()
        {
            List<Student_LTDto> student_LTs = new List<Student_LTDto>();
            var result = dbContext.Student_LTs.ToList();
            foreach (var item in result)
            {
                student_LTs.Add(mapper.Map<Student_LTDto>(item));
            }
            return student_LTs;
        }

        public Student_LTDto GetStudent_LTById(int id)
        {
            var res = dbContext.Student_LTs.FirstOrDefault(x => x.Student_LTId == id);
            if (res == null)
            {
                throw new NotFoundException();
            }
            else
            {
                var result = mapper.Map<Student_LTDto>(res);
                return result;
            }
        }

        public void UpdateStudent_LT(int id, UpdateStudent_LTDto Updatedto)
        {
            var result = dbContext.Student_LTs.FirstOrDefault(x => x.Student_LTId == id);
            if (result != null)
            {
                var res = mapper.Map<Student_LTEntity>(Updatedto);
            }
            else
            {
                throw new NotFoundException();
            }

            dbContext.SaveChanges();
        }

        public void Updaterating(int id, float rating )
        {
            var result = dbContext.Student_LTs.FirstOrDefault(x => x.Student_LTId == id);
                 result.Rating = rating;
                dbContext.SaveChanges();
        }
        }
}

