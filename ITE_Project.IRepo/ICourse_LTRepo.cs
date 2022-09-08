using ITE_Project.Dto.Course;
using ITE_Project.Dto.Course_LT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
   public interface ICourse_LTRepo
    {
        public void AddCourse_LT(AddCourse_LTDto addDto);
        public void UpdateCourse_LT(Course_LTDto Updatedto);
        public void DeleteCourse_LT(int id);
      
        public Course_LTDto GetCourse_LTById(int id);
        public List<Course_LTDto> GetAllCourse_LT();

    }
}
