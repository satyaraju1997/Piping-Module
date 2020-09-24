using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("TBL_COP")]
    public class COP : Entity
    {
        [Column("TBL_COP_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("COP_LEVEL")]
        public int COP_LEVEL { get; set; }
        [Column("A")]
        public decimal A { get; set; }
        [Column("B")]
        public decimal B { get; set; }
        [Column("C")]
        public decimal C { get; set; }
        [Column("D")]
        public decimal D { get; set; }
        [Column("E")]
        public decimal E { get; set; }

    }
}
