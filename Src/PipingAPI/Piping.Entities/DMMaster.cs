using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("DMMaster")]
    public class DMMaster : Entity
    {
        [Column("DMMasterID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }    
        public string Code { get; set; }
        public string Description { get; set; }
        public string Method { get; set; }
        public decimal? Frequency { get; set; }
        public string Interval { get; set; }
        public string Source { get; set; }
        public string Priority { get; set; }
        public string Extent { get; set; }           
    }
}
