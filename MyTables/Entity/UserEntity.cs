using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities
{
  public  class UserEntity: IdentityUser<int>
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key]
        //public int UserId { get; set; }
        //[Required,EmailAddress, MaxLength(50)]
        //public string Email { get; set; }
        //[Required, MinLength(10),MaxLength(50)]
        //public string Password { get; set; }
        public Type_Of Type { get; set; }
        [Display(Name = "profile picture")]
        public byte[] profilePicture { get; set; }
        //one to one relation
        public UniversityEntity university { get; set; }
        public  StudentEntity   student { get; set; }
       
    }
    public enum Type_Of
    {
        University,
        Student
    }
}
