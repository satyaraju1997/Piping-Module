using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface ICorrosionStudyService
    {
        List<CorrosionStudyDTO> GetAll();
        CorrosionStudyDTO GetByID(int ID);

        CorrosionStudyResponseDTO GetByLoopNo(string LoopNo);

        List<CorrosionStudyDTO> GetBySearchFilters(CorrosionStudyFilterDTO corrosionStudyFilterDTO);

        CorrosionStudyResponseDTO Create(CorrosionStudyRequestDTO CorrosionStudyRequestDTO);

        CorrosionStudyResponseDTO Update(CorrosionStudyRequestDTO CorrosionStudyRequestDTO);

        CorrosionStudyResponseDTO GetPipeClustersByLoopNo(CorrosionStudyFilterDTO corrosionStudyFilterDTO);
        void Delete(int ID);
    }
}
