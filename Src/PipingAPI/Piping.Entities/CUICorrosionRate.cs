using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_CUICorrosionRate")]
    public class CUICorrosionRate : Entity
    {
        [Column("MST_CUICorrosionRate_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public decimal OperatingTemperatureInDegC { get; set; }
        public decimal? OperatingTemperatureInDegF { get; set; }
        public string Driver { get; set; }
        public decimal CorrosionRate { get; set; }
        public bool Active { get; set; }
    }
}
