using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IPlantService
    {
        List<PlantDTO> GetPlants();      
    }
}
