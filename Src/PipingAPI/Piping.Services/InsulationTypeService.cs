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
    public class InsulationTypeService : IInsulationTypeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public InsulationTypeService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<InsulationTypeDTO> GetAll()
        {
            List<InsulationTypeDTO> list = (from i in _unitOfWork.InsulationType.FindAll()
                                            select new InsulationTypeDTO
                                            {
                                                ID = i.ID,
                                                Name = i.Name,
                                                AdjustmentFactor = i.AdjustmentFactor,
                                                Active = i.Active,
                                                CreatedBy = i.CreatedBy,
                                                CreatedDate = i.CreatedDate,
                                                ModifiedBy = i.ModifiedBy,
                                                ModifiedDate = i.ModifiedDate
                                            }).OrderBy(p => p.ID)
                .ToList();

            return list.OrderBy(p => p.ID).ToList();
        }

        public InsulationTypeDTO GetByID(int ID)
        {
            return (from i in _unitOfWork.InsulationType.FindAll().Where(i => i.ID == ID)
                    select new InsulationTypeDTO
                    {
                        ID = i.ID,
                        Name = i.Name,
                        AdjustmentFactor = i.AdjustmentFactor,
                        Active = i.Active,
                        CreatedBy = i.CreatedBy,
                        CreatedDate = i.CreatedDate,
                        ModifiedBy = i.ModifiedBy,
                        ModifiedDate = i.ModifiedDate
                    })
                .FirstOrDefault();
        }

        public InsulationTypeDTO Create(InsulationTypeDTO obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    InsulationType tempObj = (from i in _unitOfWork.InsulationType.GenerateEntityAsIQueryable()
                                              where i.Name == obj.Name
                                              select i).FirstOrDefault();

                    if (tempObj == null)
                    {
                        var insulationType = new InsulationType()
                        {
                            Name = obj.Name,
                            AdjustmentFactor = obj.AdjustmentFactor,
                            Active = true,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now
                        };

                        _unitOfWork.InsulationType.Create(insulationType);
                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new InsulationTypeDTO
                        {
                            ID = insulationType.ID,
                            Status = true,
                            StatusMessage = "Successfully created",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new InsulationTypeDTO
                        {
                            ID = tempObj.ID,
                            Status = false,
                            StatusMessage = "Error - Duplicate Insulation Type - " + tempObj.Name,
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new InsulationTypeDTO()
                    {
                        ID = 0,
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }
        public InsulationTypeDTO Update(InsulationTypeDTO obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    InsulationType tempObj = (from r in _unitOfWork.InsulationType.GenerateEntityAsIQueryable()
                                              where r.Name == obj.Name && r.ID != obj.ID
                                              select r).FirstOrDefault();

                    if (tempObj == null)
                    {
                        var response = _unitOfWork.InsulationType.FindById(obj.ID);
                        if (response != null)
                        {
                            response.Name = obj.Name;
                            response.AdjustmentFactor = obj.AdjustmentFactor;
                            response.Active = obj.Active;
                            response.CreatedBy = obj.CreatedBy;
                            response.CreatedDate = obj.CreatedDate;
                            response.ModifiedBy = obj.ModifiedBy;
                            response.ModifiedDate = DateTime.Now;
                        }
                        _unitOfWork.InsulationType.Update(response);
                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new InsulationTypeDTO
                        {
                            ID = obj.ID,
                            Status = true,
                            StatusMessage = "Successfully updated",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new InsulationTypeDTO
                        {
                            ID = tempObj.ID,
                            Status = false,
                            StatusMessage = "Error - Duplicate Insulation Type.",
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new InsulationTypeDTO()
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
            var entity = _unitOfWork.InsulationType.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.InsulationType.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public List<DropdownDTO> GetDropdownList()
        {
            List<DropdownDTO> list = (from i in _unitOfWork.InsulationType.FindAll()
                                      select new DropdownDTO
                                      {
                                          Value = i.ID.ToString(),
                                          Text = i.Name
                                      }).OrderBy(p => p.Text)
                .ToList();

            return list.OrderBy(p => p.Text).ToList();
        }

    }
}
