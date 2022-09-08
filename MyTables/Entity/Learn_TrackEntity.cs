using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities
{
    public class Learn_TrackEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int LearnTrackId { get; set; }

        [Required]
        [MaxLength(100)]
        public string LearnTrackName { get; set; }

        [MinLength(50)]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [MaxLength(50)]
        public Specialize Specialize_Name { get; set; }
        public string PhotoLearnTrack { get; set; }


        //one to many relation
        public virtual ICollection<Student_LTEntity> Student_LT { get; set; }
        public virtual ICollection<Course_LTEntity> Course_LT { get; set; }
    }
    

}
