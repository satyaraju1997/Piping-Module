using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_FlammableConstant")]
    public class FlammableConstant : Entity
    {
        [Column("FlammableConstantID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Fluid { get; set; }
        public string FluidModel { get; set; }
        public decimal? CAINL_A_cmd { get; set; }
        public decimal? CAINL_B_cmd { get; set; }
        public decimal? IAINL_A_cmd { get; set; }
        public decimal? IAINL_B_cmd { get; set; }
        public decimal? CAIL_A_cmd { get; set; }
        public decimal? CAIL_B_cmd { get; set; }
        public decimal? IAIL_A_cmd { get; set; }
        public decimal? IAIL_B_cmd { get; set; }
        public decimal? CAINL_A_pi { get; set; }
        public decimal? CAINL_B_pi { get; set; }
        public decimal? IAINL_A_pi { get; set; }
        public decimal? IAINL_B_pi { get; set; }
        public decimal? CAIL_A_pi { get; set; }
        public decimal? CAIL_B_pi { get; set; }
        public decimal? IAIL_A_pi { get; set; }
        public decimal? IAIL_B_pi { get; set; }

    }
}
