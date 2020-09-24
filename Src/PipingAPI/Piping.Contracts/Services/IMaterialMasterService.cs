using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IMaterialMasterService
    {
        List<MaterialMasterDTO> GetAll();
        MaterialMasterDTO GetByID(int ID);
        MaterialMasterDTO Create(MaterialMasterDTO obj);
        MaterialMasterDTO Update(MaterialMasterDTO obj);
        void Delete(int ID);       
        List<DropdownDTO> GetMaterialStdDropdownList();
        List<DropdownDTO> GetMaterialGradeDropdownList();
    }
}
