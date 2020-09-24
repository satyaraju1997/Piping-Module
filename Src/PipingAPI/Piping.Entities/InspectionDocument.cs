using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("InspectionDocument")]
    public class InspectionDocument : Entity
    {
        [Column("InspectionDocumentID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("PipeMasterID", Order = 4)]
        [ForeignKey("PipeMasterID")]
        public int? PipeMasterID { get; set; }
        public PipeMaster PipeMaster { get; set; }

        [Column("PipeReportID", Order = 4)]
        [ForeignKey("PipeReportID")]
        public int? PipeReportID { get; set; }
        public PipeReport PipeReport { get; set; }
        public string EquipmentNo { get; set; }
        public string ReportNo { get; set; }
        public string DocumentType { get; set; }     

       
        [Required]
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
        public int? FileSize { get; set; }

       
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string FileFormat { get; set; }

        
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string FileName { get; set; }
        
        public byte[] Content { get; set; }       
        [Required]
        public bool Active { get; set; }
    }
}
