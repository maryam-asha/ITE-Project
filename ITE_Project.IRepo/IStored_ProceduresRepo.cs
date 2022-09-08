using ITE_Project.Dto.Learn_Track;
using ITE_Project.Dto.Stored_ProceduresDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
   public interface IStored_ProceduresRepo
    {
        public List<All_Information_For_Courses_In_LearnTrackDto> All_Information_For_Courses_In_LearnTrack (int LearnTrackId);
        public List<Information_Of_Student_In_LearnTrack_By_DateDto> Information_Of_Student_In_LearnTrack_By_Date(ModelDto dto);
        public List<Search_By_Courses_By_CourseId_And_Level_NameDto> Search_By_Courses_By_CourseId_And_Level_Name(int? CourseId, Level? Level_Name);
        public List<Learn_TrackDto> Search_For_LearnTrack_By_Specialize_Name(int Specialize_Name);
        public List<Select_Details_Scholarship_By_University_Or_StudentDto> Select_Details_Scholarship_By_University_Or_Student(int? UniversityId, int? StudentId);
        public List<Search_For_Course_By_CourseName_and_Level_NameDto> Search_For_Courses_By_CourseName_And_Level_Name(string CourseName, int? Level_Name);
        public List<Get_All_Scholarships_For_StudentDto> Get_All_Scholarships_For_Student();
        public List<Count_Scholarships_For_One_University_TypeDto> Count_Scholarships_For_One_University_Type();
        public List<Get_All_Users_As_StudentDto> Get_All_Users_As_Student();
        public List<Get_All_Users_As_UniversityDto> Get_All_Users_As_University();
        public Count_Of_Student_In_Specialize_Name_Of_LearnTrackDto Count_Of_Student_In_Specialize_Name_Of_LearnTrack(int Specialize_Name);
        public List<Information_Of_LearnTrack_For_StudentDto> Information_Of_LearnTrack_For_Student(int StudentId);
        
        public Get_Rating_and_Count_For_LearnTrackDto Get_Rating_and_Count_For_LearnTrack(int LearnTrackId);
   
        public List<Level_For_Course_SelectedDto> Level_For_Course_Selected(int CourseId);
        public List<LearnTrack_For_SpecializeName_SelectedDto> LearnTrack_For_SpecializeName_Selected(string SpecializeName);
        public List<UniversityNameByScholarDto> UniversityNameByScholar(int ScholarshipId);
       
        public Count_Of_Student_In_LearnTrack_By_DateDto Count_Of_Student_In_LearnTrack_By_Date
            (Count_Of_Student_In_LearnTrack_By_DateDto dto);
        public List<Count_Of_Student_In_Scholarship_By_DateDto> Count_Of_Student_In_Scholarship_By_Date(DateTime FirstDate, DateTime EndDate);
        public List<Search_Scholarship_By_Spec_UniverDto> Search_Scholarship_By_Spec_Univer(int? UniversityId, int? Specialize_Name);
    }
}
