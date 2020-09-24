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
    public class StructuralMinThkService : IStructuralMinThkService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public StructuralMinThkService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<StructuralMinThkDTO> GetAll()
        {
            List < StructuralMinThkDTO >  list = (from p in _unitOfWork.StructuralMinThk.FindAll()
                    select new StructuralMinThkDTO
                    {
                        ID = p.ID,
                        ComponentType = p.ComponentType,
                        OutsideDiameterInches = p.OutsideDiameterInches,
                        OutsideDiameterMM = p.OutsideDiameterMM,
                        StructureWallThicknessMM = p.StructureWallThicknessMM,
                        Active = p.Active,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate
                    }).OrderBy(p => p.ID)
                .ToList();

            return list.OrderBy(p => p.ID).ToList();
        }

        public StructuralMinThkDTO GetByID(int ID)
        {
            return (from p in _unitOfWork.StructuralMinThk.FindAll().Where(p => p.ID == ID)
                    select new StructuralMinThkDTO
                    {
                        ID = p.ID,
                        ComponentType = p.ComponentType,
                        OutsideDiameterInches = p.OutsideDiameterInches,
                        OutsideDiameterMM = p.OutsideDiameterMM,
                        StructureWallThicknessMM = p.StructureWallThicknessMM,
                        Active = p.Active,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate
                    })
                .FirstOrDefault();
        }

        public StructuralMinThkDTO Create(StructuralMinThkDTO structuralMinThkDTO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    StructuralMinThk tempObj = (from s in _unitOfWork.StructuralMinThk.GenerateEntityAsIQueryable()
                                                 where s.ComponentType == structuralMinThkDTO.ComponentType 
                                                 select s).FirstOrDefault();

                    if (tempObj == null)
                    {

                        var obj = new StructuralMinThk()
                        {
                            ComponentType = structuralMinThkDTO.ComponentType,
                            OutsideDiameterInches = structuralMinThkDTO.OutsideDiameterInches,
                            OutsideDiameterMM = structuralMinThkDTO.OutsideDiameterMM,
                            StructureWallThicknessMM = structuralMinThkDTO.StructureWallThicknessMM,
                            Active = true,
                            CreatedBy = structuralMinThkDTO.CreatedBy,
                            CreatedDate = DateTime.Now
                        };

                        _unitOfWork.StructuralMinThk.Create(obj);
                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new StructuralMinThkDTO
                        {
                            ID = obj.ID,
                            Status = true,
                            StatusMessage = "Successfully created",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new StructuralMinThkDTO
                        {
                            ID = tempObj.ID,
                            Status = false,
                            StatusMessage = "Error - Duplicate Component Type - " + tempObj.ComponentType,
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new StructuralMinThkDTO()
                    {
                        ID = 0,
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }
        public StructuralMinThkDTO Update(StructuralMinThkDTO structuralMinThkDTO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    StructuralMinThk tempObj = (from r in _unitOfWork.StructuralMinThk.GenerateEntityAsIQueryable()
                                                 where r.ComponentType == structuralMinThkDTO.ComponentType && r.ID != structuralMinThkDTO.ID
                                                 select r).FirstOrDefault();

                    if (tempObj == null)
                    {
                        var response = _unitOfWork.StructuralMinThk.FindById(structuralMinThkDTO.ID);
                        if (response != null)
                        {
                            response.ComponentType = structuralMinThkDTO.ComponentType;
                            response.OutsideDiameterInches = structuralMinThkDTO.OutsideDiameterInches;
                            response.OutsideDiameterMM = structuralMinThkDTO.OutsideDiameterMM;
                            response.StructureWallThicknessMM = structuralMinThkDTO.StructureWallThicknessMM;

                            response.Active = structuralMinThkDTO.Active;
                            response.CreatedBy = structuralMinThkDTO.CreatedBy;
                            response.CreatedDate = structuralMinThkDTO.CreatedDate;
                            response.ModifiedBy = structuralMinThkDTO.ModifiedBy;
                            response.ModifiedDate = DateTime.Now;
                        }
                        _unitOfWork.StructuralMinThk.Update(response);
                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new StructuralMinThkDTO
                        {
                            ID = structuralMinThkDTO.ID,
                            Status = true,
                            StatusMessage = "Successfully updated",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new StructuralMinThkDTO
                        {
                            ID = tempObj.ID,
                            Status = false,
                            StatusMessage = "Error - Duplicate Component Type.",
                            StatusCode = 200
                        };
                    }
                }
                catch(Exception ex)
                {
                    transaction.Rollback();
                    return new StructuralMinThkDTO()
                    {
                        ID = 0,
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.StructuralMinThk.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.StructuralMinThk.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public List<DropdownDTO> GetDropdownList()
        {
            List<DropdownDTO> list = (from i in _unitOfWork.StructuralMinThk.FindAll()
                                      select new DropdownDTO
                                      {
                                          Value = i.ID.ToString(),
                                          Text = i.ComponentType
                                      }).OrderBy(p => p.Text)
                .ToList();

            return list.OrderBy(p => p.Text).ToList();
        }

    }
}
