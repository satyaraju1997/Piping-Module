using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IPOFECService
    {
        List<POFECDTO> GetAll();
        POFECDTO GetByID(int ID);
        POFECDTO GetByEquipmentNo(string EquipmentNo);
        void Create(POFECDTO POFECDTO);
        void Update(POFECDTO POFECDTO);
        void Delete(int ID);
    }
}
