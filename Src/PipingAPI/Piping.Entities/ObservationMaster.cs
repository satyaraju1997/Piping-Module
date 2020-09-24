using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_Observation")]
    public class ObservationMaster : Entity
    {
        [Column("ObservationMasterID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        public string Description { get; set; }

        public bool Active { get; set; }
    }
}
