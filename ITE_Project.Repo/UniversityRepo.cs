using AutoMapper;
using ITE_Project.Repo.My_Exception;
using MyTables.Entities;
using ITE_Project.Dto.University;
using ITE_Project.IRepo;
using MyDbProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITE_Project.Repo
{
    public class UniversityRepo : IUniversityRepo
    {
        private readonly MyDbContext myDbContext ;
        private readonly IMapper mapper;
        public UniversityRepo(MyDbContext myDbContext, IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }
        
        public void AddUniversity(AddUniversityDto addUniversityDto)
        {
            myDbContext.Universities.Add(mapper.Map<UniversityEntity>(addUniversityDto));
            myDbContext.SaveChanges();
        }

        public void DeleteUniversity(int UniversityId)
        {
            var result = myDbContext.Universities.Include(m => m.user).FirstOrDefault(x => x.UniversityId == UniversityId);
            if (result!=null)
            {
                myDbContext.Universities.Remove(result);
                myDbContext.SaveChanges();
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<UniversityDto> GetAllUniversities()
        {
            List<UniversityDto> Universities = new List<UniversityDto>();
            var result = myDbContext.Universities.Include(m => m.user).ToList();
            foreach (var item in result)
            {
                Universities.Add(mapper.Map<UniversityDto>(item));

            }
            return Universities;

        }

        public UniversityDto GetUniversityByID(int UniversityId)
        {
            var result = myDbContext.Universities.Include(m => m.user).FirstOrDefault(x => x.UniversityId == UniversityId);
            if (result == null)
            {
               throw new NotFoundException();
            }
            var Result = mapper.Map<UniversityDto>(result);
            return Result;
        }

        public void UpdateUniversity( UniversityDto updateUniversityDto)
        {
            var res = mapper.Map<UniversityEntity>(updateUniversityDto);
            myDbContext.Universities.Update(res);
            myDbContext.SaveChanges();
        }
    }
}
