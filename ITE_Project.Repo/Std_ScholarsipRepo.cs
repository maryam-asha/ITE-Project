using AutoMapper;
using ITE_Project.Repo.My_Exception;
using ITE_Project.Dto.Std_Scholarship;
using ITE_Project.IRepo;
using MyDbProject;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ITE_Project.Repo
{
    public class Std_ScholarsipRepo : IStd_ScholarshipRepo
    {
        private readonly IMapper mapper;
        private readonly MyDbContext myDbContext;
        public Std_ScholarsipRepo(MyDbContext myDbContext , IMapper mapper)
        {
            this.myDbContext = myDbContext;
            this.mapper=mapper;

        }
        public bool AddStd_Scholarship(AddStd_ScholarshipDto addDto)
        {
            bool x = false;
            var res = myDbContext.Std_Scholarships.FirstOrDefault(x => x.ScholarshipId == addDto.ScholarshipId && x.StudentId == addDto.StudentId);
            int id = addDto.ScholarshipId;
            var r = myDbContext.Scholarships.FirstOrDefault(x => x.ScholarshipId == id);
            DateTime s = r.StartDate;
            DateTime e = r.EndDate;
          if ( addDto.Date_Log_Scholarship >=s && addDto.Date_Log_Scholarship <= e && res == null)
            {
                var result = mapper.Map<Std_ScholarshipEntity>(addDto);
                myDbContext.Std_Scholarships.Add(result);
                myDbContext.SaveChanges();
                x = true;
            }


            return x;
        }
        public AddStd_ScholarshipDto AddToUser(int id, string name)
        {
            var result = myDbContext.Users.FirstOrDefault(m => m.Email == name);
            int x = result.Id;
            var res = myDbContext.Students.FirstOrDefault(m => m.UserId == x);
            AddStd_ScholarshipDto slt = new AddStd_ScholarshipDto()
            {
                ScholarshipId = id,
                StudentId = res.StudentId,
                Date_Log_Scholarship = DateTime.Now,
                Taken=false
            };

            return slt;
        }
        public List<Std_ScholarshipDto> GetAllStd_Scholarships_for_University(string name)
        {
            var result = myDbContext.Users.FirstOrDefault(m => m.Email == name);
            int x = result.Id;
            var res = myDbContext.Universities.FirstOrDefault(m => m.UserId == x);

            List<Std_ScholarshipDto> Scholarshipes = new List<Std_ScholarshipDto>();
            var resul = myDbContext.Std_Scholarships
                .Include(m => m.Scholarship)
                .ThenInclude(m => m.University)
                .Include(m => m.Student)
                .Where(m => m.Scholarship.UniversityId == res.UniversityId).ToList();
            foreach (var item in resul)
            {
                Scholarshipes.Add(mapper.Map<Std_ScholarshipDto>(item));
            }
            return Scholarshipes;

        }
        public void DeleteStd_Scholarship(int Std_ScholarshipId)
        {
            var result = myDbContext.Std_Scholarships.FirstOrDefault(x => x.Std_ScholarshipId == Std_ScholarshipId);
            if (result!=null)
            {
                myDbContext.Std_Scholarships.Remove(result);
                myDbContext.SaveChanges();
            }
            
        }

        public List<Std_ScholarshipDto> GetAllStd_Scholarships()
        {
            List<Std_ScholarshipDto> std_Scholarship = new List<Std_ScholarshipDto>();
            var result = myDbContext.Std_Scholarships.ToList();
            foreach (var item in result)
            {
                std_Scholarship.Add(mapper.Map<Std_ScholarshipDto>(item));
            }
            return std_Scholarship;

        }

        public Std_ScholarshipDto GetStd_ScholarshipByID(int Std_ScholarshipId)
        {
            var result = myDbContext.Std_Scholarships.FirstOrDefault(x => x.Std_ScholarshipId == Std_ScholarshipId);
            if (result==null)
            {
                throw new NotFoundException();


            }
            var Result = mapper.Map<Std_ScholarshipDto>(result);
            return Result;
        }

        public void UpdateStd_Scholarship(int Std_ScholarshipId, UpdateStd_ScholarshipDto updateStd_ScholarshipDto)
        {
            var result = myDbContext.Std_Scholarships.FirstOrDefault(x => x.Std_ScholarshipId == Std_ScholarshipId);
            if (result!=null)
            {
                result = mapper.Map<Std_ScholarshipEntity>(updateStd_ScholarshipDto);
                myDbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();

            }

        }
        public List<Std_ScholarshipDto> MyScholarship(string name)
        {
            var result = myDbContext.Users.FirstOrDefault(m => m.Email == name);
            int x = result.Id;
            var res = myDbContext.Students.FirstOrDefault(m => m.UserId == x);

            List<Std_ScholarshipDto> Lt = new List<Std_ScholarshipDto>();

            var resul = myDbContext.Std_Scholarships
                .Include(m => m.Student)
                .Include(m => m.Scholarship)
                .ThenInclude(m=>m.University)
                .Where(m => m.StudentId == res.StudentId).ToList();
            foreach (var item in resul)
            {
                Lt.Add(mapper.Map<Std_ScholarshipDto>(item));
            }
            return Lt;

        }
        public void TakeStd(int Id)
        {
            var res = myDbContext.Std_Scholarships.FirstOrDefault(x => x.Std_ScholarshipId == Id);
            if (res.Taken==false)
            {
                res.Taken=true;

            }
            else
            {
                res.Taken=false;
            }

            myDbContext.SaveChanges();



        }

    }
}
