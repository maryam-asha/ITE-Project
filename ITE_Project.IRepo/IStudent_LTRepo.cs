using ITE_Project.Dto.Course;
using ITE_Project.Dto.Student_LT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
   public interface IStudent_LTRepo
    {
        public List<CourseDto> getcourser(int id);
        public List<Student_LTDto> MyLT(string name);
        public AddStudent_LTDto AddToUser(int id, string name);
        public bool AddStudent_LT(AddStudent_LTDto addDto);
        public void UpdateStudent_LT(int id, UpdateStudent_LTDto Updatedto);
        public void DeleteStudent_LT(int id);
        public Student_LTDto GetStudent_LTById(int id);
        public void Updaterating(int id, float rating);
        public List<Student_LTDto> GetAllStudent_LT();
    }
}
