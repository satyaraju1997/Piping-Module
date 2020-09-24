using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_FluidModel")]
    public class FluidModel : Entity
    {
        [Column("FluidModelID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string FluidStoredPhase { get; set; }
        public string FluidReleasePhase { get; set; }
        public string Model { get; set; }
        public string NBP { get; set; }
    }
}
