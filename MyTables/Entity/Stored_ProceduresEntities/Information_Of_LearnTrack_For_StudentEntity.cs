using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities.Stored_ProceduresEntities
{
  public class Information_Of_LearnTrack_For_StudentEntity
    {
        public string LearnTrackName { get; set; }
        public string Description { get; set; }
        public Specialize Specialize_Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
   
}
