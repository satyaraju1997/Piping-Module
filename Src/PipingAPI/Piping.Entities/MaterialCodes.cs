using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_MaterialCodes")]
    public class MaterialCodes : Entity
    {
        [Column("MST_MaterialCodes_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Column("MaterialCode")]
        public string Code { get; set; }
        [Column("MaterialName")]
        public string Name { get; set; }        
        public bool Active { get; set; }
    }
}
