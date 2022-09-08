using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities
{
   public class Course_LTEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CourseLTId { get; set; }

        [Required]
        [ForeignKey("Courses")]
        public int CourseId { get; set; }

        [Required]
        [ForeignKey("Learn_Tracks")]
        public int LearnTrackId { get; set; }

        //one to many relation
        public virtual CourseEntity Course { get; set; }
        public virtual Learn_TrackEntity LearnTrack { get; set; }
      
    
       
    }
}
