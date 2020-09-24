using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_ExternalSeverityIndex")]
    public class ExternalSeverityIndex : Entity
    {
        [Column("MST_ExternalSeverityIndex_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }   
        public string Suceptability { get; set; }
        public decimal SeverityIndex { get; set; }
        public bool Active { get; set; }
    }
}
