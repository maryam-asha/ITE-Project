using ITE_Project.Dto.Opinion;
using ITE_Project.IRepo;
using AutoMapper;
using ITE_Project.Repo.My_Exception;
using MyDbProject;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo
{
    public class OpinionRepo : IOpinionRepo
    {
        private readonly MyDbContext myDbContext;
        private readonly IMapper mapper;
        public OpinionRepo(MyDbContext myDbContext, IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }
        public void AddOpinion(AddOpinionDto addDto)
        {

            var result = mapper.Map<OpinionEntity>(addDto);
            myDbContext.opinions.Add(result);
            myDbContext.SaveChanges();
          //  throw new SuccessException();
        }

        public void AddOpinionWithImage(AddOpinionWithImageDto addDto)
        {
            var result = mapper.Map<OpinionEntity>(addDto);
            myDbContext.opinions.Add(result);
            myDbContext.SaveChanges();
           // throw new SuccessException();
        }

        public void DeleteOpinion(int id)
        {

            var result = myDbContext.opinions.FirstOrDefault(x => x.OpinionsId == id);
            if (result == null)
            {
                throw new NotFoundException();

            }
            else
            {
               myDbContext.opinions.Remove(result);
                myDbContext.SaveChanges();
            }
        }

        public List<OpinionDto> GetAllOpinion()
        {
        List<OpinionDto> opinions = new List<OpinionDto>();
            var result = myDbContext.opinions.ToList();
            foreach (var item in result)
            {
                opinions.Add(mapper.Map<OpinionDto>(item));
            }
            return opinions;
        }
       
        public OpinionDto GetOpinionById(int id)
        {
            var res = myDbContext.opinions.FirstOrDefault(x => x.OpinionsId == id);
            if (res == null)
            {
                throw new NotFoundException();
            }
            else
            {
                var result = mapper.Map<OpinionDto>(res);
                return result;
            }
        }

        public int GetOpinionCount()
        {
            return myDbContext.opinions.Count();
        }

        public void UpdateOpinion(OpinionDto Updatedto)
        {
           var res = mapper.Map<OpinionEntity>(Updatedto);
                myDbContext.opinions.Update(res);
                 myDbContext.SaveChanges();  
        }
    }
}
