using AutoMapper;
using ITE_Project.Dto.Learn_Track;
using ITE_Project.Dto.Stored_ProceduresDto;
using ITE_Project.IRepo;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyDbProject;
using MyTables.Entities.Stored_ProceduresEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo
{
    public class Stored_ProceduresRepo : IStored_ProceduresRepo
    {
        private readonly IMapper mapper;
        private readonly MyDbContext myDbContext;
        public Stored_ProceduresRepo(IMapper mapper, MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }
        public List<All_Information_For_Courses_In_LearnTrackDto> All_Information_For_Courses_In_LearnTrack(int LearnTrackId)
        {
            List<All_Information_For_Courses_In_LearnTrackDto> all_Information_For_Courses_In_LearnTrack = new List<All_Information_For_Courses_In_LearnTrackDto>();
            SqlParameter parameter = new SqlParameter("@LearnTrackId", LearnTrackId);
            var res = myDbContext.All_Information_For_Courses_In_LearnTracks.FromSqlRaw("All_Information_For_Courses_In_LearnTrack @LearnTrackId", parameter);
            foreach (var item in res)
            {
                all_Information_For_Courses_In_LearnTrack.Add(mapper.Map<All_Information_For_Courses_In_LearnTrackDto>(item));
            }
            return all_Information_For_Courses_In_LearnTrack;
        }
    

     


        public List< Search_By_Courses_By_CourseId_And_Level_NameDto> Search_By_Courses_By_CourseId_And_Level_Name(int? CourseId, Level? Level_Name)
        {
            List<Search_By_Courses_By_CourseId_And_Level_NameDto> Search_By_Courses_By_CourseId_And_Level_Name = new List<Search_By_Courses_By_CourseId_And_Level_NameDto>();
            SqlParameter parameter1 = new SqlParameter("@CourseId", CourseId);
            parameter1.Value = (CourseId == null) ? DBNull.Value : CourseId;
            SqlParameter parameter2 = new SqlParameter("@Level_Name", Level_Name);
            parameter2.Value = (Level_Name == null) ? DBNull.Value : Level_Name;
            var res = myDbContext.Search_By_Courses_By_CourseId_And_Level_Names.FromSqlRaw("Search_By_Courses_By_CourseId_And_Level_Name @CourseId,@Language_Name", parameter1, parameter2).ToList();
            foreach (var item in res)
            {
                 Search_By_Courses_By_CourseId_And_Level_Name.Add(mapper.Map<Search_By_Courses_By_CourseId_And_Level_NameDto>(res));
            }
            
            return Search_By_Courses_By_CourseId_And_Level_Name;
        }

      
        public List<Learn_TrackDto> Search_For_LearnTrack_By_Specialize_Name(int Specialize_Name)
        {
            List<Learn_TrackDto> search_For_LearnTrack_By_Specialize_Name = new List<Learn_TrackDto>();
            SqlParameter parameter = new SqlParameter("@Specialize_Name", Specialize_Name);
            var res = myDbContext.Search_For_LearnTrack_By_Specialize_Names.FromSqlRaw("Search_For_LearnTrack_By_Specialize_Name @Specialize_Name", parameter);
            foreach (var item in res)
            {
                search_For_LearnTrack_By_Specialize_Name.Add(mapper.Map<Learn_TrackDto>(item));
            }
            return search_For_LearnTrack_By_Specialize_Name;
        }


        public List<Count_Scholarships_For_One_University_TypeDto> Count_Scholarships_For_One_University_Type()
        {
            List<Count_Scholarships_For_One_University_TypeDto> Count_Scholarships_For_One_University_Type = new List<Count_Scholarships_For_One_University_TypeDto>();
            var data = myDbContext.CountScholarshipsForOneUniversityTypes.FromSqlRaw("[dbo].[CountScholarshipsForOneUniversityType]").ToList();
            foreach (var item in data)
            {
                Count_Scholarships_For_One_University_Type.Add(mapper.Map<Count_Scholarships_For_One_University_TypeDto>(data));
            }
            return Count_Scholarships_For_One_University_Type;
        }
        public List<Information_Of_Student_In_LearnTrack_By_DateDto> Information_Of_Student_In_LearnTrack_By_Date(ModelDto dto)
        {
            List<Information_Of_Student_In_LearnTrack_By_DateDto> information_Of_Student_In_LearnTrack_By_Date = new List<Information_Of_Student_In_LearnTrack_By_DateDto>();
            SqlParameter param1 = new SqlParameter("@FirstDate", dto.StartDate);
            SqlParameter param2 = new SqlParameter("@EndDate", dto.EndDate);
            SqlParameter param3 = new SqlParameter("@LearnTrackId", dto.LearnTrackId);
            var res = myDbContext.Information_Of_Student_In_LearnTrack_By_Dates.FromSqlRaw("Information_Of_Student_In_LearnTrack_By_Date @FirstDate ,@EndDate,@LearnTrackId",
                param1, param2, param3).ToList();
            foreach (var item in res)
            {
                information_Of_Student_In_LearnTrack_By_Date.Add(mapper.Map<Information_Of_Student_In_LearnTrack_By_DateDto>(item));
            }
            return information_Of_Student_In_LearnTrack_By_Date;
        }

        public List<Search_For_Course_By_CourseName_and_Level_NameDto> Search_For_Courses_By_CourseName_And_Level_Name(string CourseName, int? Level_Name)
        {
            //string l = Level_Name.ToString();
            List<Search_For_Course_By_CourseName_and_Level_NameDto> Search_For_Course_By_CourseName_and_Level_Name = new List<Search_For_Course_By_CourseName_and_Level_NameDto>();
            SqlParameter parameter1 = new SqlParameter("@CourseName", CourseName);
            parameter1.Value = (CourseName == null) ? DBNull.Value : CourseName;
            SqlParameter parameter2 = new SqlParameter("@Level_Name", Level_Name);
            parameter2.Value = (Level_Name == null) ? DBNull.Value : Level_Name;
            var res = myDbContext.Search_By_Courses_By_CourseName_And_Level_Names.FromSqlRaw("Search_For_Course_By_CourseName_And_Level_Name @CourseName,@Level_Name",
                parameter1, parameter2).ToList();
            foreach (var item in res)
            {
                Search_For_Course_By_CourseName_and_Level_Name.Add(mapper.Map<Search_For_Course_By_CourseName_and_Level_NameDto>(item));
            }
            return Search_For_Course_By_CourseName_and_Level_Name;
        }
        public List<Get_All_Scholarships_For_StudentDto> Get_All_Scholarships_For_Student()
        {

            List<Get_All_Scholarships_For_StudentDto> Get_All_Scholarships_For_Student = new List<Get_All_Scholarships_For_StudentDto>();
            var data = myDbContext.GetAllScholarshipsForStudents.FromSqlRaw("[dbo].[GetAllScholarshipsForStudent]").ToList();
            foreach (var item in data)
            {
                Get_All_Scholarships_For_Student.Add(mapper.Map<Get_All_Scholarships_For_StudentDto>(item));
            }
            return Get_All_Scholarships_For_Student;
        }

        public List<Search_Scholarship_By_Spec_UniverDto> Search_Scholarship_By_Spec_Univer(int? UniversityId,int? Specialize_Name)
        {
            List<Search_Scholarship_By_Spec_UniverDto> Search_Scholarship_By_Spec_Univer = new List<Search_Scholarship_By_Spec_UniverDto>();
            SqlParameter param1 = new SqlParameter("@UniversityId", UniversityId);
            param1.Value = (UniversityId == null) ? DBNull.Value : UniversityId;
            SqlParameter param2 = new SqlParameter("@Specialize_Name", Specialize_Name);
            param2.Value = (Specialize_Name == null) ? DBNull.Value : Specialize_Name;

            var res = myDbContext.SearchScholarshipBySpecUnivers.FromSqlRaw("SearchScholarshipBySpecUniver @UniversityId,@Specialize_Name ", param1, param2).ToList();
            foreach (var item in res)
            {
                Search_Scholarship_By_Spec_Univer.Add(mapper.Map<Search_Scholarship_By_Spec_UniverDto>(item));

            }
            return Search_Scholarship_By_Spec_Univer;
        }

        public List<Select_Details_Scholarship_By_University_Or_StudentDto> Select_Details_Scholarship_By_University_Or_Student(int? UniversityId, int? StudentId)
        {
            List<Select_Details_Scholarship_By_University_Or_StudentDto> Select_Details_Scholarship_By_University_Or_Student = new List<Select_Details_Scholarship_By_University_Or_StudentDto>();
            SqlParameter param1 = new SqlParameter("@UniversityId", UniversityId);
            param1.Value = (UniversityId == null) ? DBNull.Value : UniversityId;
            SqlParameter param2 = new SqlParameter("@StudentId", StudentId);
            param2.Value = (StudentId == null) ? DBNull.Value : StudentId;
            var res = myDbContext.Select_Details_Scholarship_By_University_Or_Students.FromSqlRaw("Select_Details_Scholarship_By_University_Or_Student @UniversityId ,@StudentId", param1, param2).ToList();
            foreach (var item in res)
            {
                Select_Details_Scholarship_By_University_Or_Student.Add(mapper.Map<Select_Details_Scholarship_By_University_Or_StudentDto>(item));

            }
            return Select_Details_Scholarship_By_University_Or_Student;
        }
        public List<Get_All_Users_As_StudentDto> Get_All_Users_As_Student()
        {
            List<Get_All_Users_As_StudentDto> Get_All_Users_As_Student = new List<Get_All_Users_As_StudentDto>();
            var data = myDbContext.GetAllUsersAsStudents.FromSqlRaw("[dbo].[GetAllScholarshipsForStudent]").ToList();
            foreach (var item in data)
            {
                Get_All_Users_As_Student.Add(mapper.Map<Get_All_Users_As_StudentDto>(data));
            }
            return Get_All_Users_As_Student;
        }
        public List<Get_All_Users_As_UniversityDto> Get_All_Users_As_University()
        {
            List<Get_All_Users_As_UniversityDto> Get_All_Users_As_University = new List<Get_All_Users_As_UniversityDto>();
            var data = myDbContext.GetAllUsersAsUniversities.FromSqlRaw("[dbo].[GetAllUsersAsUniversity]").ToList();
            foreach (var item in data)
            {
                Get_All_Users_As_University.Add(mapper.Map<Get_All_Users_As_UniversityDto>(data));
            }
            return Get_All_Users_As_University;
        }
        public Count_Of_Student_In_Specialize_Name_Of_LearnTrackDto Count_Of_Student_In_Specialize_Name_Of_LearnTrack(int Specialize_Name)
        {
            SqlParameter parameter = new SqlParameter("@Specialize_Name", Specialize_Name);
            var res = myDbContext.Count_Of_Student_In_Specialize_Name_Of_LearnTracks.FromSqlRaw("Count_Of_Student_In_Specialize_Name_Of_LearnTrack @Specialize_Name", parameter).ToList().FirstOrDefault();
            var result = mapper.Map<Count_Of_Student_In_Specialize_Name_Of_LearnTrackDto>(res);
            return result;
        }
        public List<Information_Of_LearnTrack_For_StudentDto> Information_Of_LearnTrack_For_Student(int StudentId)
        {
            List<Information_Of_LearnTrack_For_StudentDto> Information_Of_LearnTrack_For_Student = new List<Information_Of_LearnTrack_For_StudentDto>();
            SqlParameter parameter = new SqlParameter("@StudentId", StudentId);
            var res = myDbContext.Information_Of_LearnTrack_For_Students.FromSqlRaw("Information_Of_LearnTrack_For_Student @LearnTrackId", parameter).ToList();
            foreach (var item in res)
            {
                Information_Of_LearnTrack_For_Student.Add(mapper.Map<Information_Of_LearnTrack_For_StudentDto>(item));
            }
            return Information_Of_LearnTrack_For_Student;
        }

        
        public Dto.Stored_ProceduresDto.Get_Rating_and_Count_For_LearnTrackDto Get_Rating_and_Count_For_LearnTrack(int LearnTrackId)
        {
            SqlParameter parameter1 = new SqlParameter("@LearnTrackId", LearnTrackId);
            var res = myDbContext.Get_Rating_and_Count_For_LearnTracks.FromSqlRaw("Get_Rating_and_Count_For_LearnTrack @LearnTrackId", parameter1).ToList();
            var result = mapper.Map<Dto.Stored_ProceduresDto.Get_Rating_and_Count_For_LearnTrackDto>(res);
            return result;
        }
      
        public Count_Of_Student_In_LearnTrack_By_DateDto Count_Of_Student_In_LearnTrack_By_Date(Count_Of_Student_In_LearnTrack_By_DateDto dto)
        {
            SqlParameter param1 = new SqlParameter("@FirstDate", dto.StartDate);
            SqlParameter param2 = new SqlParameter("@EndDate", dto.EndDate);
            SqlParameter param3 = new SqlParameter("@LearnTrakId", dto.LearnTrackId);
            var res = myDbContext.Count_Of_Student_In_LearnTrack_By_Dates.FromSqlRaw("Count_Of_Student_In_LearnTrack_By_Date @FirstDate ,@EndDate,@LearnTrakId",
                param1, param2, param3).ToList().FirstOrDefault();
            var result = mapper.Map<Count_Of_Student_In_LearnTrack_By_DateDto>(res);
            return result;
        }
        public List<Level_For_Course_SelectedDto> Level_For_Course_Selected(int CourseId)
        {
            List<Level_For_Course_SelectedDto> Level_For_Course_Selected = new List<Level_For_Course_SelectedDto>();
            SqlParameter parameter = new SqlParameter("@CourseId", CourseId);
            var res = myDbContext.Level_For_Course_Selecteds.FromSqlRaw("Level_For_Course_Selected @CourseId", parameter).ToList();
            foreach (var item in res)
            {
                Level_For_Course_Selected.Add(mapper.Map<Level_For_Course_SelectedDto>(item));
            }
            return Level_For_Course_Selected;

        }
        public List<LearnTrack_For_SpecializeName_SelectedDto> LearnTrack_For_SpecializeName_Selected(string SpecializeName)
        {
            List<LearnTrack_For_SpecializeName_SelectedDto> LearnTrack_For_SpecializeName_Selected = new List<LearnTrack_For_SpecializeName_SelectedDto>();
            SqlParameter parameter = new SqlParameter("@SpecializeName", SpecializeName);
            var res = myDbContext.LearnTrack_For_SpecializeName_Selecteds.FromSqlRaw("LearnTrack_For_SpecializeName_Selected @SpecializeName", parameter).ToList();
            foreach (var item in res)
            {
                LearnTrack_For_SpecializeName_Selected.Add(mapper.Map<LearnTrack_For_SpecializeName_SelectedDto>(item));
            }
            return LearnTrack_For_SpecializeName_Selected;

        }
        public List<UniversityNameByScholarDto> UniversityNameByScholar(int ScholarshipId)
        {
            List<UniversityNameByScholarDto> UniversityNameByScholar = new List<UniversityNameByScholarDto>();
            SqlParameter parameter1 = new SqlParameter("@ScholarshipId", ScholarshipId);
            var res = myDbContext.UniversityNameByScholars.FromSqlRaw("UniversityNameByScholar @ScholarshipId", parameter1).ToList();
            foreach (var item in res)
            {
                UniversityNameByScholar.Add(mapper.Map<UniversityNameByScholarDto>(item));
            }
            return UniversityNameByScholar;

        }
        public List<Count_Of_Student_In_Scholarship_By_DateDto> Count_Of_Student_In_Scholarship_By_Date(DateTime FirstDate, DateTime EndDate)
        {
            List<Count_Of_Student_In_Scholarship_By_DateDto> Count_Of_Student_In_Scholarship_By_Date = new List<Count_Of_Student_In_Scholarship_By_DateDto>();
            SqlParameter param1 = new SqlParameter("@FirstDate", FirstDate);
            SqlParameter param2 = new SqlParameter("@EndDate", EndDate);
            var res = myDbContext.Count_Of_Student_In_Scholarship_By_Dates.FromSqlRaw("Count_Of_Student_In_Scholarship_By_Date @FirstDate ,@EndDate", param1, param2).ToList();

            foreach (var item in res)
            {
                Count_Of_Student_In_Scholarship_By_Date.Add(mapper.Map<Count_Of_Student_In_Scholarship_By_DateDto>(item));
            }
            return Count_Of_Student_In_Scholarship_By_Date;
        }

    }
}
