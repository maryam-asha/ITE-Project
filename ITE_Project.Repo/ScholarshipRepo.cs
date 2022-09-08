using AutoMapper;
using ITE_Project.Repo.My_Exception;
using ITE_Project.Dto.Scholarship;
using ITE_Project.IRepo;
using MyDbProject;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITE_Project.Dto.Std_Scholarship;

namespace ITE_Project.Repo
{
    public class ScholarshipRepo : IScholarshipRepo
    {
        private readonly IMapper mapper;
        private readonly MyDbContext myDbContext;

        public List<UniversityEntity> UniversityList { get; private set; }
        public List<ScholarshipEntity> ScholarshipList { get; private set; }

        public ScholarshipRepo(IMapper mapper, MyDbContext myDbContext)
        {
            this.myDbContext = myDbContext;
            this.mapper = mapper;
        }

        //public AddScholarshipDto AddScholarshipWithList()
        //{
        //    AddScholarshipDto modle = new AddScholarshipDto();
        //    {
        //     //  var result = mapper.Map<ScholarshipEntity>(modle);
        //        UniversityList = myDbContext.Universities.ToList();
        //        modle.Scholarship  = new ScholarshipEntity();
        //        ScholarshipList = myDbContext.Scholarships.Distinct().ToList();
        //    }
        //    return (modle);
        //}
        public void AddScholarship(AddScholarshipDto addScholarshipDto)
        {
            var result = mapper.Map<ScholarshipEntity>(addScholarshipDto);
            myDbContext.Scholarships.Add(result);
            myDbContext.SaveChanges();
        }

        public int CountScholarship()
        {
            return myDbContext.Scholarships.Count();
        }
        public AddScholarshipDto getall(){

            AddScholarshipDto model = new AddScholarshipDto()
            {
                UniversityList = myDbContext.Universities.ToList(),
                Scholarship = new ScholarshipEntity(),
                ScholarshipList = myDbContext.Scholarships.OrderBy(m => m.Description).Select(m=>m.Description).Distinct().ToList()
            };

            return model;
        }
        public List<ScholarshipDto> GetScholarshipByUniversty(int universtyId)
        {
            List<ScholarshipDto> scholarship = new List<ScholarshipDto>();
            var result = myDbContext.Scholarships.Include(m => m.University).Where(m => m.UniversityId == universtyId);
            foreach (var item in result)
            {
                scholarship.Add(mapper.Map<ScholarshipDto>(item));

            }
            return scholarship;
        }

        public void DeleteScholarship(int ScholarshipId)
        {
            var result = myDbContext.Scholarships.FirstOrDefault(x => x.ScholarshipId == ScholarshipId);
            if (result!=null)
            {
                myDbContext.Scholarships.Remove(result);
                myDbContext.SaveChanges();
            }
            else
            {
                throw new NotFoundException();

            }
        }

        public List<ScholarshipDto> GetAllSholarships()
        {
            List<ScholarshipDto> scholarship = new List<ScholarshipDto>();
            var result = myDbContext.Scholarships.Include(m => m.University).ToList();
            foreach (var item in result)
            {
                scholarship.Add(mapper.Map<ScholarshipDto>(item));

            }
            return scholarship;
        }
        public List<Std_ScholarshipDto> SearchStudentsByName(String Fullname)
        {
            IQueryable<Std_ScholarshipEntity> query = myDbContext.Std_Scholarships.Include(m => m.Student).Include(m => m.Scholarship).ThenInclude(m => m.University);
            if (Fullname is not null)
            {
                Fullname = Fullname.ToLower();
                if (Fullname.Contains(" "))
                {
                    var names = Fullname.Split(' ');
                    string firstName = names[0];
                    string lastName = names[1];
                    query = query.Where(m => m.Student.FirstName.ToLower() == firstName && m.Student.LastName == lastName);

                }
                else
                {
                    query = query.Where(m => m.Student.FirstName.ToLower() == Fullname || m.Student.LastName == Fullname);

                }

            }
            var select_Scholar = query.ToList();
            List<Std_ScholarshipDto> Scholarships = new List<Std_ScholarshipDto>();
            foreach (var item in select_Scholar)
            {
                Scholarships.Add(mapper.Map<Std_ScholarshipDto>(item));
            }
            return Scholarships;

        }
        public List<ScholarshipDto> getScholarship(string name)
        {
            var result = myDbContext.Users.FirstOrDefault(m => m.Email == name);
            int x = result.Id;
            var res = myDbContext.Universities.FirstOrDefault(m => m.UserId == x);

            List<ScholarshipDto> Scholarshipes = new List<ScholarshipDto>();
            var resul = myDbContext.Scholarships
                .Include(m => m.University)
               .Where(m => m.UniversityId == res.UniversityId).ToList();
            foreach (var item in resul)
            {
                Scholarshipes.Add(mapper.Map<ScholarshipDto>(item));
            }
            return Scholarshipes;

        }

        public ScholarshipDto GetScholarshipByID(int ScholarshipId)
        {
            var result = myDbContext.Scholarships.Include(m => m.University).FirstOrDefault(x => x.ScholarshipId == ScholarshipId);
            if (result == null )
            {

                throw new NotFoundException();
            }

           
            var Result = mapper.Map<ScholarshipDto>(result);
           
            return Result;
        }




        public void UpdateScholarship(ScholarshipDto Updatedto)
        {
            var res = mapper.Map<ScholarshipEntity>(Updatedto);
            myDbContext.Scholarships.Update(res);
            myDbContext.SaveChanges();

        }

        //public void UpdateScholarship(int ScholarshipId, UpdateScholarshipDto UpdateScholarshipDto)
        //{
        //    var result = myDbContext.Scholarships.FirstOrDefault(x => x.ScholarshipId == ScholarshipId);
        //    if (result!=null)
        //    {
        //        result = mapper.Map<ScholarshipEntity>(UpdateScholarshipDto);
        //        myDbContext.SaveChanges();

        //    }
        //    else
        //    {
        //        throw new NotFoundException();

        //    }

        //        }
    }
}
