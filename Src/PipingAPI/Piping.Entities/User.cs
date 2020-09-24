using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("User")]
    public class User : Entity
    {
        [Column("UserID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }        

        [Column("Username", Order = 2)]
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string Username { get; set; }

        [Column("Password", Order = 3)]             
        public string Password { get; set; }

        [Column("PasswordHash", Order = 3)]      
        public string PasswordHash { get; set; }

        [Column("PasswordSalt", Order = 3)]
        public string PasswordSalt { get; set; }

        [Column("Email", Order = 4)]       
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Email { get; set; }

        [Column("CompanyID", Order = 4)]
        [ForeignKey("CompanyID")]
        [Required]
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        public bool IsLocked { get; set; }
     
        public bool IsExpired { get; set; }

        public DateTime? PasswordChangedDate { get; set; }
        public DateTime? LockedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
