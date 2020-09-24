using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IStructuralMinThkService
    {
        List<StructuralMinThkDTO> GetAll();
        StructuralMinThkDTO GetByID(int ID);
        StructuralMinThkDTO Create(StructuralMinThkDTO obj);
        StructuralMinThkDTO Update(StructuralMinThkDTO obj);
        void Delete(int ID);
        List<DropdownDTO> GetDropdownList();
    }
}
