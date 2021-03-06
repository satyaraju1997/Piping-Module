﻿using AutoMapper;
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
    public class POFSCCService : IPOFSCCService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public POFSCCService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<POFDMDTO> GetAll()
        {
            return (from p in _unitOfWork.POFSCC.FindAll()
                    select new POFDMDTO
                    {
                        ID = p.ID,
                        PipeMasterID = p.PipeMasterID,
                        EquipmentNo = p.EquipmentNo,
                        DMCode = p.DMCode,
                        DMName = p.DMName,
                        InitialSuceptability = p.InitialSuceptability,
                        IntialIndex = p.IntialIndex,
                        High = p.High,
                        Medium = p.Medium,
                        Low = p.Low,
                        Found = p.Found,
                        DamageReductionFactor = p.DamageReductionFactor,
                        DamageFactor = p.DamageFactor,
                        POF = p.POF,
                        LastYearVH = p.LastYearVH
                    })
                .ToList();
        }

        public POFDMDTO GetByID(int ID)
        {
            return (from p in _unitOfWork.POFSCC.FindAll().Where(p => p.ID == ID)
                    select new POFDMDTO
                    {
                        ID = p.ID,
                        PipeMasterID = p.PipeMasterID,
                        EquipmentNo = p.EquipmentNo,
                        DMCode = p.DMCode,
                        DMName = p.DMName,
                        InitialSuceptability = p.InitialSuceptability,
                        IntialIndex = p.IntialIndex,
                        High = p.High,
                        Medium = p.Medium,
                        Low = p.Low,
                        Found = p.Found,
                        DamageReductionFactor = p.DamageReductionFactor,
                        DamageFactor = p.DamageFactor,
                        POF = p.POF,
                        LastYearVH = p.LastYearVH,
                        Active = p.Active,
                        CreatedBy = p.CreatedBy,                        
                        ModifiedBy = p.ModifiedBy                        
                    })
                .FirstOrDefault();
        }

        public POFDMDTO GetByEquipmentNo(string EquipmentNo)
        {
            return (from p in _unitOfWork.POFSCC.GenerateEntityAsIQueryable().Where(p => p.EquipmentNo == EquipmentNo).OrderByDescending(p => p.CreatedDate)
                    select new POFDMDTO
                    {
                        ID = p.ID,
                        PipeMasterID = p.PipeMasterID,
                        EquipmentNo = p.EquipmentNo,
                        DMCode = p.DMCode,
                        DMName = p.DMName,
                        InitialSuceptability = p.InitialSuceptability,
                        IntialIndex = p.IntialIndex,
                        High = p.High,
                        Medium = p.Medium,
                        Low = p.Low,
                        Found = p.Found,
                        DamageReductionFactor = p.DamageReductionFactor,
                        DamageFactor = p.DamageFactor,
                        POF = p.POF,
                        LastYearVH = p.LastYearVH,
                        Active = p.Active,
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy
                    })
                .FirstOrDefault();
        }

        public void Create(POFDMDTO POFDMDTO)
        {
            POFSCC obj = _mapper.Map<POFSCC>(POFDMDTO);
            obj.CreatedDate = DateTime.Now;
            _unitOfWork.POFSCC.Create(obj);
            _unitOfWork.SaveChanges();           
        }
        public void Update(POFDMDTO POFDMDTO)
        {
            int ID = POFDMDTO.ID;
            POFSCC pipeline = _unitOfWork.POFSCC.FindById(ID);
            if (pipeline != null)
            {
                pipeline.PipeMasterID = POFDMDTO.PipeMasterID;
                pipeline.DMCode = POFDMDTO.DMCode;
                pipeline.DMName = POFDMDTO.DMName;
                pipeline.InitialSuceptability = POFDMDTO.InitialSuceptability;
                pipeline.IntialIndex = POFDMDTO.IntialIndex;
                pipeline.High = POFDMDTO.High;
                pipeline.Medium = POFDMDTO.Medium;
                pipeline.Low = POFDMDTO.Low;
                pipeline.Found = POFDMDTO.Found;
                pipeline.DamageReductionFactor = POFDMDTO.DamageReductionFactor;
                pipeline.DamageFactor = POFDMDTO.DamageFactor;
                pipeline.POF = POFDMDTO.POF;
                pipeline.LastYearVH = POFDMDTO.LastYearVH;
                pipeline.ModifiedBy = POFDMDTO.ModifiedBy;
                pipeline.ModifiedDate = DateTime.Now;
            }
            _unitOfWork.POFSCC.Update(pipeline);
            _unitOfWork.SaveChanges();
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.POFSCC.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.POFSCC.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }
       
    }
}
