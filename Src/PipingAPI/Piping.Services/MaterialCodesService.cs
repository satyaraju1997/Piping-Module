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
    public class MaterialCodesService : IMaterialCodesService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public MaterialCodesService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<MaterialCodesDTO> GetAll()
        {
            List<MaterialCodesDTO> list = (from i in _unitOfWork.MaterialCodes.FindAll()
                                            select new MaterialCodesDTO
                                            {
                                                ID = i.ID,
                                                Name = i.Name,
                                                Code = i.Code,
                                                Active = i.Active,
                                                CreatedBy = i.CreatedBy,
                                                CreatedDate = i.CreatedDate,
                                                ModifiedBy = i.ModifiedBy,
                                                ModifiedDate = i.ModifiedDate
                                            }).OrderBy(p => p.ID)
                .ToList();

            return list.OrderBy(p => p.ID).ToList();
        }

        public MaterialCodesDTO GetByID(int ID)
        {
            return (from i in _unitOfWork.MaterialCodes.FindAll().Where(i => i.ID == ID)
                    select new MaterialCodesDTO
                    {
                        ID = i.ID,
                        Name = i.Name,
                        Code = i.Code,
                        Active = i.Active,
                        CreatedBy = i.CreatedBy,
                        CreatedDate = i.CreatedDate,
                        ModifiedBy = i.ModifiedBy,
                        ModifiedDate = i.ModifiedDate
                    })
                .FirstOrDefault();
        }

        public MaterialCodesDTO Create(MaterialCodesDTO obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    MaterialCodes tempObj = (from i in _unitOfWork.MaterialCodes.GenerateEntityAsIQueryable()
                                              where i.Name == obj.Name
                                              select i).FirstOrDefault();

                    if (tempObj == null)
                    {
                        var materialCode = new MaterialCodes()
                        {
                            Name = obj.Name,
                            Code = obj.Code,
                            Active = true,
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now
                        };

                        _unitOfWork.MaterialCodes.Create(materialCode);
                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new MaterialCodesDTO
                        {
                            ID = materialCode.ID,
                            Status = true,
                            StatusMessage = "Successfully created",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new MaterialCodesDTO
                        {
                            ID = tempObj.ID,
                            Status = false,
                            StatusMessage = "Error - Duplicate Matrial Code - " + tempObj.Name,
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new MaterialCodesDTO()
                    {
                        ID = 0,
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }
        public MaterialCodesDTO Update(MaterialCodesDTO obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    MaterialCodes tempObj = (from r in _unitOfWork.MaterialCodes.GenerateEntityAsIQueryable()
                                              where r.Name == obj.Name && r.ID != obj.ID
                                              select r).FirstOrDefault();

                    if (tempObj == null)
                    {
                        var response = _unitOfWork.MaterialCodes.FindById(obj.ID);
                        if (response != null)
                        {
                            response.Name = obj.Name;
                            response.Code = obj.Code;
                            response.Active = obj.Active;
                            response.CreatedBy = obj.CreatedBy;
                            response.CreatedDate = obj.CreatedDate;
                            response.ModifiedBy = obj.ModifiedBy;
                            response.ModifiedDate = DateTime.Now;
                        }
                        _unitOfWork.MaterialCodes.Update(response);
                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new MaterialCodesDTO
                        {
                            ID = obj.ID,
                            Status = true,
                            StatusMessage = "Successfully updated",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new MaterialCodesDTO
                        {
                            ID = tempObj.ID,
                            Status = false,
                            StatusMessage = "Error - Duplicate Material Code.",
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new MaterialCodesDTO()
                    {
                        ID = 0,
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }       

        public List<DropdownDTO> GetDropdownList()
        {
            List<DropdownDTO> list = (from i in _unitOfWork.MaterialCodes.FindAll()
                                           select new DropdownDTO
                                           {
                                               Value = i.ID.ToString(),
                                               Text = i.Name                                              
                                           }).OrderBy(p => p.Text)
                .ToList();

            return list.OrderBy(p => p.Text).ToList();
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.MaterialCodes.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.MaterialCodes.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

    }
}
