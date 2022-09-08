using ITE_Project.Dto.Learn_Track;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
   public interface ILearn_TrackRepo
    {
        public void AddLearn_Track(AddLearn_TrackDto addDto);
        public void UpdateLearn_Track(Learn_TrackDto Updatedto);
        public void DeleteLearn_Track(int id);
        public Learn_TrackDto GetLearn_TracktById(int id);
        public int GetLearn_TrackCount();
        public List<Learn_TrackDto> GetAllLearn_Track();
    }
}
