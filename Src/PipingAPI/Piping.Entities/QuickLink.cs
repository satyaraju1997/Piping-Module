using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("QuickLink")]
    public class QuickLink : Entity
    {
        [Column("QuickLinkID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }       

        [Column("QuickLinkName", Order = 2)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Name { get; set; }

        [Column("SourceTable", Order = 3)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string SourceTable { get; set; }

        [Column("SourceTableColumn", Order = 4)]
        [Required]
        [MaxLength(150, ErrorMessage = "Length must be less then 150 characters")]
        public string SourceTableColumn { get; set; }

        [Column("DestinationTable", Order = 5)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string DestinationTable { get; set; }

        [Column("DestinationTableColumn", Order = 6)]
        [Required]
        [MaxLength(150, ErrorMessage = "Length must be less then 150 characters")]
        public string DestinationTableColumn { get; set; }

        [Column("Icon", Order = 7)]      
        public string Icon { get; set; }

        [Column(Order = 8)]
        [Required]
        public bool Active { get; set; }
    }
}
