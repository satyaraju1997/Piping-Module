using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_CUISuceptability")]
    public class CUISuceptability : Entity
    {
        [Column("MST_CUISuceptability_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public decimal OperatingTemperatureInDegC_From { get; set; }
        public decimal OperatingTemperatureInDegC_To { get; set; }
        public decimal? OperatingTemperatureInDegF_From { get; set; }
        public decimal? OperatingTemperatureInDegF_To { get; set; }
        public string Driver { get; set; }
        public string Suceptability { get; set; }
        public bool Active { get; set; }
    }
}
