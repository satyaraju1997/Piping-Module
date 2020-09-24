using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_FluidIC")]
    public class FluidIC : Entity
    {
        [Column("FluidIC_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string FluidType { get; set; }
        public string ReleaseType { get; set; }
        public decimal? FactIC { get; set; }
    }
}
