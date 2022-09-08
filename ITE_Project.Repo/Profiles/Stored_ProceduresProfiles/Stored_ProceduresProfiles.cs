using AutoMapper;
using ITE_Project.Dto.Learn_Track;
using ITE_Project.Dto.Stored_ProceduresDto;
using MyTables.Entities.Stored_ProceduresEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo.Profiles.Stored_ProceduresProfiles
{
  public class Stored_ProceduresProfiles : Profile
    {
        public Stored_ProceduresProfiles() {
            CreateMap<Information_Of_Student_In_LearnTrack_By_DateEntity, Information_Of_Student_In_LearnTrack_By_DateDto>();
            CreateMap<Search_For_Course_By_CourseName_and_Level_NameEntity, Search_For_Course_By_CourseName_and_Level_NameDto>();
            CreateMap<All_Information_For_Courses_In_LearnTrackEntity, All_Information_For_Courses_In_LearnTrackDto>();
            CreateMap<Search_By_Courses_By_CourseId_And_Level_NameEntity, Search_By_Courses_By_CourseId_And_Level_NameDto>();
            CreateMap<Search_For_LearnTrack_By_Specialize_NameEntity, Search_For_LearnTrack_By_Specialize_NameDto>();
            CreateMap<Get_All_Users_As_StudentEntity, Get_All_Users_As_StudentDto>();
            CreateMap<Get_All_Users_As_UniversityEntity, Get_All_Users_As_UniversityDto>();
            CreateMap<Count_Of_Student_In_Specialize_Name_Of_LearnTrackEntity, Count_Of_Student_In_Specialize_Name_Of_LearnTrackDto>();
            CreateMap<Information_Of_LearnTrack_For_StudentEntity, Information_Of_LearnTrack_For_StudentDto>();
            CreateMap<Count_Scholarships_For_One_University_TypeEntity, Count_Scholarships_For_One_University_TypeDto>();
            CreateMap<Get_All_Scholarships_For_StudentEntity, Get_All_Scholarships_For_StudentDto>();
            CreateMap<Select_Details_Scholarship_By_University_Or_StudentEntity, Select_Details_Scholarship_By_University_Or_StudentDto>();
            CreateMap<Select_Details_Scholarship_By_University_Or_StudentEntity, Select_Details_Scholarship_By_University_Or_StudentDto>();
            CreateMap<LearnTrack_For_SpecializeName_SelectedEntity, LearnTrack_For_SpecializeName_SelectedDto>();
            CreateMap<Level_For_Course_SelectedEntity, Level_For_Course_SelectedDto>();
            CreateMap<Count_Of_Student_In_LearnTrack_By_DateEntity, Count_Of_Student_In_LearnTrack_By_DateDto>();
            CreateMap<Get_Rating_and_Count_For_LearnTrackEntity, Get_Rating_and_Count_For_LearnTrackDto>();
            CreateMap<UniversityNameByScholarEntity, UniversityNameByScholarDto>();
            CreateMap<Search_For_LearnTrack_By_Specialize_NameEntity, Learn_TrackDto>();
            CreateMap<Search_Scholarship_By_Spec_UniverEntity, Search_Scholarship_By_Spec_UniverDto>();
            CreateMap<Count_Of_Student_In_Scholarship_By_DateEntity, Count_Of_Student_In_Scholarship_By_DateDto>();
        }
    }
}
