using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IInspectionStrategyService
    {
        List<InspectionStrategyDTO> GetAll();
        InspectionStrategyDTO GetByID(int ID);
        List<InspectionStrategyDTO> GetByEquipmentNo(string EquipmentNo);

        void Create(InspectionStrategyDTO InspectionStrategyDTO);

        void Update(InspectionStrategyDTO InspectionStrategyDTO);

        void Delete(int ID);
    }
}
