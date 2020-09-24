using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("UserRole")]
    public class UserRole : Entity
    {
        [Column("UserRoleID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [Column(Order = 2)]
        [ForeignKey(nameof(User))]
        public int? UserID { get; set; }
        public User User { get; set; }
        [Column(Order = 3)]
        [Required]
        [ForeignKey(nameof(Role))]
        public int? RoleID { get; set; }
        public Role Role { get; set; }
        [Column(Order = 4)]
        [Required]
        public bool Active { get; set; }
    }
}
