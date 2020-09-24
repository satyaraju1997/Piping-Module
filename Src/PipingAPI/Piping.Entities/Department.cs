using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("Department")]
    public class Department : Entity
    {
        [Column("DepartmentID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }        

        [Column("DepartmentCode", Order = 2)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string Code { get; set; }

        [Column("DepartmentName", Order = 3)]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Name { get; set; }        

        [Column("CompanyID", Order = 4)]
        [ForeignKey("CompanyID")]
        [Required]
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        [Required]
        public bool Active { get; set; }       
    }
}
