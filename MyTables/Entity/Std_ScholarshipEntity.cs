using System;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities
{
   public class Std_ScholarshipEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Std_ScholarshipId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date_Log_Scholarship { get; set; }
        public bool Taken { get; set; }
        //one to many relation
        [Required, ForeignKey("Scholarships")]
        public int ScholarshipId { get; set; }
        public virtual ScholarshipEntity Scholarship { get; set; }

        //one to many relation
        [Required, ForeignKey("Students")]
        public int StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }


    }
}
