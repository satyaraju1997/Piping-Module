using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Piping.Common.Enums;

namespace Piping.Entities
{
    [Table("MST_MATERIAL")]
    public class MaterialMaster : Entity
    {
        [Column("MST_MATERIAL_ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }       
        [Column("NOMINAL_COMPOSITION")]
        public string NOMINAL_COMPOSITION { get; set; }
        [Column("PRODUCT_FORM")]
        public string PRODUCT_FORM { get; set; }
        [Column("SPEC_NO")]
        public string SPEC_NO { get; set; }
        [Column("TYPE_GRADE")]
        public string TYPE_GRADE { get; set; }
        [Column("UNS_NO")]
        public string UNS_NO { get; set; }
        [Column("SIZE_THICKNESS_MM")]
        public string SIZE_THICKNESS_MM { get; set; }
        [Column("P_NO")]
        public string P_NO { get; set; }
        [Column("GROUP_NO")]
        public string GROUP_NO { get; set; }
        [Column("TENSILE_STRENGTH_MPA")]
        public string TENSILE_STRENGTH_MPA { get; set; }
        [Column("YIELD_STRENGTH_MPA")]
        public string YIELD_STRENGTH_MPA { get; set; }
        [Column("DTEMP_UPTO_40")]
        public string DTEMP_UPTO_40 { get; set; }
        [Column("DTEMP_UPTO_41_UPTO_65")]
        public string DTEMP_UPTO_41_UPTO_65 { get; set; }
        [Column("DTEMP_UPTO_66_UPTO_100")]
        public string DTEMP_UPTO_66_UPTO_100 { get; set; }
        [Column("DTEMP_UPTO_101_UPTO_125")]
        public string DTEMP_UPTO_101_UPTO_125 { get; set; }
        [Column("DTEMP_UPTO_126_UPTO_150")]
        public string DTEMP_UPTO_126_UPTO_150 { get; set; }
        [Column("DTEMP_UPTO_151_UPTO_175")]
        public string DTEMP_UPTO_151_UPTO_175 { get; set; }
        [Column("DTEMP_UPTO_176_UPTO_200")]
        public string DTEMP_UPTO_176_UPTO_200 { get; set; }
        [Column("DTEMP_UPTO_201_UPTO_225")]
        public string DTEMP_UPTO_201_UPTO_225 { get; set; }
        [Column("DTEMP_UPTO_226_UPTO_250")]
        public string DTEMP_UPTO_226_UPTO_250 { get; set; }
        [Column("DTEMP_UPTO_251_UPTO_275")]
        public string DTEMP_UPTO_251_UPTO_275 { get; set; }
        [Column("DTEMP_UPTO_276_UPTO_300")]
        public string DTEMP_UPTO_276_UPTO_300 { get; set; }
        [Column("DTEMP_UPTO_301_UPTO_325")]
        public string DTEMP_UPTO_301_UPTO_325 { get; set; }
        [Column("DTEMP_UPTO_326_UPTO_350")]
        public string DTEMP_UPTO_326_UPTO_350 { get; set; }
        [Column("DTEMP_UPTO_351_UPTO_375")]
        public string DTEMP_UPTO_351_UPTO_375 { get; set; }
        [Column("DTEMP_UPTO_376_UPTO_400")]
        public string DTEMP_UPTO_376_UPTO_400 { get; set; }
        [Column("DTEMP_UPTO_401_UPTO_425")]
        public string DTEMP_UPTO_401_UPTO_425 { get; set; }
        [Column("DTEMP_UPTO_426_UPTO_450")]
        public string DTEMP_UPTO_426_UPTO_450 { get; set; }
        [Column("DTEMP_UPTO_451_UPTO_475")]
        public string DTEMP_UPTO_451_UPTO_475 { get; set; }
        [Column("DTEMP_UPTO_476_UPTO_500")]
        public string DTEMP_UPTO_476_UPTO_500 { get; set; }
        [Column("DTEMP_UPTO_501_UPTO_525")]
        public string DTEMP_UPTO_501_UPTO_525 { get; set; }
        [Column("DTEMP_UPTO_526_UPTO_550")]
        public string DTEMP_UPTO_526_UPTO_550 { get; set; }
        [Column("DTEMP_UPTO_551_UPTO_575")]
        public string DTEMP_UPTO_551_UPTO_575 { get; set; }
        [Column("DTEMP_UPTO_576_UPTO_600")]
        public string DTEMP_UPTO_576_UPTO_600 { get; set; }
        [Column("DTEMP_UPTO_601_UPTO_625")]
        public string DTEMP_UPTO_601_UPTO_625 { get; set; }
        [Column("DTEMP_UPTO_626_UPTO_650")]
        public string DTEMP_UPTO_626_UPTO_650 { get; set; }
        [Column("DTEMP_UPTO_651_UPTO_675")]
        public string DTEMP_UPTO_651_UPTO_675 { get; set; }
        [Column("DTEMP_UPTO_676_UPTO_700")]
        public string DTEMP_UPTO_676_UPTO_700 { get; set; }
        [Column("DTEMP_UPTO_701_UPTO_725")]
        public string DTEMP_UPTO_701_UPTO_725 { get; set; }
        [Column("DTEMP_UPTO_726_UPTO_750")]
        public string DTEMP_UPTO_726_UPTO_750 { get; set; }
        [Column("DTEMP_UPTO_751_UPTO_775")]
        public string DTEMP_UPTO_751_UPTO_775 { get; set; }
        [Column("DTEMP_UPTO_776_UPTO_800")]
        public string DTEMP_UPTO_776_UPTO_800 { get; set; }
        [Column("DTEMP_UPTO_801_UPTO_825")]
        public string DTEMP_UPTO_801_UPTO_825 { get; set; }
        [Column("DTEMP_UPTO_826_UPTO_850")]
        public string DTEMP_UPTO_826_UPTO_850 { get; set; }
        [Column("DTEMP_UPTO_851_UPTO_875")]
        public string DTEMP_UPTO_851_UPTO_875 { get; set; }
        [Column("DTEMP_UPTO_876_UPTO_900")]
        public string DTEMP_UPTO_876_UPTO_900 { get; set; }
        [Column("DTEMP_UPTO_901_UPTO_925")]
        public string DTEMP_UPTO_901_UPTO_925 { get; set; }
        [Column("DTEMP_UPTO_926_UPTO_950")]
        public string DTEMP_UPTO_926_UPTO_950 { get; set; }
        [Column("DTEMP_UPTO_951_UPTO_975")]
        public string DTEMP_UPTO_951_UPTO_975 { get; set; }
        [Column("DTEMP_UPTO_976_UPTO_1000")]
        public string DTEMP_UPTO_976_UPTO_1000 { get; set; }
        [Column("DTEMP_UPTO_1001_UPTO_1025")]
        public string DTEMP_UPTO_1001_UPTO_1025 { get; set; }
        [Column("DTEMP_UPTO_1026_UPTO_1050")]
        public string DTEMP_UPTO_1026_UPTO_1050 { get; set; }
        [Column("DTEMP_UPTO_1051_UPTO_1075")]
        public string DTEMP_UPTO_1051_UPTO_1075 { get; set; }
        [Column("DTEMP_UPTO_1076_UPTO_1100")]
        public string DTEMP_UPTO_1076_UPTO_1100 { get; set; }
    }
}
