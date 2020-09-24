using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IPOFODMService
    {
        List<POFDMDTO> GetAll();
        POFDMDTO GetByID(int ID);
        POFDMDTO GetByEquipmentNo(string EquipmentNo);
        void Create(POFDMDTO POFDMDTO);
        void Update(POFDMDTO POFDMDTO);
        void Delete(int ID);
    }
}
