using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("RoleMenuAction")]
    public class RoleMenuAction : Entity
    {
        [Column("RoleMenuActionID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
       
        [Column(Order = 2)]
        [Required]
        [ForeignKey(nameof(Role))]
        public int? RoleID { get; set; }
        public Role Role { get; set; }

        [Required]
        [Column(Order = 3)]
        [ForeignKey(nameof(Menu))]
        public int? MenuID { get; set; }
        public Menu Menu { get; set; }

        
        [Column(Order = 3)]
        [ForeignKey(nameof(Piping.Entities.Action))]
        public int? ActionID { get; set; }
        public Piping.Entities.Action Action { get; set; }

        [Column(Order = 4)]
        [Required]
        public bool Active { get; set; }
    }
}
