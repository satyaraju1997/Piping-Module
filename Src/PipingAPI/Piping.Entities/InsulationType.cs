using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_InsulationType")]
    public class InsulationType : Entity
    {
        [Column("MST_InsulationType_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("AdjustmentFactor")]
        public decimal AdjustmentFactor { get; set; }
        public bool Active { get; set; }
    }
}
