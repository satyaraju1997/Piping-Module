using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("AlertMaster")]
    public class AlertMaster : Entity
    {
        [Column("AlertMasterID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "Length must be less then 10 characters")]
        [Column(Order = 2)]
        public string Code { get; set; }
        [Column(Order = 3)]
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string Name { get; set; }   
        [Column(Order = 4)]
        [Required]
        public bool Active { get; set; }
    
        [MaxLength(250, ErrorMessage = "Length must be less then 250 characters")]
        [Column(Order = 5)]
        public string EmailSubject { get; set; }
        
        [MaxLength]        
        public string EmailContent { get; set; }

        [MaxLength(250, ErrorMessage = "Length must be less then 250 characters")]
        [Column(Order = 7)]
        public string EmailFrom { get; set; }

        [MaxLength(250, ErrorMessage = "Length must be less then 250 characters")]
        [Column(Order = 8)]
        public string EmailTo { get; set; }

        [MaxLength(250, ErrorMessage = "Length must be less then 250 characters")]
        [Column(Order = 9)]
        public string EmailCc { get; set; }

        [MaxLength(250, ErrorMessage = "Length must be less then 250 characters")]
        [Column(Order = 9)]
        public string EmailBcc { get; set; }
    }
}
