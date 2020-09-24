using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("UserAudit")]
    public class UserAudit : Entity
    {
        [Column("UserAuditID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("ActivityType", Order = 2)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string ActivityType { get; set; }

        [Column("Value", Order = 3)]        
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Value { get; set; }

        [Column("UserID", Order = 4)]
        [ForeignKey("UserID")]
        public int? UserID { get; set; }
        public User User { get; set; }

        [Column("Occurred", Order = 5)]
        public DateTime? Occurred { get; set; }

        [Column(Order = 6)]
        [Required]
        public bool Active { get; set; }
    }
}
