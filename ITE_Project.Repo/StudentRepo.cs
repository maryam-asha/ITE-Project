using System;
using ITE_Project.Repo.My_Exception;
using MyDbProject;
using MyTables.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITE_Project.IRepo;
using ITE_Project.Dto.Student;
using Microsoft.EntityFrameworkCore;

namespace ITE_Project.Repo
{

    public class StudentRepo : IStudentRepo
    {
        private readonly IMapper mapper;
        private readonly MyDbContext myDbContext;
        public StudentRepo(IMapper mapper, MyDbContext myDbContext)
        {
            this.mapper = mapper;
            this.myDbContext = myDbContext;
        }
        public void AddStudent(AddStudentDto addStudentDto)
        {
            var result = mapper.Map<StudentEntity>(addStudentDto);
            myDbContext.Students.Add(result);
            myDbContext.SaveChanges();
        }

        public void DeleteStudent(int StudentId)
        {
            var result = myDbContext.Students.Include(m => m.user).FirstOrDefault(x => x.StudentId == StudentId);
            if (result!=null)
            {
                myDbContext.Students.Remove(result);
                myDbContext.SaveChanges();

            }
            else
            {
                throw new NotFoundException();
            }



        }

        public List<StudentDto> GetAllStudents()
        {
            List<StudentDto> Student = new List<StudentDto>();
            var result = myDbContext.Students.Include(m => m.user).ToList();
            foreach (var item in result)
            {
                Student.Add(mapper.Map<StudentDto>(item));


            }
            return Student;
           
        }

        public StudentDto GetStudentByID(int StudentId)
        {
            var result = myDbContext.Students.Include(m => m.user).FirstOrDefault(x => x.StudentId == StudentId);
            if (result == null)
            {
                throw new NotFoundException();
            }
            else
            {
                var Result = mapper.Map<StudentDto>(result);
                return Result;
            }
        }
        public StudentDto GetStudentByEmail(string name)
        {
            var result = myDbContext.Users.FirstOrDefault(m => m.Email == name);
            int x = result.Id;
            var res = myDbContext.Students.FirstOrDefault(m => m.UserId == x);

            if (res == null)
            {
                throw new NotFoundException();
            }
            else
            {
                var Result = mapper.Map<StudentDto>(res);
                return Result;
            }
        }
        public void UpdateStudent(StudentDto updateStudentDto)
        {
            var res = mapper.Map<StudentEntity>(updateStudentDto);
            myDbContext.Students.Update(res);
            myDbContext.SaveChanges();
        }
    }
}
