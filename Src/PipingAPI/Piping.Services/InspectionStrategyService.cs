using AutoMapper;
using Piping.Contracts.Services;
using Piping.Contracts.Repository;
using Piping.Repository;
using Piping.DTO;
using Piping.Entities;
using Piping.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Drawing;
using System.IO;

namespace Piping.Services
{
    public class InspectionStrategyService : IInspectionStrategyService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public InspectionStrategyService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<InspectionStrategyDTO> GetAll()
        {
            return (from p in _unitOfWork.InspectionStrategy.FindAll()
                    select new InspectionStrategyDTO
                    {
                        ID = p.ID,
                        DMCode = p.DMCode,
                        Frequency = p.Frequency,
                        Priority = p.Priority,
                        NDTMethod = p.NDTMethod,
                        InspectionYear = p.InspectionYear,
                        EquipmentNo = p.EquipmentNo,
                        PipeMasterID = p.PipeMasterID,
                        RecommendedAction = p.RecommendedAction,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate
                    })
                .ToList();

          
        }

        public InspectionStrategyDTO GetByID(int ID)
        {
            InspectionStrategy inspectionStrategy = (from p in _unitOfWork.InspectionStrategy.FindAll().Where(p => p.ID == ID)
                                                     select p).FirstOrDefault();
            InspectionStrategyDTO inspectionStrategDTO = _mapper.Map<InspectionStrategyDTO>(inspectionStrategy);

            return inspectionStrategDTO;
        }

        public List<InspectionStrategyDTO> GetByEquipmentNo(string EquipmentNo)
        {
            List<InspectionStrategy> inspectionStrategyList = (from p in _unitOfWork.InspectionStrategy.FindAll().Where(p => p.EquipmentNo == EquipmentNo)
                                                     select p).ToList();

            List<InspectionStrategyDTO> inspectionStrategyDTOList = new List<InspectionStrategyDTO>();
            foreach(InspectionStrategy obj in inspectionStrategyList)
                inspectionStrategyDTOList.Add(_mapper.Map<InspectionStrategyDTO>(obj));

            return inspectionStrategyDTOList;
        }

        public void Create(InspectionStrategyDTO InspectionStrategyDTO)
        {
            InspectionStrategy inspectionStrategy = _mapper.Map<InspectionStrategy>(InspectionStrategyDTO);

            inspectionStrategy.CreatedDate = DateTime.Now;

            _unitOfWork.InspectionStrategy.Create(inspectionStrategy);
            _unitOfWork.SaveChanges();
        }
        public void Update(InspectionStrategyDTO InspectionStrategyDTO)
        {
            var response = _unitOfWork.InspectionStrategy.FindById(InspectionStrategyDTO.ID);
            if (response != null)
            {
                response.DMCode = InspectionStrategyDTO.DMCode;
                response.Frequency = InspectionStrategyDTO.Frequency;
                response.Priority = InspectionStrategyDTO.Priority;
                response.NDTMethod = InspectionStrategyDTO.NDTMethod;             
                response.CreatedBy = InspectionStrategyDTO.CreatedBy;
                response.CreatedDate = InspectionStrategyDTO.CreatedDate;
                response.ModifiedBy = InspectionStrategyDTO.ModifiedBy;
                response.ModifiedDate = DateTime.Now;
            }
            _unitOfWork.InspectionStrategy.Update(response);
            _unitOfWork.SaveChanges();
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.InspectionStrategy.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.InspectionStrategy.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }
       
    }
}
