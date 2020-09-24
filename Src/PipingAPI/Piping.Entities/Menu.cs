using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("Menu")]
    public class Menu : Entity
    {
        [Column("MenuID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }        

        [Column("MenuCode", Order = 2)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string Code { get; set; }

        [Column("MenuName", Order = 3)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Name { get; set; }

        [Column("ParentMenuID", Order = 4)]
        [ForeignKey("ParentMenuID")]
        public int? ParentMenuID { get; set; }
        public Menu ParentMenu { get; set; }     
        
        [Column("Path", Order = 5)]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Path { get; set; }

        [Column("Icon", Order = 6)]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Icon { get; set; }

        [Column("DisplayOrder", Order = 7)]
        public int DisplayOrder { get; set; }

        [Required]
        public bool Active { get; set; }

        public virtual ICollection<RoleMenuAction> RoleMenuActions { get; set; }        
    }
}
