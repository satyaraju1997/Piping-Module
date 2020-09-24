using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_StructuralMinThk")]
    public class StructuralMinThk : Entity
    {
        [Column("MST_StructuralMinThk_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("ComponentType")]
        [Required]
        public string ComponentType { get; set; }
        [Column("OutsideDiameter_IN")]
        [Required]
        public decimal OutsideDiameterInches { get; set; }
        [Column("OutsideDiameter_MM")]
        [Required]
        public decimal OutsideDiameterMM { get; set; }
        [Column("StructureWallThickness_MM")]
        [Required]
        public decimal StructureWallThicknessMM { get; set; }       
        [Required]
        public bool Active { get; set; }
    }
}
