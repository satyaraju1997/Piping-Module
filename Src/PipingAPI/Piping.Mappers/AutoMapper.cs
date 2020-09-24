using AutoMapper;
using Piping.DTO;
using Piping.Entities;
using System;

namespace Piping.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PipeMaster, PipeMasterDTO>().ReverseMap();
            CreateMap<PipeReport, PipeReportDTO>().ReverseMap();
            CreateMap<InspectionStrategy, InspectionStrategyDTO>().ReverseMap();            
            CreateMap<TML, TMLDTO>().ReverseMap();            
            CreateMap<InspectionConfidence, InspectionConfidenceDTO>().ReverseMap();           
            CreateMap<InspectionRecommendation, InspectionRecommendationDTO>().ReverseMap();
            CreateMap<InspectionObservation, InspectionObservationDTO>().ReverseMap();
            CreateMap<InspectionDocument, InspectionDocumentDTO>().ReverseMap();
            CreateMap<InspectionProgram, InspectionProgramDTO>().ReverseMap();
            CreateMap<InspectionDistribution, InspectionDistributionDTO>().ReverseMap();
            //  CreateMap<PipelineDTO, PipeMaster>();
            CreateMap<POFSCC, POFDMDTO>();
            CreateMap<POFODM, POFDMDTO>();
            CreateMap<DocumentMaster, DocumentDTO>();
            CreateMap<CorrosionStudy, CorrosionStudyDTO>().ReverseMap();
            CreateMap<COFMaster, COFMasterDTO>().ReverseMap();
            CreateMap<IOW, IOWDTO>().ReverseMap();
            CreateMap<PipeClusterPOF, PipeClusterPOFDTO>().ReverseMap();
            CreateMap<RiskAnalysis, RiskAnalysisDTO>().ReverseMap();
            CreateMap<PipeMasterCOF, PipeMasterCOFDTO>().ReverseMap();
        }
    }
}
