using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("Status")]
    public class Status : Entity
    {
        [Column("StatusID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]
        [Column(Order = 2)]
        public string Code { get; set; }
        [Column(Order = 3)]
        [Required]
        [MaxLength(250, ErrorMessage = "Length must be less then 250 characters")]
        public string Name { get; set; }   
        [Column(Order = 4)]
        [Required]
        public bool Active { get; set; }
        [Column(Order = 5)]
        [Required]
        public int DisplayOrder { get; set; }
        
        [ForeignKey(nameof(Status))]
        public int? ParentStatusID { get; set; }
        public Status ParentStatus { get; set; }
    }
}
