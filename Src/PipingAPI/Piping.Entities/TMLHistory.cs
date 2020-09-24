using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("TMLHistory")]
    public class TMLHistory : Entity
    {
        [Column("TMLHistoryID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }       

        [Column("EquipmentNo", Order = 2)]
        [MaxLength(25)]
        public string EquipmentNo { get; set; }

        [Column("ReportNo", Order = 2)]
        [MaxLength(10)]
        public string ReportNo { get; set; }

        [Column("TMLNo", Order = 2)]
        [MaxLength(10)]
        public string TMLNo { get; set; }

        [Column("CorrosionType", Order = 2)]
        [MaxLength(3)]
        public string CorrosionType { get; set; }

        [Column("Year", Order = 2)]        
        public int Year { get; set; }

        [Column("Diameter", Order = 2)]        
        public int Diameter { get; set; }

        [Column("NominalThick", Order = 2)]
        public decimal NominalThick { get; set; }

        [Column("MeasuredThick", Order = 2)]
        public decimal MeasuredThick { get; set; }
    }
}
