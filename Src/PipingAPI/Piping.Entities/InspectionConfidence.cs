using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("InspectionConfidence")]
    public class InspectionConfidence : Entity
    {
        [Column("InspectionConfidenceID")]
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
    }
}
