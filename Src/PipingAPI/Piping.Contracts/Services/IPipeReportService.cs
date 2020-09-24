using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IPipeReportService
    {
        List<PipeReportDTO> GetAll();
        List<ObservationMasterDTO> GetAllObservations();
        PipeReportDTO GetByID(int ID);
        List<PipeReportDTO> GetByEquipmentNo(string EquipmentNo);
        PipeReportResponseDTO GetByReportNo(string ReportNo);
        PipeReportResponseDTO Create(PipeReportRequestDTO obj);
        PipeReportResponseDTO Update(PipeReportRequestDTO obj);
        void Delete(int ID);
        string GenerateReportNo(string year);
        List<PipeReportDTO> GetBySearchFilters(PipeReportFilterDTO pipeReportFilterDTO);
    }
}
