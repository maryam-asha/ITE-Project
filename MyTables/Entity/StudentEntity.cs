using MyTables.Entity.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace MyTables.Entities
{
   public class StudentEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int StudentId { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]

        public string FirstName { get; set; }
        [MinLength(3), MaxLength(20)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]

        public string LastName { get; set; }
        [MinLength(2), MaxLength(20)]
        public string Country { get; set; }
        [Required]
        [MaxLength(10), MinLength(10)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        [MinLength(5), MaxLength(100)]
        public string Address { get; set; }
        [DataType(DataType.Date)]
        [IsValidBirthDay("Birthday")]
        public DateTime Birthday { get; set; }
       
        //one to one relation
        public UserEntity user { get; set; }
      
        [Required, ForeignKey("Users")]
        public int UserId { get; set; }

        [Range(60.0, 100.0)]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Entered Number Should be Float")]
        public float? National_examination_mark { get; set; }
        [Range(60.0, 100.0)]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Entered Number Should be Float")]
        public float? Master_mark{ get; set; }
        [Range(150.0, 290.0)]
        public float? Baccalaureate_mark { get; set; }
        [Range(60.0, 100.0)]
        [RegularExpression(@"^[0-9]*\.?[0-9]+$", ErrorMessage = "Entered Number Should be Float")]
        public float? Average { get; set; }



        //one to many relation
        public virtual ICollection<Std_ScholarshipEntity> Std_Scholarship { get; set; }
        //one to many relation
        public virtual ICollection<Student_LTEntity> Student_LTs { get; set; }
    }
}
