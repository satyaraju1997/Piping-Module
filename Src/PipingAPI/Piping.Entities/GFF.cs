using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_GFF")]
    public class GFF : Entity
    {
        [Column("GFF_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ComponentType { get; set; }
        public int? ComponentDiameterFrom { get; set; }
        public int? ComponentDiameterTo { get; set; }
        public decimal? Gff1 { get; set; }
        public decimal? Gff2 { get; set; }
        public decimal? Gff3 { get; set; }
        public decimal? Gff4 { get; set; }
        public decimal? GffTotal { get; set; }
    }
}
