using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_LDMax")]
    public class LDMax : Entity
    {
        [Column("LDMaxID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string DetectionRating { get; set; }
        public string IsolationRating { get; set; }
        public decimal? D1 { get; set; }
        public decimal? D2 { get; set; }
        public decimal? D3 { get; set; }
        public decimal? ReductionFactor { get; set; }

    }
}
