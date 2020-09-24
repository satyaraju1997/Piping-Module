using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IInsulationTypeService
    {
        List<InsulationTypeDTO> GetAll();
        InsulationTypeDTO GetByID(int ID);
        InsulationTypeDTO Create(InsulationTypeDTO obj);
        InsulationTypeDTO Update(InsulationTypeDTO obj);
        void Delete(int ID);
        List<DropdownDTO> GetDropdownList();
    }
}
