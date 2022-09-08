using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyTables.Entities
{
    public class OpinionEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int OpinionsId { get; set; }
         
        [MaxLength(20)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public  string Email { get; set; }

        [Required]
        [MinLength(20),MaxLength(100)]
        public string Message { get; set; }
        public string Image { get; set; }
    }
}
