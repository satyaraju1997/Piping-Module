using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("POFMaster")]
    public class POFMaster : Entity
    {
        [Column("POFMasterID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }       

        [Column("EquipmentNo", Order = 2)]       
        [MaxLength(25)]
        public string EquipmentNo { get; set; }

        [Column("DMCode", Order = 2)]
        [MaxLength(25)]
        public string DMCode { get; set; }

        [Column("DMName", Order = 2)]
        [MaxLength(100)]
        public string DMName { get; set; }

        [Column("DamageFactor", Order = 2)]       
        public int? DamageFactor { get; set; }

        [Column("POF", Order = 2)]       
        public int? POF { get; set; }

       
    }
}
