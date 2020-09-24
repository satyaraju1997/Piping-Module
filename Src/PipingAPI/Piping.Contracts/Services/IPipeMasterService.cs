using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IPipeMasterService
    {
        List<PipeMasterDTO> GetAll();
        PipeMasterDTO GetByID(int ID);
        PipeMasterDTO GetByEquipmentNo(string EquipmentNo);
        void Create(PipeMasterDTO pipelineDTO);
        void Delete(int ID);

        //Basic Data   
        PipelineBasicDTO GetBasicData(int ID);
        void UpdateBasicData(PipelineBasicDTO pipelineBasicDTO);
        // Design Data
        PipelineDesignDTO GetDesignData(int ID);
        void UpdateDesignData(PipelineDesignDTO pipelineDesignDTO);
        void CalculateDesignBulkData();
        int BulkInsert(string jsonPipeMaster);
        PipeMasterCOFDTO GetCOFData(int ID);
        //
    }
}
