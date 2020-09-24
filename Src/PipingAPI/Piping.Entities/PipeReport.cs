using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("PipeReport")]
    public class PipeReport : Entity
    {
        [Column("PipeReportID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string ReportNo { get; set; }
        public string WorkOrderNo { get; set; }


        [Column("PipeMasterID", Order = 4)]
        [ForeignKey("PipeMasterID")]
        public int? PipeMasterID { get; set; }
        public PipeMaster PipeMaster { get; set; }
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
        public string ClusterNo { get; set; }
        public string Material { get; set; }
        [Column("Fluid", Order = 9)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string Fluid { get; set; }
        public string ConsequenceRank { get; set; }
        public string OverallCOF { get; set; }
        public string OverallPOF { get; set; }
        public string OverallCondition { get; set; }
        public string OverallStatus { get; set; }
        public string RevisedStatus { get; set; }
        public string InspectionType { get; set; }
        public string ResultedInto { get; set; }
        public string NextFollowupDate { get; set; }
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
        public DateTime? NextFollowUpDate  { get; set; }
        public int? InspectionYear { get; set; }
        public DateTime? InspectionDate { get; set; }
        public string InspectionBy { get; set; }
        public DateTime? VerificationDate { get; set; }
        public string VerificationBy { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApprovalBy { get; set; }
    }
}
