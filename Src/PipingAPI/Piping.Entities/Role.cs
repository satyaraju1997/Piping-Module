using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("Role")]
    public class Role : Entity
    {
        [Column("RoleID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }        

        [Column("RoleCode", Order = 2)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string Code { get; set; }

        [Column("RoleName", Order = 3)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Name { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RoleMenuAction> RoleMenuActions { get; set; }
    }
}
