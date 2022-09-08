using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyTables.Entities
{
    public class Student_LTEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Student_LTId { get; set; }
        [Range(0.0, 10.0)]
        public float Rating { get; set; }

        //one to many relation
        [Required]
        [ForeignKey("Students")]
        public int StudentId { get; set; }
        public virtual StudentEntity Student { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartlearnTime { get; set; }
        //one to many relation
        [Required]
        [ForeignKey("LearnTracks")]
        public int LearnTrackId { get; set; }
        public virtual Learn_TrackEntity LearnTrack { get; set; }

    }
}
