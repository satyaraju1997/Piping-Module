using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("COFMaster")]
    public class COFMaster : Entity
    {
        [Column("COFMasterID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("EquipmentNo", Order = 2)]
        [MaxLength(25)]
        public string EquipmentNo { get; set; }
      
        public string LoopNo { get; set; }
        [Column("CorrosionStudyID", Order = 4)]
        [ForeignKey("CorrosionStudyID")]
        public int? CorrosionStudyID { get; set; }
        public CorrosionStudy CorrosionStudy { get; set; }


        [Column("Overall", Order = 2)]        
        [MaxLength(1)]
        public string Overall { get; set; }

        [Column("Toxic", Order = 2)]
        [MaxLength(1)]
        public string Toxic { get; set; }

        [Column("Flammable", Order = 2)]
        [MaxLength(1)]
        public string Flammable { get; set; }

        [Column("Production", Order = 2)]
        [MaxLength(1)]
        public string Production { get; set; }

        [Column("Other", Order = 2)]
        [MaxLength(1)]
        public string Other { get; set; }

        public string RefresentativeFluid { get; set; }
        public string FluidPhaseStored { get; set; }
        public string DetectionRating { get; set; }
        public string IsolationRating { get; set; }
        public decimal? MitigationFactor { get; set; }
        public string ToxicReferenceFluid { get; set; }
        public decimal? ToxicFluidFraction { get; set; }

    }
}
