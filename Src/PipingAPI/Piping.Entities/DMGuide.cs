using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("DMGuide")]
    public class DMGuide : Entity
    {
        [Column("DMGuideID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }     
        public string MaterialCode { get; set; }
        public string FluidCode { get; set; }
        public string FluidName { get; set; }
        public string SubFluid { get; set; }
        public string PWHT { get; set; }
        public string LowerRange { get; set; }
        public string HigherRange { get; set; }
        public string DMCode { get; set; }
        public string DMDescription { get; set; }
        public string DMType { get; set; }
        public string DMRate { get; set; }
        public string DMSuceptability { get; set; }
        public string DMSeverity { get; set; }
        public string DMGuideDocument { get; set; }
        public string Source { get; set; }       
        public string SpecialCondition { get; set; }
       
    }
}
