using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("COFFlammable")]
    public class COFFlammable : Entity
    {
        [Column("COFFlammableID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string EquipmentNo { get; set; }
        public string FluidCode { get; set; }
        public string Holes { get; set; }
        public string ReferenceFluid { get; set; }
        public string ToxicFluid { get; set; }
        public decimal? ToxicPercentage { get; set; }
        public string ReleaseState { get; set; }
        public string StoredStage { get; set; }
        public string ReleaseModel { get; set; }
        public decimal? OpPr { get; set; }
        public string Detection { get; set; }
        public string Isolation { get; set; }
        public string Mitigation { get; set; }
        public decimal? Diameter { get; set; }
        public decimal? Length { get; set; }
        public decimal? OpTemp { get; set; }
        public string IgnitionSourceNearBy { get; set; }
        public decimal? MassInventory { get; set; }
        public decimal? CdLiquid { get; set; }
        public decimal? CdVapour { get; set; }
        public int? Kv { get; set; }
        public int? Gc { get; set; }
        public int? C1 { get; set; }
        public decimal? Patm { get; set; }
        public decimal? HoleDia { get; set; }
        public decimal? MaxDiaWmax { get; set; }
        public decimal? MW { get; set; }
        public int? FluidType { get; set; }
        public decimal? AIT { get; set; }
        public decimal? EffectiveDensity { get; set; }
        public decimal? VapourDensity { get; set; }
        public decimal? LiquidDensity { get; set; }
        public decimal? K { get; set; }
        public decimal? Max60XLD { get; set; }
        public decimal? Area { get; set; }
        public decimal? OpPrPlus101 { get; set; }
        public decimal? LiquidReleaseRate { get; set; }
        public decimal? Ptrans { get; set; }
        public decimal? Wn1 { get; set; }
        public decimal? Wn2 { get; set; }
        public decimal? PPtrans { get; set; }
        public decimal? VapourReleaseRate { get; set; }
        public decimal? EffectiveReleaseRate { get; set; }
        public decimal? MaxAreaWmax { get; set; }
        public decimal? LiquidReleaseRateLDmax { get; set; }
        public decimal? Wn1Wmax { get; set; }
        public decimal? Wn2Wmax { get; set; }
        public decimal? VapourReleaseRateWmax { get; set; }
        public decimal? EffectiveReleaseRateWmax { get; set; }
        public decimal? MassComp { get; set; }
        public decimal? AvailableMassInventory { get; set; }
        public decimal? MassAdd { get; set; }
        public decimal? MassCompPlusMassAdd { get; set; }
        public decimal? MassAvailable { get; set; }
        public decimal? Tn { get; set; }
        public string ReleaseType { get; set; }
        public decimal? FactDI { get; set; }
        public decimal? FactMIT { get; set; }
        public decimal? Raten { get; set; }
        public decimal? LDn { get; set; }
        public decimal? Massn { get; set; }
        public decimal? CAINL_A_cmd { get; set; }
        public decimal? CAINL_B_cmd { get; set; }
        public decimal? IAINL_A_cmd { get; set; }
        public decimal? IAINL_B_cmd { get; set; }
        public decimal? CAIL_A_cmd { get; set; }
        public decimal? CAIL_B_cmd { get; set; }
        public decimal? IAIL_A_cmd { get; set; }
        public decimal? IAIL_B_cmd { get; set; }
        public decimal? CAINL_A_pi { get; set; }
        public decimal? CAINL_B_pi { get; set; }
        public decimal? IAINL_A_pi { get; set; }
        public decimal? IAINL_B_pi { get; set; }
        public decimal? CAIL_A_pi { get; set; }
        public decimal? CAIL_B_pi { get; set; }
        public decimal? IAIL_A_pi { get; set; }
        public decimal? IAIL_B_pi { get; set; }
        public decimal? Ts { get; set; }
        public decimal? Enff { get; set; }
        public decimal? CAINL_CA_cmd { get; set; }
        public decimal? IAINL_CA_cmd { get; set; }
        public decimal? CAIL_CA_cmd { get; set; }
        public decimal? IAIL_CA_cmd { get; set; }
        public decimal? CAINL_CA_pi { get; set; }
        public decimal? IAINL_CA_pi { get; set; }
        public decimal? CAIL_CA_pi { get; set; }
        public decimal? IAIL_CA_pi { get; set; }
        public decimal? FactICcalc { get; set; }
        public decimal? FactIC { get; set; }
        public decimal? AINL_CMD_CA { get; set; }
        public decimal? AIL_CMD_CA { get; set; }
        public decimal? AINL_PI_CA { get; set; }
        public decimal? AIL_PI_CA { get; set; }
        public decimal? TsPlus55 { get; set; }
        public decimal? TsMinus55 { get; set; }
        public decimal? FactAITcalc { get; set; }
        public decimal? FactAIT { get; set; }
        public decimal? CA_cmd { get; set; }
        public decimal? CA_pi { get; set; }
        public decimal? GFFn { get; set; }
        public decimal? GFFtotal { get; set; }
        public decimal? Final_CA_cmd { get; set; }
        public decimal? Final_CA_pi { get; set; }


    }
}
