using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("CorrosionStudy")]
    public class CorrosionStudy : Entity
    {
        [Column("CorrosionStudyID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }         
        public string PlantCode { get; set; }
        public string LoopNo { get; set; }
        public string FluidCode { get; set; }
        public string FluidName { get; set; }
        public string SubFluidCode { get; set; }
        public string ProcessDescription { get; set; }
        public decimal? MinPressure { get; set; }
        public decimal? MaxPressure { get; set; }
        public decimal? MinTemperature { get; set; }
        public decimal? MaxTemperature { get; set; }

    }
}
