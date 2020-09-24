using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("TBL_POF_IC")]
    public class POF_IC : Entity
    {
        [Column("TBL_POF_IC_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Column("EQUIPMENT_NO")]
        public string EQUIPMENT_NO { get; set; }
        [Column("PRESENT_YEAR")]
        public string PRESENT_YEAR { get; set; }
        [Column("CORROSION_TYPE")]
        public string CORROSION_TYPE { get; set; }
        [Column("YEAR_IN_SERVICE")]
        public string YEAR_IN_SERVICE { get; set; }
        [Column("NOM_DIA_D_INCHES")]
        public string NOM_DIA_D_INCHES { get; set; }
        [Column("NOM_THK_NT_INCHES")]
        public string NOM_THK_NT_INCHES { get; set; }
        [Column("DESIGN_TEMP_DEGF")]
        public string DESIGN_TEMP_DEGF { get; set; }
        [Column("DESIGN_PRESSURE_P_PSI")]
        public string DESIGN_PRESSURE_P_PSI { get; set; }
        [Column("EFFECTIVE_CORROSION_RATE")]
        public string EFFECTIVE_CORROSION_RATE { get; set; }
        [Column("MATERIAL_STD")]
        public string MATERIAL_STD { get; set; }
        [Column("MATERIAL_GRADE")]
        public string MATERIAL_GRADE { get; set; }
        [Column("INJECTION_POINTS_INTERMITENT")]
        public string INJECTION_POINTS_INTERMITENT { get; set; }
        [Column("CORROSION_ALLOWANCE")]
        public string CORROSION_ALLOWANCE { get; set; }
        [Column("VERY_HIGH")]
        public string VERY_HIGH { get; set; }
        [Column("HIGH")]
        public string HIGH { get; set; }
        [Column("MEDIUM")]
        public string MEDIUM { get; set; }
        [Column("LOW")]
        public string LOW { get; set; }
        [Column("NO")]
        public string NO { get; set; }

        [Column("THEORETICAL_CORROSION_RATE_TICR")]
        public string THEORETICAL_CORROSION_RATE_TICR { get; set; }
        [Column("MEASURED_LONGTERM_CORROSION_RATE_LICR")]
        public string MEASURED_LONGTERM_CORROSION_RATE_LICR { get; set; }
        [Column("MEASURED_SHORTTERM_CORROSION_RATE_SICR")]
        public string MEASURED_SHORTTERM_CORROSION_RATE_SICR { get; set; }
        [Column("USE_LICR")]
        public string USE_LICR { get; set; }
        [Column("USE_SICR")]
        public string USE_SICR { get; set; }
        
        [Column("LAST_MEASURED_THK_FOR_DIA_LMT")]
        public string LAST_MEASURED_THK_FOR_DIA_LMT { get; set; }
        [Column("LAST_MEASURED_YEAR_FOR_DIA_LMY")]
        public string LAST_MEASURED_YEAR_FOR_DIA_LMY { get; set; }
        [Column("YIELD_STRENGTH_KSI")]
        public string YIELD_STRENGTH_KSI { get; set; }
        [Column("TENSILE_STREGTH_KSI")]
        public string TENSILE_STREGTH_KSI { get; set; }
        [Column("EFFICIENCY_OF_WELD_E")]
        public string EFFICIENCY_OF_WELD_E { get; set; }
        [Column("YOUNGS_MODULUS_Y")]
        public string YOUNGS_MODULUS_Y { get; set; }
        [Column("ALLOWABLE_STRESS_PSI")]
        public string ALLOWABLE_STRESS_PSI { get; set; }
        [Column("PRP_1")]
        public string PRP_1 { get; set; }
        [Column("PRP_2")]
        public string PRP_2 { get; set; }
        [Column("PRP_3")]
        public string PRP_3 { get; set; }
        [Column("CONDITIONAL_PROBABILITY_1_A")]
        public string CONDITIONAL_PROBABILITY_1_A { get; set; }
        [Column("CONDITIONAL_PROBABILITY_1_B")]
        public string CONDITIONAL_PROBABILITY_1_B { get; set; }
        [Column("CONDITIONAL_PROBABILITY_1_C")]
        public string CONDITIONAL_PROBABILITY_1_C { get; set; }
        [Column("CONDITIONAL_PROBABILITY_1_D")]
        public string CONDITIONAL_PROBABILITY_1_D { get; set; }
        [Column("CONDITIONAL_PROBABILITY_1_E")]
        public string CONDITIONAL_PROBABILITY_1_E { get; set; }
        [Column("CONDITIONAL_PROBABILITY_2_A")]
        public string CONDITIONAL_PROBABILITY_2_A { get; set; }
        [Column("CONDITIONAL_PROBABILITY_2_B")]
        public string CONDITIONAL_PROBABILITY_2_B { get; set; }
        [Column("CONDITIONAL_PROBABILITY_2_C")]
        public string CONDITIONAL_PROBABILITY_2_C { get; set; }
        [Column("CONDITIONAL_PROBABILITY_2_D")]
        public string CONDITIONAL_PROBABILITY_2_D { get; set; }
        [Column("CONDITIONAL_PROBABILITY_2_E")]
        public string CONDITIONAL_PROBABILITY_2_E { get; set; }
        [Column("CONDITIONAL_PROBABILITY_3_A")]
        public string CONDITIONAL_PROBABILITY_3_A { get; set; }
        [Column("CONDITIONAL_PROBABILITY_3_B")]
        public string CONDITIONAL_PROBABILITY_3_B { get; set; }
        [Column("CONDITIONAL_PROBABILITY_3_C")]
        public string CONDITIONAL_PROBABILITY_3_C { get; set; }
        [Column("CONDITIONAL_PROBABILITY_3_D")]
        public string CONDITIONAL_PROBABILITY_3_D { get; set; }
        [Column("CONDITIONAL_PROBABILITY_3_E")]
        public string CONDITIONAL_PROBABILITY_3_E { get; set; }
        [Column("EFFECTIVE_AGE")]
        public string EFFECTIVE_AGE { get; set; }
        [Column("EFFECTIVE_THK")]
        public string EFFECTIVE_THK { get; set; }
        [Column("MIN_REQ_THK")]
        public string MIN_REQ_THK { get; set; }
        [Column("EFFECTIVE_CORR_RATE")]
        public string EFFECTIVE_CORR_RATE { get; set; }
        [Column("ART")]
        public string ART { get; set; }
        [Column("FLOW_STRESS")]
        public string FLOW_STRESS { get; set; }
        [Column("STENGTH_RATIO")]
        public string STENGTH_RATIO { get; set; }
        [Column("INSPECTION_EFFECTIVENESS_1")]
        public string INSPECTION_EFFECTIVENESS_1 { get; set; }
        [Column("INSPECTION_EFFECTIVENESS_2")]
        public string INSPECTION_EFFECTIVENESS_2 { get; set; }
        [Column("INSPECTION_EFFECTIVENESS_3")]
        public string INSPECTION_EFFECTIVENESS_3 { get; set; }
        [Column("POSTERIOR_PROBABILITY_1")]
        public string POSTERIOR_PROBABILITY_1 { get; set; }
        [Column("POSTERIOR_PROBABILITY_2")]
        public string POSTERIOR_PROBABILITY_2 { get; set; }
        [Column("POSTERIOR_PROBABILITY_3")]
        public string POSTERIOR_PROBABILITY_3 { get; set; }
        [Column("CAL_OF_BETA_COVT")]
        public string CAL_OF_BETA_COVT { get; set; }
        [Column("CAL_OF_BETA_COVSF")]
        public string CAL_OF_BETA_COVSF { get; set; }
        [Column("CAL_OF_BETA_COVP")]
        public string CAL_OF_BETA_COVP { get; set; }
        [Column("CAL_OF_BETA_CONST_1")]
        public string CAL_OF_BETA_CONST_1 { get; set; }
        [Column("CAL_OF_BETA_CONST_2")]
        public string CAL_OF_BETA_CONST_2 { get; set; }
        [Column("CAL_OF_BETA_CONST_3")]
        public string CAL_OF_BETA_CONST_3 { get; set; }
        [Column("CAL_OF_BETA_1")]
        public string CAL_OF_BETA_1 { get; set; }
        [Column("CAL_OF_BETA_2")]
        public string CAL_OF_BETA_2 { get; set; }
        [Column("CAL_OF_BETA_3")]
        public string CAL_OF_BETA_3 { get; set; }
        [Column("CAL_OF_BETA_DS_VALUES_1")]
        public string CAL_OF_BETA_DS_VALUES_1 { get; set; }
        [Column("CAL_OF_BETA_DS_VALUES_2")]
        public string CAL_OF_BETA_DS_VALUES_2 { get; set; }
        [Column("CAL_OF_BETA_DS_VALUES_3")]
        public string CAL_OF_BETA_DS_VALUES_3 { get; set; }
        [Column("DAMAGE_FACTOR")]
        public string DAMAGE_FACTOR { get; set; }
        [Column("POF")]
        public string POF { get; set; }
        [Column("POF_EXPO")]
        public string POF_EXPO { get; set; }
        [Column("AVAILABLE_THK")]
        public string AVAILABLE_THK { get; set; }
        [Column("REMAINING_LIFE")]
        public string REMAINING_LIFE { get; set; }
        [Column("HALF_LIFE")]
        public string HALF_LIFE { get; set; }
        [Column("POF_HALF_LIFE")]
        public string POF_HALF_LIFE { get; set; }
        [Column("OVERALL_POF")]
        public string OVERALL_POF { get; set; }



    }
}
