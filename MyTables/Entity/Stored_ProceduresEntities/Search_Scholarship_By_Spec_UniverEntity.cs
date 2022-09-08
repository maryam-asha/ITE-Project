using MyTables.Entity.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities.Stored_ProceduresEntities
{
    public class Search_Scholarship_By_Spec_UniverEntity
    {
        public int ScholarshipId { get; set; }
        public Specialize Specialize_Name { get; set; }
        public string University_Name { get; set; }
        public string Country { get; set; }
        public string University_Address { get; set; }
        public string Phone { get; set; }
       

        //public virtual UniversityEntity University { get; set; }
        public int UniversityId { get; set; }
        public string Description { get; set; }
        public Scholarshiptype type { get; set; }
        public string ScholarshipImage { get; set; }
        public ScholarshipLevel Level { get; set; }
        public DateTime StartDate { get; set; }

        [IsValidEndDate("StartDate")]
        public DateTime EndDate { get; set; }
    }
}
