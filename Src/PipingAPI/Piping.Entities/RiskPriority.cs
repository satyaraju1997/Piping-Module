using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_RiskPriority")]
    public class RiskPriority : Entity
    {
        [Column("RiskPriorityID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }    
       
        [Column("COF")]
        public string COF { get; set; }
        [Column("POF")]
        public int POF { get; set; }       
        [Column("Priority")]
        public int Priority { get; set; }
        [Column("Risk")]
        public string Risk { get; set; }
        [Column("Financial")]
        public int Financial { get; set; }       
    }
}
