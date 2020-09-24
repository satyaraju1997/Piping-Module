using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("InspectionObservation")]
    public class InspectionObservation : Entity
    {
        [Column("InspectionObservationID")]
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
        public string Observation { get; set; }
       
    }
}
