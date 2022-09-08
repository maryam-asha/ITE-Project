using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities.Stored_ProceduresEntities
{
   public class Information_Of_Student_In_LearnTrack_By_DateEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; } 

        [Required, EmailAddress, MaxLength(50)]
        public string Email { get; set; }

    }
}
