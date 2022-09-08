using ITE_Project.Dto.Course;
using System.Collections.Generic;

namespace ITE_Project.IRepo
{
    public interface ICourseRepo
    {
        public void AddCourse(AddCourseDto addDto);
        public void UpdateCourse(CourseDto Updatedto);
        public void DeleteCourse(int id);
        public CourseDto GetCourseById(int id);
        public int GetCourseCount();
        public List<CourseDto> GetAllCourse();
        public List<CourseDto> GetAllCourse2();
    }
}
