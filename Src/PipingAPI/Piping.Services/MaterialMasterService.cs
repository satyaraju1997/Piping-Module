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
    public class MaterialMasterService : IMaterialMasterService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public MaterialMasterService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<MaterialMasterDTO> GetAll()
        {
            List<MaterialMasterDTO> list = (from i in _unitOfWork.MaterialMaster.FindAll()
                                            select new MaterialMasterDTO
                                            {
                                                ID = i.ID,
                                                SPEC_NO = i.SPEC_NO,                                                
                                                CreatedBy = i.CreatedBy,
                                                CreatedDate = i.CreatedDate,
                                                ModifiedBy = i.ModifiedBy,
                                                ModifiedDate = i.ModifiedDate
                                            }).OrderBy(p => p.ID)
                .ToList();

            return list.OrderBy(p => p.ID).ToList();
        }

        public MaterialMasterDTO GetByID(int ID)
        {
            return (from i in _unitOfWork.MaterialMaster.FindAll().Where(i => i.ID == ID)
                    select new MaterialMasterDTO
                    {
                        ID = i.ID,
                        SPEC_NO = i.SPEC_NO,                       
                        CreatedBy = i.CreatedBy,
                        CreatedDate = i.CreatedDate,
                        ModifiedBy = i.ModifiedBy,
                        ModifiedDate = i.ModifiedDate
                    })
                .FirstOrDefault();
        }

        public MaterialMasterDTO Create(MaterialMasterDTO obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    MaterialMaster tempObj = (from i in _unitOfWork.MaterialMaster.GenerateEntityAsIQueryable()
                                              where i.SPEC_NO == obj.SPEC_NO
                                             select i).FirstOrDefault();

                    if (tempObj == null)
                    {
                        var materialMaster = new MaterialMaster()
                        {
                            SPEC_NO = obj.SPEC_NO,
                            TYPE_GRADE = obj.TYPE_GRADE,                           
                            CreatedBy = obj.CreatedBy,
                            CreatedDate = DateTime.Now
                        };

                        _unitOfWork.MaterialMaster.Create(materialMaster);
                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new MaterialMasterDTO
                        {
                            ID = materialMaster.ID,
                            Status = true,
                            StatusMessage = "Successfully created",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new MaterialMasterDTO
                        {
                            ID = tempObj.ID,
                            Status = false,
                            StatusMessage = "Error - Duplicate Matrial - " + tempObj.SPEC_NO,
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new MaterialMasterDTO()
                    {
                        ID = 0,
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }
        public MaterialMasterDTO Update(MaterialMasterDTO obj)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    MaterialMaster tempObj = (from r in _unitOfWork.MaterialMaster.GenerateEntityAsIQueryable()
                                              where r.SPEC_NO == obj.SPEC_NO && r.ID != obj.ID
                                              select r).FirstOrDefault();

                    if (tempObj == null)
                    {
                        var response = _unitOfWork.MaterialMaster.FindById(obj.ID);
                        if (response != null)
                        {
                            response.NOMINAL_COMPOSITION = obj.NOMINAL_COMPOSITION;
                            response.PRODUCT_FORM = obj.PRODUCT_FORM;                           
                            response.CreatedBy = obj.CreatedBy;
                            response.CreatedDate = obj.CreatedDate;
                            response.ModifiedBy = obj.ModifiedBy;
                            response.ModifiedDate = DateTime.Now;
                        }
                        _unitOfWork.MaterialMaster.Update(response);
                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new MaterialMasterDTO
                        {
                            ID = obj.ID,
                            Status = true,
                            StatusMessage = "Successfully updated",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new MaterialMasterDTO
                        {
                            ID = tempObj.ID,
                            Status = false,
                            StatusMessage = "Error - Duplicate Material.",
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new MaterialMasterDTO()
                    {
                        ID = 0,
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }
        public List<DropdownDTO> GetMaterialStdDropdownList()
        {
            List<DropdownDTO> materialList = new List<DropdownDTO>();
            List<string> list = (from i in _unitOfWork.MaterialMaster.FindAll()
                                 group i by i.SPEC_NO into g
                                 orderby g.Key
                                 select g.Key).ToList();

            foreach (var item in list)
            {
                materialList.Add(new DropdownDTO { Value = item, Text = item });
            }

            return materialList.Distinct().OrderBy(p => p.Text).ToList();
        }
        public List<DropdownDTO> GetMaterialGradeDropdownList()
        {         

            List<DropdownDTO> materialList = new List<DropdownDTO>();
            List<string> list = (from i in _unitOfWork.MaterialMaster.FindAll()
                                 group i by i.TYPE_GRADE into g
                                 orderby g.Key
                                 select g.Key).ToList();
           
            foreach (string item in list)
            {
                materialList.Add(new DropdownDTO { Value = item, Text = item });
            }

            return materialList.Distinct().OrderBy(p => p.Text).ToList();
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.MaterialMaster.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.MaterialMaster.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

    }
}
