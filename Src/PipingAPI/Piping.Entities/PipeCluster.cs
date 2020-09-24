using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("PipeCluster")]
    public class PipeCluster : Entity
    {
        [Column("PipeClusterID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("CorrosionStudyID", Order = 4)]
        [ForeignKey("CorrosionStudyID")]
        public int? CorrosionStudyID { get; set; }
        public CorrosionStudy CorrosionStudy { get; set; }      
        public string PlantCode { get; set; }
        public string LoopNo { get; set; }
        public string FluidCode { get; set; }
        public string MaterialCode { get; set; }
        public string PWHT { get; set; }
        public string PipeSpecification { get; set; }
        public string ClusterNo { get; set; }
        public decimal? MinPressure { get; set; }
        public decimal? MaxPressure { get; set; }
        public decimal? MinTemperature { get; set; }
        public decimal? MaxTemperature { get; set; }
    }
}
