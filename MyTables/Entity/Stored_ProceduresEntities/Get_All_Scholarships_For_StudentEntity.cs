using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities.Stored_ProceduresEntities
{
    public class Get_All_Scholarships_For_StudentEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialize Specialize_Name { get; set; }
        public Scholarshiptype type { get; set; }
        public string University_Name { get; set; }
        public DateTime Date_Log_Scholarship { get; set; }

        public int Count_Student_SCholarship { get; set; }

    }
}
