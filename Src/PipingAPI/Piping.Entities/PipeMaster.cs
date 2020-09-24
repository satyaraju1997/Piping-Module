using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("PipeMaster")]
    public class PipeMaster : Entity
    {
        [Column("PipeMasterID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

		[Column("EquipmentNo", Order = 2)]
        [Required]
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
		public string EquipmentNo { get; set; }
				
		[Column("Description", Order = 3)]       
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
		public string Description { get; set; }
		
		[Column("FromTo", Order = 4)]        
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
		public string FromTo { get; set; }
		
        [Column("PlantCode", Order = 5)]
        [Required]
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
        public string PlantCode { get; set; }
		
		[Column("Train", Order = 6)]
        [Required]
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
        public string Train { get; set; }

        [Column("PandIDNo", Order = 7)]        
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
        public string PandIDNo { get; set; }
		
		[Column("AreaCode", Order = 8)]        
        [MaxLength(8, ErrorMessage = "Length must be less then 8 characters")]
        public string AreaCode { get; set; }
		
		[Column("Fluid", Order = 9)] 
		[Required]		
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string Fluid { get; set; }

        [Column("FluidCode", Order = 9)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string FluidCode { get; set; }

        [Column("FluidName", Order = 9)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 10 characters")]
        public string FluidName { get; set; }

        [Column("SubFluid", Order = 9)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string SubFluid { get; set; }

        [Column("YearInService", Order = 10)]
        [Required]
        [MaxLength(4, ErrorMessage = "Length must be 4 characters")]
        public int YearInService { get; set; }
		
		[Column("DesignTemperature", Order = 11)]          
        public Decimal? DesignTemperature  { get; set; }
		
		[Column("DesignPressure", Order = 12)]       
        public Decimal? DesignPressure { get; set; }
		
		[Column("OperatingTemperature", Order = 13)]        
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
        public Decimal? OperatingTemperature { get; set; }
		
		[Column("OperatingPressure", Order = 14)]        
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
        public Decimal? OperatingPressure { get; set; }
		
		[Column("PWHT", Order = 15)]
        [Required]
        [MaxLength(1, ErrorMessage = "Length must be 1 character")]
        public string PWHT { get; set; }
		
		[Column("MaterialCode", Order = 16)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 5 characters")]
        public string MaterialCode { get; set; }
		
		[Column("MaterialStd", Order = 17)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 8 characters")]
        public string MaterialStd { get; set; }
		
		[Column("MaterialGrade", Order = 18)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 8 characters")]
        public string MaterialGrade { get; set; }
		
		[Column("PipeSpec", Order = 19)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 8 characters")]
        public string PipeSpec { get; set; }
		
	    [Column("NominalDiameter", Order = 20)]             
        public Decimal? NominalDiameter { get; set; }
		
		[Column("NominalThick", Order = 21)]           
        public Decimal? NominalThick { get; set; }
		
		[Column("Length", Order = 22)]
        [Required]
        public Decimal Length { get; set; }
		
		[Column("JointEfficiency", Order = 23)]
        [Required]      
        public Decimal JointEfficiency { get; set; }
		
		[Column("Insulated", Order = 24)]
        [Required]
        [MaxLength(1, ErrorMessage = "Length must be 1 character")]
        public string Insulated { get; set; }
		
		[Column("InsulationType", Order = 25)]       
        [MaxLength(20, ErrorMessage = "Length must be less then 20 characters")]
        public string InsulationType { get; set; }
		
		[Column("CorrosionAllowance", Order = 26)]
        [Required]       
        public Decimal CorrosionAllowance { get; set; }
		
		[Column("MDMT", Order = 27)]     
        public Decimal? MDMT { get; set; }
		
		[Column("ConstructionCode", Order = 28)]
        [Required]
        [MaxLength(20, ErrorMessage = "Length must be less then 20 characters")]
        public string ConstructionCode { get; set; }
		
		[Column("PipeClusterNo", Order = 29)]
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public string PipeClusterNo { get; set; }
		
		[Column("CorrosionLoopNo", Order = 30)]
        [Required]
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
        public string CorrosionLoopNo { get; set; }        

        [Column("NextInspectionDate", Order = 48)]     
        public DateTime? NextInspectionDate { get; set; }
		
		[Column("NextFollowDate", Order = 49)]     
        public DateTime? NextFollowDate { get; set; }
		
		[Column("OverallRisk", Order = 50)]       
        [MaxLength(20, ErrorMessage = "Length must be less then 20 characters")]
        public string OverallRisk { get; set; }

        [Column("OverallStatus", Order = 50)]
        [MaxLength(20, ErrorMessage = "Length must be less then 20 characters")]
        public string OverallStatus { get; set; }

        [Column("OverallPOF", Order = 51)]        
        [MaxLength(5, ErrorMessage = "Length must be 1 character")]	
        public string OverallPOF { get; set; }
		
		[Column("OverallCOF", Order = 52)]       
        [MaxLength(5, ErrorMessage = "Length must be 1 character")]	
        public string OverallCOF { get; set; }

        [Column("UseLastMeasuredThick_ULMT", Order = 52)]
        public string UseLastMeasuredThick_ULMT { get; set; }
        [Column("MinReqThkOption_MRTO", Order = 52)]
        public string MinReqThkOption_MRTO { get; set; }

        [Column("AllowableStressMPA_S", Order = 27)]
        public Decimal? AllowableStressMPA_S { get; set; }

        [Column("YieldStrengthMPA_YS", Order = 27)]
        public Decimal? YieldStrengthMPA_YS { get; set; }

        [Column("TensileStrengthMPA_TS", Order = 27)]
        public Decimal? TensileStrengthMPA_TS { get; set; }

        [Column("FlowStress_FS", Order = 27)]
        public Decimal? FlowStress_FS { get; set; }

        [Column("StengthRatio_SR", Order = 27)]
        public Decimal? StengthRatio_SR { get; set; }

        [Column("LastMeasuredThick_LMT", Order = 27)]
        public Decimal? LastMeasuredThick_LMT { get; set; }
            
        [Column("LastMeasuredYear_LMY", Order = 27)]
        public int? LastMeasuredYear_LMY { get; set; }

        [Column("PrMinReqThkInternal_PMTI", Order = 27)]
        public Decimal? PrMinReqThkInternal_PMTI { get; set; }

        [Column("PrMinReqThkExternal_PMTE", Order = 27)]
        public Decimal? PrMinReqThkExternal_PMTE { get; set; }

        [Column("UserCalPrMinReqThk_UMT", Order = 27)]
        public Decimal? UserCalPrMinReqThk_UMT { get; set; }

        [Column("StructuralMinThk_SMT", Order = 27)]
        public Decimal? StructuralMinThk_SMT { get; set; }

        [Column("EffectiveMinReqThk_EMRT", Order = 27)]
        public Decimal? EffectiveMinReqThk_EMRT { get; set; }

        [Column("EffectiveThk_ETHK", Order = 27)]
        public Decimal? EffectiveThk_ETHK { get; set; }       
      
        public int? AnalysisYear { get; set; }

    }
}
