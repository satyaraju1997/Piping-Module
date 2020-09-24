using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("InspectionStrategy")]
    public class InspectionStrategy : Entity
    {
        [Column("InspectionStrategyID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("PipeMasterID")]
        [ForeignKey("PipeMasterID")]
        public int? PipeMasterID { get; set; }
        [Column("PipeReportID")]
        [ForeignKey("PipeReportID")]
        public int? PipeReportID { get; set; }
        public PipeReport PipeReport { get; set; }
        public PipeMaster PipeMaster { get; set; }       
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }
        public string DMCode { get; set; }
        public string Priority { get; set; }
        public string Frequency { get; set; }
        public string RecommendedAction { get; set; }
        public string NDTMethod { get; set; }
        public int? InspectionYear { get; set; }
    }
}
