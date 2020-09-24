using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("RoleMenuQuickLink")]
    public class RoleMenuQuickLink : Entity
    {
        [Column("RoleMenuQuickLinkID", Order = 1)]
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

        [Required]
        [Column(Order = 4)]
        [ForeignKey(nameof(QuickLink))]
        public int? QuickLinkID { get; set; }
        public QuickLink QuickLink { get; set; }

        [Column(Order = 5)]
        [Required]
        public bool Active { get; set; }
    }
}
