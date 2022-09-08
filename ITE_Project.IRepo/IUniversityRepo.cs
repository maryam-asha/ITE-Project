using ITE_Project.Dto.University;
using ITE_Project.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
   public  interface IUniversityRepo
    {
        public void AddUniversity(AddUniversityDto addUniversityDto);
        public void DeleteUniversity(int UniversityId);
        public void UpdateUniversity(UniversityDto updateUniversityDto);
        public List<UniversityDto> GetAllUniversities();
        public UniversityDto GetUniversityByID(int UniversityId);


    }
}
