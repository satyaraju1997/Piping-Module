using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IMaterialCodesService
    {
        List<MaterialCodesDTO> GetAll();
        MaterialCodesDTO GetByID(int ID);
        MaterialCodesDTO Create(MaterialCodesDTO obj);
        MaterialCodesDTO Update(MaterialCodesDTO obj);
        void Delete(int ID);
        List<DropdownDTO> GetDropdownList();
    }
}
