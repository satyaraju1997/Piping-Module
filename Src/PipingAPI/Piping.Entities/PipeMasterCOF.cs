using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("PipeMasterCOF")]
    public class PipeMasterCOF : Entity
    {
        [Column("PipeMasterCOFID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("PipeMasterID", Order = 4)]
        [ForeignKey("PipeMasterID")]
        public int? PipeMasterID { get; set; }
        public PipeMaster PipeMaster { get; set; }
        public string EquipmentNo { get; set; }
        public string FluidCode { get; set; }
        public string ApplicableFluid { get; set; }
        
        public string Fluid { get; set; }
        public string ToxicFluid { get; set; }
        public decimal? ToxicFluidPercentage { get; set; }
        public string ReleaseState { get; set; }
        public string StoredStage { get; set; }
        public string ReleaseModel { get; set; }
        public decimal? OperatingPressure { get; set; }
        public string DetectionRating { get; set; }
        public string IsolationRating { get; set; }
        public string Mitigation { get; set; }
        public decimal? ComponentDiameter { get; set; }
        public decimal? ComponentLength { get; set; }
        public decimal? OperatingTemperature { get; set; }
        public string IgnitionSource { get; set; }
        public decimal? MassInventory { get; set; }
        public decimal? MassComponent { get; set; }
        public decimal? NormalBoilingPoint { get; set; }
        public decimal? MolecularWeight { get; set; }
        public string FluidPhase { get; set; }
        public string FluidPhaseStored { get; set; }
        public string ComponentType { get; set; }
        public string Flammable { get; set; }
        public string Toxic { get; set; }
        public string NFNT { get; set; }
        public decimal? ProductionLoss { get; set; }

    }
}
