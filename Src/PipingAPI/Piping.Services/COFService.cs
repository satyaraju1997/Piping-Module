using AutoMapper;
using Piping.Contracts.Repository;
using Piping.Contracts.Services;
using Piping.DTO;
using Piping.Entities;
using Piping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Piping.Services
{
    public class COFService : ICOFService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public COFService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }      

        public COFDTO GetByID(int ID)
        {
            COFFlammable COF = (from p in _unitOfWork.COFFlammable.FindAll().Where(p => p.ID == ID)
                                                     select p).FirstOrDefault();
            COFDTO inspectionStrategDTO = _mapper.Map<COFDTO>(COF);

            return inspectionStrategDTO;
        }

        public List<COFDTO> GetByEquipmentNo(string EquipmentNo)
        {
            List<COFFlammable> COFList = (from p in _unitOfWork.COFFlammable.FindAll().Where(p => p.EquipmentNo == EquipmentNo)
                                                     select p).ToList();

            List<COFDTO> COFDTOList = new List<COFDTO>();
            foreach(COFFlammable obj in COFList)
                COFDTOList.Add(_mapper.Map<COFDTO>(obj));

            return COFDTOList;
        }

        public void Create(COFDTO COFDTO)
        {
            COFFlammable COF = _mapper.Map<COFFlammable>(COFDTO);

            COF.CreatedDate = DateTime.Now;

            _unitOfWork.COFFlammable.Create(COF);
            _unitOfWork.SaveChanges();
        }
        public void Update(COFDTO COFDTO)
        {
            var response = _unitOfWork.COFFlammable.FindById(COFDTO.ID);
            if (response != null)
            {          
                response.ModifiedDate = DateTime.Now;
            }
            _unitOfWork.COFFlammable.Update(response);
            _unitOfWork.SaveChanges();
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.COFFlammable.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.COFFlammable.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }       
    }
}
