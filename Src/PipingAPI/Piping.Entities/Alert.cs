using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("Alert")]
    public class Alert : Entity
    {
        [Column("AlertId", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [ForeignKey(nameof(AlertMaster))]
        public int AlertMasterID { get; set; }
        public AlertMaster AlertMaster { get; set; }

        [ForeignKey(nameof(Status))]
        public int StatusID { get; set; }
        public Status Status { get; set; }

        [Column(Order = 3)]
        [Required]
        [MaxLength(250, ErrorMessage = "Length must be less then 250 characters")]
        public string Remarks { get; set; }   
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
        [Column(Order = 8)]
        public string EmailCc { get; set; }

        [MaxLength(250, ErrorMessage = "Length must be less then 250 characters")]
        [Column(Order = 8)]
        public string EmailBcc { get; set; }
    }
}
