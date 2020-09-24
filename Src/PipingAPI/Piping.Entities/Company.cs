using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("Company")]
    public class Company : Entity
    {
        [Column("CompanyID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("CompanyCode", Order = 2)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string Code { get; set; }

        [Column("CompanyName", Order = 3)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Name { get; set; }

        [Column("LogoName", Order = 4)]
        public string LogoName { get; set; }

        [Column("LogoContent", Order = 5)]       
        public byte[] LogoContent { get; set; }

        [Column(Order = 6)]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Address { get; set; }

        [Column(Order = 7)]        
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Website { get; set; }

        [Column(Order = 8)]        
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Email { get; set; }

        [Column(Order = 9)]
        [MaxLength(20, ErrorMessage = "Length must be less then 20 characters")]
        public string Phone { get; set; }

        [Column(Order = 10)]
        [Required]
        public bool Active { get; set; }
    }
}
