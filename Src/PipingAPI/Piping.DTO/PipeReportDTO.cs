using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{

    public class PipeReportRequestDTO
    {
        public PipeReportDTO PipeReport { get; set; }
        public List<InspectionConfidenceDTO> InspectionConfidenceList { get; set; }
        public List<InspectionDocumentDTO> InspectionDocumentList { get; set; }
        public List<InspectionDistributionDTO> InspectionDistributionList { get; set; }
        public List<InspectionRecommendationDTO> InspectionRecommendationList { get; set; }
        public List<InspectionObservationDTO> InspectionObservationList { get; set; }
        public List<InspectionProgramDTO> InspectionProgramList { get; set; }
        public List<TMLDTO> TMLList { get; set; }
    }

    public class PipeReportResponseDTO : BaseResponseDTO
    {
        public PipeReportDTO PipeReport { get; set; }
        public string ReportNo { get; set; }
        public List<InspectionConfidenceDTO> InspectionConfidenceList { get; set; }
        public List<InspectionDocumentDTO> InspectionDocumentList { get; set; }
        public List<InspectionDistributionDTO> InspectionDistributionList { get; set; }
        public List<InspectionRecommendationDTO> InspectionRecommendationList { get; set; }
        public List<InspectionObservationDTO> InspectionObservationList { get; set; }
        public List<InspectionProgramDTO> InspectionProgramList { get; set; }
        public List<TMLDTO> TMLList { get; set; }
    }

    public class PipeReportFilterDTO
    {
        public string ReportID { get; set; }
        public string ReportNo { get; set; }
        public string EquipmentNo { get; set; }
        public string PlantCode { get; set; }
        public string ParentPlantCode { get; set; }
        public string FluidCode { get; set; }
        public int? InspectionYear { get; set; }
        public string Risk { get; set; }
        public string Status { get; set; }
        public string DefectCode { get; set; }
    }
        public class PipeReportDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public string ReportNo { get; set; }
        public string WorkOrderNo { get; set; }
        public string EquipmentNo { get; set; }
        public string Description { get; set; }
        public string FromTo { get; set; }
        public string ParentPlantCode { get; set; }
        public string PlantCode { get; set; }
        public string Train { get; set; }
        public string PandIDNo { get; set; }
        public string ClusterNo { get; set; }
        public string OverallCOF { get; set; }
        public string OverallPOF { get; set; }
        public string Material { get; set; }
        public string Fluid { get; set; }
        public string FluidCode { get; set; }
        public string UnitCode { get; set; }        
        public string ConsequenceRank { get; set; }
        public string OverallCondition { get; set; }
        public string OverallStatus { get; set; }
        public string RevisedStatus { get; set; }
        public string InspectionType { get; set; }
        public string ResultedInto { get; set; }       
        public string RequireRCA { get; set; }
        public string RCAModel { get; set; }
        public string RCAStatus { get; set; }
        public decimal? TotalManHours { get; set; }
        public string InsulationCondition { get; set; }
        public int? RepaintedYear { get; set; }
        public string DefectCode { get; set; }
        public string RootCause { get; set; }
        public decimal? NominalDiameter { get; set; }
        public decimal? NominalThick { get; set; }
        public decimal? MeasuredThick { get; set; }
        public DateTime? NextFollowUpDate { get; set; }
        public int? InspectionYear { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string InspectionBy { get; set; }
        public DateTime? VerificationDate { get; set; }
        public string VerificationBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApprovalBy { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class InspectionConfidenceDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public int? PipeReportID { get; set; }
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }
        public string DamageMechanism { get; set; }
        public string InspectionProgram { get; set; }
        public int? Frequency { get; set; }
        public string Priority { get; set; }
        public string ConfidenceLevel { get; set; }
        public string NDTMethod { get; set; }
        public int? LastInspectionYear { get; set; }
        public string CMLNo { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class InspectionDistributionDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public int? PipeReportID { get; set; }
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }
        public string DistributionStatus { get; set; }
        public DateTime? Occurred { get; set; }
        public string DistributionCode { get; set; }
        public string DistributionBy { get; set; }
        public string Remarks { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class InspectionDocumentDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public int? PipeReportID { get; set; }
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }
        public string DocumentType { get; set; }
        public int? FileSize { get; set; }
        public string FileFormat { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class InspectionObservationDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public int? PipeReportID { get; set; }
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }
        public string Observation { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class InspectionProgramDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public int? PipeReportID { get; set; }
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }
        public string Program { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class InspectionRecommendationDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public int? PipeReportID { get; set; }
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }
        public string SerialNo { get; set; }
        public string ActionCategory { get; set; }
        public string RecommendedAction { get; set; }
        public DateTime? TargetDate { get; set; }
        public string Responsible { get; set; }
        public string Priority { get; set; }
        public string WONumber { get; set; }

        public string CommentByActionTaker { get; set; }
        public string ActionUpdateDate { get; set; }
        public string ActionNo { get; set; }
        public DateTime? ModifiedTargetDate { get; set; }
        public string WOStatus { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class TMLDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public int? PipeReportID { get; set; }
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }
        public string TMLNo { get; set; }        
        public string CorrosionType { get; set; }
        public string ComponentType { get; set; }
        public int? YearInService { get; set; }
        public decimal? NominalDiameter { get; set; }
        public decimal? NominalThick { get; set; }
        public decimal? MeasuredDiameter { get; set; }
        public decimal? MeasuredThick { get; set; }
        public decimal? LastMeasuredDiameter { get; set; }
        public decimal? LastMeasuredThick { get; set; }
        public int? LastMeasuredYear { get; set; }
        public decimal? RemainingLife { get; set; }
        public DateTime? NextInspectionDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class InspectionStrategyDTO
    {
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }
        public int? PipeReportID { get; set; }
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }

        public string DMCode { get; set; }
        public string Priority { get; set; }
        public string Frequency { get; set; }
        public string RecommendedAction { get; set; }
        public string NDTMethod { get; set; }
        public int? InspectionYear { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class ObservationMasterDTO
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
