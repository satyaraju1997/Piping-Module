using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("TBL_PRP")]
    public class PRP : Entity
    {
        [Column("TBL_PRP_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("PRP_CONFIDENCE")]
        public string PRP_CONFIDENCE { get; set; }
        [Column("PRP_1")]
        public decimal PRP_1 { get; set; }
        [Column("PRP_2")]
        public decimal PRP_2 { get; set; }
        [Column("PRP_3")]
        public decimal PRP_3 { get; set; }
    }
}
