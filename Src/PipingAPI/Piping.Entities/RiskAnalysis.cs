using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("RiskAnalysis")]
    public class RiskAnalysis : Entity
    {
        [Column("RiskAnalysisID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
       
        [Column("EquipmentNo")]
        public string EquipmentNo { get; set; }
        [Column("COF")]
        public string COF { get; set; }
        [Column("C_POF")]
        public int? CurrentPOF { get; set; }
        [Column("C_Year")]
        public int? CurrentYear { get; set; }
        [Column("C_Priority")]
        public int? CurrentPriority { get; set; }
        [Column("C_Risk")]
        public string CurrentRisk { get; set; }
        [Column("C_Financial")]
        public int? CurrentFinancial { get; set; }
        [Column("C_FinancialRisk")]
        public int? CurrentFinancialRisk { get; set; }
        [Column("C_CummulativeRisk")]
        public int? CurrentCummulativeRisk { get; set; }

        [Column("A_POF")]
        public int? AnalysisPOF { get; set; }
        [Column("A_Year")]
        public int? AnalysisYear { get; set; }
        [Column("A_Priority")]
        public int? AnalysisPriority { get; set; }
        [Column("A_Risk")]
        public string AnalysisRisk { get; set; }
        [Column("A_Financial")]
        public int? AnalysisFinancial { get; set; }
        [Column("A_FinancialRisk")]
        public int? AnalysisFinancialRisk { get; set; }
        [Column("A_CummulativeRisk")]
        public int? AnalysisCummulativeRisk { get; set; }
    }
}
