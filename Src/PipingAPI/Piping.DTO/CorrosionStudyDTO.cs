using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class CorrosionStudyDTO
    {
        public int ID { get; set; }
        public string ParentPlantCode { get; set; }
        public string PlantCode { get; set; }
        public string LoopNo { get; set; }
        public string FluidCode { get; set; }
        public string FluidName { get; set; }
        public string SubFluidCode { get; set; }
        public string ProcessDescription { get; set; }
        public decimal? MinPressure { get; set; }
        public decimal? MaxPressure { get; set; }
        public decimal? MinTemperature { get; set; }
        public decimal? MaxTemperature { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ClusterNo  { get; set; }
        public string MaterialCode { get; set; }
        public List<string> ClusterNos { get; set; }
    }

    public class CorrosionStudyFilterDTO
    {
        public int? CorrosionStudyID { get; set; }
        public string LoopNo { get; set; }        
        public string PlantCode { get; set; }
        public string ParentPlantCode { get; set; }
        public string FluidCode { get; set; }       
    }

    public class DMGuideDTO
    {
        public int? DMGuideID { get; set; }
        public string DMCode { get; set; }
        public string DMDescription { get; set; }
        public string DMType { get; set; }
        public decimal? DMRate { get; set; }
        public string DMSuceptability { get; set; }
        public string DMSeverity { get; set; }
        public string DMGuideDocument { get; set; }
        public string Source { get; set; }
        public string SpecialCondition { get; set; }
    }


    public class PipeClusterPOFDTO
    {
        public int ID { get; set; }       
        public int? CorrosionStudyID { get; set; }      
        public string ClusterNo { get; set; }
        public string MaterialCode { get; set; }
        public string Fluid { get; set; }
        public decimal? MinPressure { get; set; }
        public decimal? MaxPressure { get; set; }
        public decimal? MinTemperature { get; set; }
        public decimal? MaxTemperature { get; set; }
        public List<DMGuideDTO> DMGuideList { get; set; }
    }

    public class IOWDTO
    {      
        public int ID { get; set; }        
        public int? CorrosionStudyID { get; set; }      
        public string IOWNo { get; set; }
        public string LoopNo { get; set; }
        public string Parameter { get; set; }
        public string Unit { get; set; }
        public string Min { get; set; }
        public string Max { get; set; }
        public string TagNo { get; set; }
        public string RelatedUnitNo { get; set; }
    }

    public class COFMasterDTO 
    {       
        public int ID { get; set; }      
        public string EquipmentNo { get; set; }
        public string LoopNo { get; set; }       
        public string Overall { get; set; }       
        public string Toxic { get; set; }       
        public string Flammable { get; set; }
        public string Production { get; set; }      
        public string Other { get; set; }
        public string RefresentativeFluid { get; set; }
        public string FluidPhaseStored { get; set; }
        public string DetectionRating { get; set; }
        public string IsolationRating { get; set; }
        public decimal? MitigationFactor { get; set; }
        public string ToxicReferenceFluid { get; set; }
        public decimal? ToxicFluidFraction { get; set; }

    }

    public class CorrosionStudyRequestDTO
    {
        public CorrosionStudyDTO CorrosionStudyDTO { get; set; }
        public List<COFMasterDTO> COFMasterDTOList { get; set; }
        public List<IOWDTO> IOWDTOList { get; set; }
        public List<PipeClusterPOFDTO> PipeClusterPOFDTOList { get; set; }        
    }

    public class CorrosionStudyResponseDTO : BaseResponseDTO
    {
        public string LoopNo { get; set; }
        public CorrosionStudyDTO CorrosionStudyDTO { get; set; }
        public List<COFMasterDTO> COFMasterDTOList { get; set; }
        public List<IOWDTO> IOWDTOList { get; set; }
        public List<PipeClusterPOFDTO> PipeClusterPOFDTOList { get; set; }
    }
}
