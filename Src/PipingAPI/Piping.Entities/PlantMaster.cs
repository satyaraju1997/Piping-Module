using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("PlantMaster")]
    public class PlantMaster : Entity
    {
        [Column("PlantMasterID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("PlantCode", Order = 2)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string Code { get; set; }

        [Column("PlantName", Order = 3)]
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string Name { get; set; }

        [Column("ParentPlantID", Order = 4)]
        [ForeignKey("ParentPlantID")]
        public int? ParentPlantID { get; set; }
        public PlantMaster ParentPlant { get; set; }

        [Column("CompanyID", Order = 5)]
        [ForeignKey("CompanyID")]
        [Required]
        public int CompanyID { get; set; }
        public Company Company { get; set; }

        [Column("Icon", Order = 6)]
        public string Icon { get; set; }

        [Column(Order = 7)]
        [Required]
        public bool Active { get; set; }
    }
}
