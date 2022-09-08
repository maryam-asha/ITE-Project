using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities.Stored_ProceduresEntities
{
    public class Count_Of_Student_In_Scholarship_By_DateEntity
    {
        public int CountOfStudent { get; set; }
        public Specialize Specialize_Name { get; set; }
        public DateTime Date_Log_Scholarship { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
