using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("IOW")]
    public class IOW : Entity
    {
        [Column("IOWID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("CorrosionStudyID", Order = 4)]
        [ForeignKey("CorrosionStudyID")]
        public int? CorrosionStudyID { get; set; }
        public CorrosionStudy CorrosionStudy { get; set; }
        public string IOWNo { get; set; }
        public string LoopNo { get; set; }
        public string Parameter { get; set; }
        public string Unit { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string TagNo { get; set; }
        public string RelatedUnitNo { get; set; }
      

    }
}
