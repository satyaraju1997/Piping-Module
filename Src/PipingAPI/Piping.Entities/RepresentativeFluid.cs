using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_RepresentativeFluid")]
    public class RepresentativeFluid : Entity
    {
        [Column("RepresentativeFluidID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Fluid { get; set; }
        public string RepresentFluid { get; set; }
        public int? DisplayOrder { get; set; }

    }
}
