using AutoMapper;
using Piping.Contracts.Services;
using Piping.Contracts.Repository;
using Piping.Repository;
using Piping.DTO;
using Piping.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;


namespace Piping.Services
{
    public class PlantService : IPlantService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public PlantService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<PlantDTO> GetPlants()
        {
            return (from p in _unitOfWork.Plant.FindAll()
                    select new PlantDTO
                    {
                        PlantID = p.ID,
                        PlantCode = p.Code,
                        PlantName = p.Name,                        
                        PlantActive = p.Active,
                        ParentPlantID = p.ParentPlantID,
                        ParentPlantCode = p.ParentPlant.Code,
                        ParentPlantName = p.ParentPlant.Name,
                        ParentPlantActive = p.ParentPlant.Active
                    })
                .ToList();
        }       
    }
}
