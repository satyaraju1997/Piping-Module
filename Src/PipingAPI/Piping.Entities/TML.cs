using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("TML")]
    public class TML : Entity
    {
        [Column("TMLID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("PipeMasterID", Order = 4)]
        [ForeignKey("PipeMasterID")]
        public int? PipeMasterID { get; set; }
        public PipeMaster PipeMaster { get; set; }
        [Column("PipeReportID", Order = 4)]
        [ForeignKey("PipeReportID")]
        public int? PipeReportID { get; set; }
        public PipeReport PipeReport { get; set; }       
        [MaxLength(25)]
        public string EquipmentNo { get; set; }      
        [MaxLength(10)]
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
    }
}
