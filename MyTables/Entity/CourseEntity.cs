using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTables.Entities
{
    public class CourseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int CourseId { get; set; }
        
        public string CourseName { get; set; }
        public string Photo { get; set; }
        public Language Language_Name { get; set; }
        public Level Level_Name { get; set; }

        [Required, MaxLength(int.MaxValue)]
        public string URLCourse { get; set; }
        [MaxLength(100)]
        public string corse_descraption { get; set; }

        //one to many relation
        public virtual ICollection<Course_LTEntity> Course_Learn_Track { get; set; }

    }
    public enum Language
    {
        Arabic,
        English
    }
    public enum Level
    {
        beginner,
        med,
        advanced
    }

}
