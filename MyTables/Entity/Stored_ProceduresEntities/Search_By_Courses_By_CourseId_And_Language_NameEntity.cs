using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities.Stored_ProceduresEntities
{
  public  class Search_By_Courses_By_CourseId_And_Level_NameEntity
    {
        public string CourseName { get; set; }
        public Language Language_Name { get; set; }
        public Level Level_Name { get; set; }
        public string URLCourse { get; set; }
        public string LearnTrackName { get; set; }
        public Specialize Specialize_Name { get; set; }
    }

  
}

