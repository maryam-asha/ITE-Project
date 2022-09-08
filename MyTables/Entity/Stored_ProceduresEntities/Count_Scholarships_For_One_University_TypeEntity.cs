using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities.Stored_ProceduresEntities
{
    public class Count_Scholarships_For_One_University_TypeEntity
    {
        public string University_Name { get; set; }
        public Scholarshiptype type { get; set; }
        public int Count_Scholarship { get; set; }
    }
}
