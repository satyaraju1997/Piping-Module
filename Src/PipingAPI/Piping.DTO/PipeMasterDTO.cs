using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class PipeMasterDTO
    {      
        public int ID { get; set; }
     
        public string EquipmentNo { get; set; }
   
        public string Description { get; set; }
      
        public string FromTo { get; set; }
    
        public string PlantCode { get; set; }
      
        public string Train { get; set; }
      
        public string PandIDNo { get; set; }
      
        public string AreaCode { get; set; }
      
        public string Fluid { get; set; }
    
        public int YearInService { get; set; }
      
        public Decimal? DesignTemperature { get; set; }
     
        public Decimal? DesignPressure { get; set; }
        
        public Decimal? OperatingTemperature { get; set; }
       
        public Decimal? OperatingPressure { get; set; }
       
        public string PWHT { get; set; }
       
        public string MaterialCode { get; set; }
      
        public string MaterialStd { get; set; }
   
        public string MaterialGrade { get; set; }
      
        public string PipeSpec { get; set; }
       
        public Decimal? NominalDiameter { get; set; }
       
        public Decimal? NominalThick { get; set; }
       
        public Decimal Length { get; set; }
      
        public Decimal JointEfficiency { get; set; }
       
        public string Insulated { get; set; }
      
        public string InsulationType { get; set; }
        
        public Decimal CorrosionAllowance { get; set; }
      
        public Decimal? MDMT { get; set; }
        
        public string ConstructionCode { get; set; }
      
        public string PipeClusterNo { get; set; }
       
        public string CorrosionLoopNo { get; set; }
       
        public DateTime? NextInspectionDate { get; set; }
        
        public DateTime? NextFollowDate { get; set; }
       
        public string OverallRisk { get; set; }
       
        public string OverallStatus { get; set; }
      
        public string OverallPOF { get; set; }
     
        public string OverallCOF { get; set; }
       
        public string UseLastMeasuredThick_ULMT { get; set; }       
        public string MinReqThkOption_MRTO { get; set; }
       
        public Decimal? AllowableStressMPA_S { get; set; }
       
        public Decimal? YieldStrengthMPA_YS { get; set; }
       
        public Decimal? TensileStrengthMPA_TS { get; set; }
       
        public Decimal? FlowStress_FS { get; set; }
      
        public Decimal? StengthRatio_SR { get; set; }
       
        public Decimal? LastMeasuredThick_LMT { get; set; }
     
        public int? LastMeasuredYear_LMY { get; set; }
     
        public Decimal? PrMinReqThkInternal_PMTI { get; set; }
      
        public Decimal? PrMinReqThkExternal_PMTE { get; set; }
        
        public Decimal? UserCalPrMinReqThk_UMT { get; set; }
       
        public Decimal? StructuralMinThk_SMT { get; set; }
      
        public Decimal? EffectiveMinReqThk_EMRT { get; set; }
      
        public Decimal? EffectiveThk_ETHK { get; set; }        
        public string FluidCode { get; set; }       
        public string FluidName { get; set; }      
        public string SubFluid { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string SystemInfo { get; set; }

    }

    public class PipelineBasicDTO
    {
        public int ID { get; set; }
        public string EquipmentNo { get; set; }
        public string Description { get; set; }
        public string FromTo { get; set; }
        public string PlantCode { get; set; }
        public string Train { get; set; }
        public string PandIDNo { get; set; }
        public string AreaCode { get; set; }
        public string Fluid { get; set; }
        public string FluidCode { get; set; }
        public string FluidName { get; set; }
        public string SubFluid { get; set; }
        public int YearInService { get; set; }
        public string OverallStatus { get; set; }
        public DateTime? NextInspectionDate { get; set; }
        public DateTime? NextFollowDate { get; set; }
        public string PipeClusterNo { get; set; }
        public string CorrosionLoopNo { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class PipelineDesignDTO
    {
        public int ID { get; set; }
        public Decimal? DesignTemperature { get; set; }
        public Decimal? DesignPressure { get; set; }
        public Decimal? OperatingTemperature { get; set; }
        public Decimal? OperatingPressure { get; set; }
        public string PWHT { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialStd { get; set; }
        public string MaterialGrade { get; set; }
        public string PipeSpec { get; set; }
        public Decimal? NominalDiameter { get; set; }
        public Decimal? NominalThick { get; set; }
        public Decimal Length { get; set; }
        public Decimal JointEfficiency { get; set; }
        public string Insulated { get; set; }
        public string InsulationType { get; set; }
        public Decimal CorrosionAllowance { get; set; }
        public Decimal? MDMT { get; set; }
        public string ConstructionCode { get; set; }
        public string UseLastMeasuredThick_ULMT { get; set; }      
        public string MinReqThkOption_MRTO { get; set; }      
        public Decimal? AllowableStressMPA_S { get; set; }       
        public Decimal? YieldStrengthMPA_YS { get; set; }
        public Decimal? TensileStrengthMPA_TS { get; set; }       
        public Decimal? FlowStress_FS { get; set; }     
        public Decimal? StengthRatio_SR { get; set; }  
        public Decimal? LastMeasuredThick_LMT { get; set; }      
        public int? LastMeasuredYear_LMY { get; set; }    
        public Decimal? PrMinReqThkInternal_PMTI { get; set; }    
        public Decimal? PrMinReqThkExternal_PMTE { get; set; }      
        public Decimal? UserCalPrMinReqThk_UMT { get; set; }      
        public Decimal? StructuralMinThk_SMT { get; set; }      
        public Decimal? EffectiveMinReqThk_EMRT { get; set; }      
        public Decimal? EffectiveThk_ETHK { get; set; }
       
        public string ModifiedBy { get; set; }
    }
    public class POFICDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }    
        public string EquipmentNo { get; set; }       
        public string InjectionPoints { get; set; }       
        public Decimal? TheoriticalCR { get; set; }      
        public Decimal? EffectiveCR { get; set; }
        public int? EffectiveAge { get; set; }   
        public Decimal? MeasuredLCR { get; set; }       
        public Decimal? MeasuredSCR { get; set; }        
        public string UseMeasuredLCR { get; set; }       
        public string UseMeasuredSCR { get; set; }     
        public int? VeryHigh { get; set; }     
        public int? High { get; set; }       
        public int? Medium { get; set; }      
        public int? Low { get; set; }       
        public int? Found { get; set; }     
        public decimal? DamageFactor { get; set; }       
        public decimal? POF { get; set; }    
        public int? LastMeasuredYear { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public decimal? Art { get; set; }        
        public decimal? FlowStress { get; set; }        
        public decimal? StrengthRatio { get; set; }
    }

    public class POFECDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }       
        public string EquipmentNo { get; set; }      
        public Decimal? TheoriticalCR { get; set; }       
        public Decimal? EffectiveCR { get; set; }      
        public Decimal? MeasuredLCR { get; set; }       
        public Decimal? MeasuredSCR { get; set; }       
        public string UseMeasuredLCR { get; set; }        
        public string UseMeasuredSCR { get; set; }        
        public int? VeryHigh { get; set; }        
        public int? High { get; set; }      
        public int? Medium { get; set; }       
        public int? Low { get; set; }        
        public int? Found { get; set; }        
        public decimal? DamageFactor { get; set; }        
        public decimal? POF { get; set; }       
        public int? LastMeasuredYear { get; set; }        
        public int? EffectiveAge { get; set; }       
        public string SoilInterfaceCondensation { get; set; }       
        public string PipeDirectBeamComplexDesign { get; set; }        
        public int? RepaintedYear { get; set; }        
        public string Driver { get; set; }       
        public string CoatingQuality { get; set; }     
        public int? CoatingAge { get; set; }      
        public int? CoatAdjustment { get; set; }        
        public int? LineAge { get; set; }       
        public string CorrosionType { get; set; }       
        public string ExternalProcess { get; set; }

        public string InsulationCondition { get; set; }
        public string Suceptability { get; set; }
        public string AdjustedSuceptability { get; set; }
        public decimal? SeverityIndex { get; set; }
        public int? AnalysisYear { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public decimal? Art { get; set; }
        public decimal? FlowStress { get; set; }
        public decimal? StrengthRatio { get; set; }
    }   

    public class POFDMDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public string EquipmentNo { get; set; }
        public string DMCode { get; set; }
        public string DMName { get; set; }
        public string InitialSuceptability { get; set; }
        public int IntialIndex { get; set; }
        public int High { get; set; }
        public int Medium { get; set; }
        public int Low { get; set; }
        public int Found { get; set; }
        public decimal DamageReductionFactor { get; set; }
        public int DamageFactor { get; set; }
        public int POF { get; set; }
        public int LastYearVH { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
    public class PipeMasterCOFDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
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