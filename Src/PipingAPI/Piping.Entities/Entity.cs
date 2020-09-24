using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    public abstract  class Entity
    {        
        [Required]
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
        public string CreatedBy { get; set; }
       
        [Required]       
        public DateTime CreatedDate { get; set; }
        [MaxLength(100, ErrorMessage = "Length must be less then 100 characters")]
       
        public string ModifiedBy { get; set; }
       
        public DateTime? ModifiedDate { get; set; }
        [MaxLength(50, ErrorMessage = "Length must be less then 50 characters")]        
        public string SystemInfo { get; set; }
    }
}
