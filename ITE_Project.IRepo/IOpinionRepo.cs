using ITE_Project.Dto.Opinion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
   public interface IOpinionRepo
    {
        public void AddOpinion(AddOpinionDto addDto);
        public void AddOpinionWithImage(AddOpinionWithImageDto addDto);
        public void UpdateOpinion( OpinionDto Updatedto);
        public void DeleteOpinion(int id);
        public OpinionDto GetOpinionById(int id);
        public int GetOpinionCount();
        public List<OpinionDto> GetAllOpinion();
    }
}
