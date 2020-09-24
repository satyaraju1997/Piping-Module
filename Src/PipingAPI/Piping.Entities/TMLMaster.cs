using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Piping.Entities
{
    [Table("TMLMaster")]
    public class TMLMaster : Entity
    {
        [Column("TMLMasterID", Order = 1)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int? PipeMasterID { get; set; }         
        [MaxLength(25)]
        public string EquipmentNo { get; set; }            
        public string TMLNo { get; set; }               
        public string CorrosionType { get; set; }
        public string ComponentType { get; set; }          
        public int Year { get; set; }              
        public decimal? NominalDiameter { get; set; }     
        public decimal? NominalThick { get; set; }    
        public decimal? MeasuredDiameter { get; set; }     
        public decimal? MeasuredThick { get; set; }
        public decimal? LastMeasuredDiameter { get; set; }        
        public decimal? LastMeasuredThick { get; set; }      
        public int? LastMeasuredYear { get; set; }
        public decimal? InitialMeasuredDiameter { get; set; }       
        public decimal? InitialMeasuredThick { get; set; }       
        public int? InitialMeasuredYear { get; set; }     
        public decimal? PreviousMeasuredDiameter { get; set; }     
        public decimal? PreviousMeasuredThick { get; set; }      
        public int? PreviousMeasuredYear { get; set; }       
        public decimal? RemainingLife { get; set; }     
        public DateTime? NextInspectionDate { get; set; }
        public int? YearInService { get; set; }
        public Decimal CorrosionAllowance { get; set; }                
        public string MinReqThkOption { get; set; }
        public Decimal? PrMinThk { get; set; }       
        public Decimal? NomThkMinusCA { get; set; }    
        public Decimal? StructuralMinThk { get; set; }       
        public Decimal? MinReqThk { get; set; }
        public Decimal? TheoriticalCorrosionRate { get; set; }
        public Decimal? EffectiveCorrosionRate { get; set; }
        public Decimal? ShortTermCorrosionRate { get; set; }
        public Decimal? LongTermCorrosionRate { get; set; }
    }
}
