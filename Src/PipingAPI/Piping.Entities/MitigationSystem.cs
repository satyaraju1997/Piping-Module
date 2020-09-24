using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_MitigationSystem")]
    public class MitigationSystem : Entity
    {
        [Column("MitigationSystemID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Mitigation { get; set; }
        public string SystemCode { get; set; }
        public decimal? FactMIT { get; set; }
    }
}
