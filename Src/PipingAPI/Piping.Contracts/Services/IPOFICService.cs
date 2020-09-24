using Piping.DTO;
using Piping.Entities;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IPOFICService
    {
        List<POFICDTO> GetAll();
        POFICDTO GetByID(int ID);
        POFICDTO GetByPipeNo(string EquipmentNo);
        void Create(POFICDTO POFICDTO);
        void Update(POFICDTO POFICDTO);
        void CalculateMassPOF();
        POF_IC GetByEquipmentNo(string EquipmentNo);
        POF_IC GetByUnitID(int UnitID);
        void Update(string EQUIPMENT_NO, decimal PRESENT_YEAR, decimal EFFICIENCY_OF_WELD_E, decimal YOUNGS_MODULUS_Y);
        List<POF_IC> GetPOF_IC_Details(string EQUIPMENT_NO, string PRESENT_YEAR);
        void Delete(int ID);
    }
}
