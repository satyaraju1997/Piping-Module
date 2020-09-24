using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_FluidProperty")]
    public class FluidProperty : Entity
    {
        [Column("FluidPropertyID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? DisplayOrder { get; set; }
        public string RepresentativeFluid { get; set; }
        public decimal? MolecularWeight { get; set; }
        public decimal? LiquidDensity { get; set; }
        public decimal? NBP { get; set; }
        public decimal? SpecificHeatCapacityRatio { get; set; }
        public decimal? AIT { get; set; }
        public string FluidReleasePhase { get; set; }
        public string FluidType { get; set; }
        public string Flammable { get; set; }
        public string Toxic { get; set; }
        public string NFNT { get; set; }
        public decimal? K { get; set; }
    }
}
