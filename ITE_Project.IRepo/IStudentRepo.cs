using ITE_Project.Dto.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
    public interface IStudentRepo
    {
        public StudentDto GetStudentByEmail(string name);
        public void AddStudent(AddStudentDto addStudentDto);
        public void DeleteStudent(int StudentId);
        public void UpdateStudent(StudentDto updateStudentDto);
        public List<StudentDto> GetAllStudents();
        public StudentDto GetStudentByID(int StudentId);

    }
}
