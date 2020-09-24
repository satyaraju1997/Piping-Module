using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("POF_SCC")]
    public class POFSCC : Entity
    {
        [Column("POF_SCC_ID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("PipeMasterID", Order = 4)]
        [ForeignKey("PipeMasterID")]
        public int? PipeMasterID { get; set; }
        public PipeMaster PipeMaster { get; set; }

        [Column("EquipmentNo", Order = 2)]        
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
        public string EquipmentNo { get; set; }

        [Column("DMCode", Order = 2)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string DMCode { get; set; }

        [Column("DMName", Order = 3)]       
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string DMName { get; set; }

        [Column("InitialSuceptability", Order = 3)]
        [Required]
        [MaxLength(15, ErrorMessage = "Length must be less then 15 characters")]
        public string InitialSuceptability { get; set; }

        [Column("IntialIndex", Order = 3)]
        [Required]        
        public int IntialIndex { get; set; }

        [Column("High", Order = 3)]
        [Required]
        public int High { get; set; }

        [Column("Medium", Order = 3)]
        [Required]
        public int Medium { get; set; }

        [Column("Low", Order = 3)]
        [Required]
        public int Low { get; set; }

        [Column("Found", Order = 3)]
        [Required]
        public int Found { get; set; }

        [Column("DamageReductionFactor", Order = 3)]
        [Required]
        public decimal DamageReductionFactor { get; set; }

        [Column("DamageFactor", Order = 3)]
        [Required]
        public int DamageFactor { get; set; }

        [Column("POF", Order = 3)]
        [Required]
        public int POF { get; set; }

        [Column("LastYearVH", Order = 3)]        
        public int LastYearVH { get; set; }

        [Required]
        public bool Active { get; set; }               
    }
}
