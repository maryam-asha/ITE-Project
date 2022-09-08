using ITE_Project.Dto;
using ITE_Project.Dto.Scholarship;
using ITE_Project.Dto.Std_Scholarship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
    public interface IScholarshipRepo
    {
        public void AddScholarship(AddScholarshipDto addScholarshipDto);

        public List<Std_ScholarshipDto> SearchStudentsByName(String Fullname);
        public List<ScholarshipDto> GetScholarshipByUniversty(int universtyId);
        public AddScholarshipDto getall();
        public List<ScholarshipDto> getScholarship(string name);
        public void DeleteScholarship(int ScholarshipId);
        public void UpdateScholarship(ScholarshipDto Updatedto);
        public List<ScholarshipDto> GetAllSholarships();
        public ScholarshipDto GetScholarshipByID(int ScholarshipId);
        public int CountScholarship();
        //public AddScholarshipDto AddScholarshipWithList();
    }
}
