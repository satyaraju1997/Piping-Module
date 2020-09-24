using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("InspectionRecommendation")]
    public class InspectionRecommendation : Entity
    {
        [Column("InspectionRecommendationID")]
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
      
    }
}
