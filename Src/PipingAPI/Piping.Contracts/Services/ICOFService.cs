using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface ICOFService
    {        
        COFDTO GetByID(int ID);
        List<COFDTO> GetByEquipmentNo(string EquipmentNo);

        void Create(COFDTO COFDTO);

        void Update(COFDTO COFDTO);

        void Delete(int ID);
    }
}
