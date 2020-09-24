using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("PipeClusterPOF")]
    public class PipeClusterPOF : Entity
    {
        [Column("PipeClusterPOFID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("CorrosionStudyID", Order = 4)]
        [ForeignKey("CorrosionStudyID")]
        public int? CorrosionStudyID { get; set; }
        public CorrosionStudy CorrosionStudy { get; set; }

        public string ClusterNo { get; set; }
        public string MaterialCode { get; set; }
        public string Fluid { get; set; }

        public string DMCode { get; set; }
        public string DMDescription { get; set; }
        public string DMType { get; set; }
        public decimal? DMRate { get; set; }
        public string DMSuceptability { get; set; }
        public string DMSeverity { get; set; }
        public string DMGuideDocument { get; set; }
        public string Source { get; set; }       
        public string SpecialCondition { get; set; }
        public decimal? MinPressure { get; set; }
        public decimal? MaxPressure { get; set; }
        public decimal? MinTemperature { get; set; }
        public decimal? MaxTemperature { get; set; }


    }
}
