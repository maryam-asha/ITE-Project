using ITE_Project.Dto.Learn_Track;
using ITE_Project.IRepo;
using ITE_Project.Repo.My_Exception;
using MyDbProject;
using AutoMapper;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.Repo
{
    public class Learn_TrackRepo : ILearn_TrackRepo
    {
        private readonly MyDbContext myDbContext;
        private readonly IMapper mapper;
        public Learn_TrackRepo(MyDbContext myDbContext, IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }
        public void AddLearn_Track(AddLearn_TrackDto addDto)
        {
            var result = mapper.Map<Learn_TrackEntity>(addDto);
            myDbContext.Learn_Tracks.Add(result);
            myDbContext.SaveChanges();
          
        }

        public void DeleteLearn_Track(int id)
        {
            var result = myDbContext.Learn_Tracks.FirstOrDefault(x => x.LearnTrackId== id);
            if (result != null)
            {
                myDbContext.Learn_Tracks.Remove(result);
                myDbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();
            }
        }

        public List<Learn_TrackDto> GetAllLearn_Track()
        {
            List<Learn_TrackDto> learnTracks = new List<Learn_TrackDto>();
            var result = myDbContext.Learn_Tracks.ToList();
            foreach (var item in result)
            {
                learnTracks.Add(mapper.Map<Learn_TrackDto>(item));
            }
            return learnTracks;
        }

        public int GetLearn_TrackCount()
        {
            return myDbContext.Learn_Tracks.Count();
        }

        public Learn_TrackDto GetLearn_TracktById(int id)
        {
            var res = myDbContext.Learn_Tracks.FirstOrDefault(x => x.LearnTrackId == id);
            if (res == null)
            {
                throw new NotFoundException();
            }
            else
            {
                var result = mapper.Map<Learn_TrackDto>(res);
                return result;
            }
        }

        public void UpdateLearn_Track(Learn_TrackDto Updatedto)
        {
            var res = mapper.Map<Learn_TrackEntity>(Updatedto);
            myDbContext.Learn_Tracks.Update(res);
            myDbContext.SaveChanges();
     
        }
    }
}
