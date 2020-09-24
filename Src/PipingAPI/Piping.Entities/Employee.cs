using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("Employee")]
    public class Employee : Entity
    {
        [Column("EmployeeID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("EmployeeNo", Order = 2)]
        [Required]
        [MaxLength(20, ErrorMessage = "Length must be less then 20 characters")]
        public string EmployeeNo { get; set; }

        [Column("FirstName", Order = 3)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string FirstName { get; set; }

        [Column("LastName", Order = 3)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string LastName { get; set; }

        [Column("Gender", Order = 4)]        
        [MaxLength(1, ErrorMessage = "Length must be less then 1 characters")]
        public GenderEnum Gender { get; set; }

        [Column("DOB", Order = 5)]       
        public DateTime? DOB { get; set; }

        [Column("DOJ", Order = 6)]
        public DateTime? DOJ { get; set; }

        [Column("DOR", Order = 7)]
        public DateTime? DOR { get; set; }

        [Column("PhotoName", Order = 8)]
        public string PhotoName { get; set; }

        [Column("PhotoContent", Order = 8)]       
        public byte[] PhotoContent { get; set; }

        [Column(Order = 9)]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public EmployeeTypeEnum EmployeeType { get; set; }

        [Column(Order = 10)]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public DesignationEnum Designation { get; set; }

        [Column(Order = 11)]        
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Address { get; set; }

        [Column(Order = 12)]        
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Email { get; set; }

        [Column(Order = 13)]
        [MaxLength(20, ErrorMessage = "Length must be less then 20 characters")]
        public string Phone { get; set; }

        [Column("DepartmentID", Order = 14)]
        [ForeignKey("DepartmentID")]
        [Required]
        public int DepartmentID { get; set; }
        public Department Department { get; set; }

        [Column(Order = 9)]
        [Required]
        public bool Active { get; set; }
    }
}
