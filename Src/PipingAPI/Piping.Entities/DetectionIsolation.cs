using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_DetectionIsolation")]
    public class DetectionIsolation : Entity
    {
        [Column("DetectionIsolationID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string DetectionRating { get; set; }
        public string IsolationRating { get; set; }
        public decimal? FactDI { get; set; }
    }
}
