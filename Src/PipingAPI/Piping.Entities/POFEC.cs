using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("POF_EC")]
    public class POFEC : Entity
    {
        [Column("POF_EC_ID", Order = 1)]
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
        
        [Column("TheoriticalCR", Order = 33)]
        public Decimal? TheoriticalCR { get; set; }      

        [Column("EffectiveCR", Order = 33)]
        public Decimal? EffectiveCR { get; set; }

        [Column("MeasuredLCR", Order = 33)]
        public Decimal? MeasuredLCR { get; set; }

        [Column("MeasuredSCR", Order = 33)]
        public Decimal? MeasuredSCR { get; set; }

        [Column("UseMeasuredLCR", Order = 33)]
        public string UseMeasuredLCR { get; set; }

        [Column("UseMeasuredSCR", Order = 33)]
        public string UseMeasuredSCR { get; set; }

        [Column("VeryHigh", Order = 33)]
        public int? VeryHigh { get; set; }

        [Column("High", Order = 33)]
        public int? High { get; set; }

        [Column("Medium", Order = 33)]
        public int? Medium { get; set; }

        [Column("Low", Order = 33)]
        public int? Low { get; set; }

        [Column("Found", Order = 33)]
        public int? Found { get; set; }

        [Column("DamageFactor", Order = 33)]
        public decimal? DamageFactor { get; set; }

        [Column("POF", Order = 33)]
        public decimal? POF { get; set; }

        [Column("LastMeasuredYear", Order = 34)]
        public int? LastMeasuredYear { get; set; }

        [Column("EffectiveAge", Order = 34)]
        public int? EffectiveAge { get; set; }

        [Column("SoilInterfaceCondensation", Order = 44)]
        [MaxLength(1, ErrorMessage = "Length must be 1 character")]
        public string SoilInterfaceCondensation { get; set; }

        [Column("PipeDirectBeamComplexDesign", Order = 42)]
        [MaxLength(1, ErrorMessage = "Length must be 1 character")]
        public string PipeDirectBeamComplexDesign { get; set; }

        [Column("RepaintedYear", Order = 43)]
        public int? RepaintedYear { get; set; }
        public string Repainted { get; set; }

        [Column("Driver", Order = 44)]
        [MaxLength(1, ErrorMessage = "Length must be 1 character")]
        public string Driver { get; set; }

        [Column("CoatingQuality", Order = 44)]
        [MaxLength(1, ErrorMessage = "Length must be 1 character")]
        public string CoatingQuality { get; set; }

        [Column("Art")]
        public decimal? Art { get; set; }
        [Column("FlowStress")]
        public decimal? FlowStress { get; set; }
        [Column("StrengthRatio")]
        public decimal? StrengthRatio { get; set; }

        [Column("CoatingAge", Order = 43)]
        public int? CoatingAge { get; set; }

        [Column("CoatAdjustment", Order = 43)]
        public int? CoatAdjustment { get; set; }

        [Column("LineAge", Order = 45)]       
        public int? LineAge { get; set; }

        [Column("CorrosionType", Order = 46)]
        public string CorrosionType { get; set; }

        [Column("ExternalProcess", Order = 47)]
        public string ExternalProcess { get; set; }
        public string InsulationCondition { get; set; }
        public string Suceptability { get; set; }
        public string AdjustedSuceptability { get; set; }
        public decimal? SeverityIndex { get; set; }
        public int? AnalysisYear { get; set; }
    }
}