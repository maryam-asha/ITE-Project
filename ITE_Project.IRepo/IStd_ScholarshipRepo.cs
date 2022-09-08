using ITE_Project.Dto.Std_Scholarship;
using ITE_Project.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
   public interface IStd_ScholarshipRepo
    {
        public void TakeStd(int Id);
        public bool AddStd_Scholarship(AddStd_ScholarshipDto addDto);
        public List<Std_ScholarshipDto> MyScholarship(string name);
       public List<Std_ScholarshipDto> GetAllStd_Scholarships_for_University(string name);
        public AddStd_ScholarshipDto AddToUser(int id, string name);
        public void DeleteStd_Scholarship(int Std_Scholarship_Id);
        public void UpdateStd_Scholarship(int Std_Scholarship_Id, UpdateStd_ScholarshipDto updateStd_ScholarshipDto);
        public List<Std_ScholarshipDto> GetAllStd_Scholarships();
        public Std_ScholarshipDto GetStd_ScholarshipByID(int Std_Scholarship_Id);
    } 
}
