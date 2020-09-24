using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class StructuralMinThkDTO : BaseResponseDTO
    {
        public int ID { get; set; }
        public string ComponentType { get; set; }
        public decimal OutsideDiameterInches { get; set; }
        public decimal OutsideDiameterMM { get; set; }
        public decimal StructureWallThicknessMM { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class InsulationTypeDTO : BaseResponseDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }        
        public decimal AdjustmentFactor { get; set; }        
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }

    public class MaterialCodesDTO : BaseResponseDTO
    {
        public int ID { get; set; }        
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
    public class MaterialMasterDTO : BaseResponseDTO
    {
        public int ID { get; set; }
     
        public string NOMINAL_COMPOSITION { get; set; }
        
        public string PRODUCT_FORM { get; set; }
        
        public string SPEC_NO { get; set; }
        
        public string TYPE_GRADE { get; set; }
        
        public string UNS_NO { get; set; }
       
        public string SIZE_THICKNESS_MM { get; set; }
       
        public string P_NO { get; set; }
        
        public string GROUP_NO { get; set; }
       
        public string TENSILE_STRENGTH_MPA { get; set; }
      
        public string YIELD_STRENGTH_MPA { get; set; }
       
        public string DTEMP_UPTO_40 { get; set; }
       
        public string DTEMP_UPTO_41_UPTO_65 { get; set; }
       
        public string DTEMP_UPTO_66_UPTO_100 { get; set; }
      
        public string DTEMP_UPTO_101_UPTO_125 { get; set; }
        
        public string DTEMP_UPTO_126_UPTO_150 { get; set; }
      
        public string DTEMP_UPTO_151_UPTO_175 { get; set; }
       
        public string DTEMP_UPTO_176_UPTO_200 { get; set; }
       
        public string DTEMP_UPTO_201_UPTO_225 { get; set; }
     
        public string DTEMP_UPTO_226_UPTO_250 { get; set; }
       
        public string DTEMP_UPTO_251_UPTO_275 { get; set; }
       
        public string DTEMP_UPTO_276_UPTO_300 { get; set; }
      
        public string DTEMP_UPTO_301_UPTO_325 { get; set; }
       
        public string DTEMP_UPTO_326_UPTO_350 { get; set; }
      
        public string DTEMP_UPTO_351_UPTO_375 { get; set; }
      
        public string DTEMP_UPTO_376_UPTO_400 { get; set; }
     
        public string DTEMP_UPTO_401_UPTO_425 { get; set; }
      
        public string DTEMP_UPTO_426_UPTO_450 { get; set; }
      
        public string DTEMP_UPTO_451_UPTO_475 { get; set; }
     
        public string DTEMP_UPTO_476_UPTO_500 { get; set; }
    
        public string DTEMP_UPTO_501_UPTO_525 { get; set; }
       
        public string DTEMP_UPTO_526_UPTO_550 { get; set; }
       
        public string DTEMP_UPTO_551_UPTO_575 { get; set; }
        
        public string DTEMP_UPTO_576_UPTO_600 { get; set; }
       
        public string DTEMP_UPTO_601_UPTO_625 { get; set; }
      
        public string DTEMP_UPTO_626_UPTO_650 { get; set; }
      
        public string DTEMP_UPTO_651_UPTO_675 { get; set; }
       
        public string DTEMP_UPTO_676_UPTO_700 { get; set; }
       
        public string DTEMP_UPTO_701_UPTO_725 { get; set; }
      
        public string DTEMP_UPTO_726_UPTO_750 { get; set; }
      
        public string DTEMP_UPTO_751_UPTO_775 { get; set; }
       
        public string DTEMP_UPTO_776_UPTO_800 { get; set; }
      
        public string DTEMP_UPTO_801_UPTO_825 { get; set; }
      
        public string DTEMP_UPTO_826_UPTO_850 { get; set; }
        
        public string DTEMP_UPTO_851_UPTO_875 { get; set; }
    
        public string DTEMP_UPTO_876_UPTO_900 { get; set; }
        
        public string DTEMP_UPTO_901_UPTO_925 { get; set; }
    
        public string DTEMP_UPTO_926_UPTO_950 { get; set; }
      
        public string DTEMP_UPTO_951_UPTO_975 { get; set; }
        
        public string DTEMP_UPTO_976_UPTO_1000 { get; set; }
      
        public string DTEMP_UPTO_1001_UPTO_1025 { get; set; }
     
        public string DTEMP_UPTO_1026_UPTO_1050 { get; set; }
      
        public string DTEMP_UPTO_1051_UPTO_1075 { get; set; }
        
        public string DTEMP_UPTO_1076_UPTO_1100 { get; set; }
       
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }


    public class DropdownDTO
    { 
        public string Value { get; set; }        
        public string Text { get; set; }        
    }
}
