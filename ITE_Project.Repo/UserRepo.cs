using AutoMapper;
using ITE_Project.Repo.My_Exception;
using ITE_Project.Dto.User;
using ITE_Project.IRepo;
using MyDbProject;
using MyTables.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ITE_Project.Repo
{
    public class UserRepo : IUserRepo
    {
        private readonly IMapper mapper;
        private readonly MyDbContext myDbContext;
        private readonly UserManager<UserEntity> _userManager;
        public UserRepo(IMapper mapper, MyDbContext myDbContext, UserManager<UserEntity> userManager)
        {
            this.myDbContext = myDbContext;
            _userManager = userManager;
            this.mapper = mapper;
        }
        public void AddUser(AddUserDto add_User_Dto)
        {
            var result = mapper.Map<UserEntity>(add_User_Dto);
            myDbContext.Users.Add(result);
            myDbContext.SaveChanges();
        }

        public int CountUserForType()
        {
            myDbContext.Users.GroupBy(x => x.Type).Select(x => new { countUsers = x.Count() });
            return CountUserForType();
        }

        public void DeleteUser(int UserId)
        {

            var result = myDbContext.Users.FirstOrDefault(x => x.Id == UserId);
            if (result!=null)
            {
                myDbContext.Users.Remove(result);
                myDbContext.SaveChanges();

            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public List<UserDto> GetAllUsers(string name)
        {
            List<UserDto> User = new List<UserDto>();
            var result = myDbContext.Users.Where(m=>m.Email!=name).ToList();
            foreach (var item in result)
            {
                User.Add(mapper.Map<UserDto>(item));
            }
            return User;
        }

        public UserDto GetUserByID(int UserId)
        {
            var result = myDbContext.Users.FirstOrDefault(x => x.Id == UserId);
            if (result==null)
            {
                throw new NotFoundException();

            }
            else {
                var Result = mapper.Map<UserDto>(result);
                return Result;
            }
                 
        }

        public void UpdateUser( UserDto userDto)
        {
                var res = mapper.Map<UserEntity>(userDto);
               myDbContext.Users.Update(res);
                myDbContext.SaveChanges();
            
        }
        public void lockuser(int UserId)
        {
           var res = myDbContext.Users.FirstOrDefault(x => x.Id == UserId);
            if (res.LockoutEnd == null || res.LockoutEnd < DateTime.Now)
            {
                res.LockoutEnd = DateTime.Now.AddYears(10);

            }
            else
            {
                res.LockoutEnd = DateTime.Now;
            }
          
            myDbContext.SaveChanges();


           
        }
    }
}
