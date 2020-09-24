using Piping.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("DocumentMaster")]
    public class DocumentMaster : Entity
    {
        [Column("DocumentMasterID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("DocumentNo", Order = 2)]
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        public string DocumentNo { get; set; }

        [Column("Description", Order = 3)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Description { get; set; }

        [Column("DocumentType", Order = 4)]
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        public DocumentTypeEnum DocumentType { get; set; }

        [Column("ReferenceNo", Order = 4)]
        [Required]
        [MaxLength(25, ErrorMessage = "Length must be less then 25 characters")]
        public string ReferenceNo { get; set; }

        [Column("Format", Order = 5)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Format { get; set; }

        [Column("FileName", Order = 6)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string FileName { get; set; }

        [Column("Content", Order = 7)]       
        public byte[] Content { get; set; }
       
        [Column(Order = 8)]
        [Required]
        public bool Active { get; set; }
    }
}
