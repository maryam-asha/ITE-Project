using ITE_Project.Dto.User;
using ITE_Project.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITE_Project.IRepo
{
  public interface IUserRepo
    {
        public void AddUser(AddUserDto add_User_Dto);
        public void DeleteUser(int UserId);
        public void UpdateUser(UserDto userDto);
        public List<UserDto> GetAllUsers(string name);
        public UserDto GetUserByID(int UserId);
        public void lockuser(int UserId);
        public int CountUserForType();


    }
}
