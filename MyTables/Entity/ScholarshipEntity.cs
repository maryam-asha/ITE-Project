using MyTables.Entity.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MyTables.Entities
{
    public class ScholarshipEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ScholarshipId { get; set; }
        [Required]
        public Scholarshiptype type { get; set; }
       [Required, MaxLength(50)]
        public Specialize Specialize_Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public ScholarshipLevel Level { get; set; }
        public string ScholarshipImage { get; set; }

        //on to many relation
        [Required,ForeignKey("Universities")]
        public int UniversityId { get; set; }
        public virtual UniversityEntity University { get; set; }

        [Required(ErrorMessage = "Start Date is Required")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Date should be in YYYY-MM-DD format")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is Required")]
        [DataType(DataType.Date)]
        [RegularExpression(@"^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$", ErrorMessage = "Date should be in YYYY-MM-DD format")]
        [IsValidEndDate("StartDate")]
        public DateTime EndDate { get; set; }

        //on to many relation
        public virtual ICollection<Std_ScholarshipEntity> Std_Scholarship { get; set; }
        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    // if either date is null, that date's required attribute will invalidate
        //    if (StartDate != null && EndDate != null && StartDate >= EndDate)
        //        yield return new ValidationResult("EndDate is not greater than StartDate.");
        //}
    }
    public enum Scholarshiptype
    {
        Inclusive,
        partial
    }
   

    public enum Specialize
    {
        Software,
        ComputerNetworks,
        ArtificialIntelligence
    }
    public enum ScholarshipLevel
    {
        Master_Scholarship,
        University_Scholarship,


    }
}
