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
    public class CorrosionStudyService : ICorrosionStudyService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public CorrosionStudyService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<CorrosionStudyDTO> GetAll()
        {
            return (from p in _unitOfWork.CorrosionStudy.FindAll()
                    select new CorrosionStudyDTO
                    {
                        ID = p.ID,
                        PlantCode = p.PlantCode,
                        LoopNo = p.LoopNo,
                        FluidCode = p.FluidCode,
                        FluidName = p.FluidName,
                        SubFluidCode = p.SubFluidCode,
                        ProcessDescription = p.ProcessDescription,
                        MinPressure = p.MinPressure,
                        MaxPressure = p.MaxPressure,
                        MinTemperature = p.MinTemperature,
                        MaxTemperature = p.MaxTemperature,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate
                    })
                .ToList();
        }

        public CorrosionStudyResponseDTO GetPipeClustersByLoopNo(CorrosionStudyFilterDTO corrosionStudyFilterDTO)
        {
            CorrosionStudyResponseDTO response = new CorrosionStudyResponseDTO();




            List<CorrosionStudyDTO> list = new List<CorrosionStudyDTO>();

            IQueryable<CorrosionStudyDTO> query = (from p in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable()
                                            join l in _context.Plant on p.PlantCode equals l.Code
                                                         select new CorrosionStudyDTO
                                                         {
                                                             ID = p.ID,
                                                             ParentPlantCode = l.ParentPlant.Code,
                                                             PlantCode = p.PlantCode,
                                                             LoopNo = p.CorrosionLoopNo,
                                                             FluidCode = p.FluidCode,
                                                             FluidName = p.FluidName,
                                                             SubFluidCode = p.SubFluid,
                                                             ProcessDescription = "",
                                                             MinPressure = p.DesignPressure,
                                                             MaxPressure = p.DesignPressure,
                                                             MinTemperature = p.DesignTemperature,
                                                             MaxTemperature = p.DesignTemperature,
                                                             ClusterNo = p.PipeClusterNo,
                                                             MaterialCode = p.MaterialCode
                                                         });

            if (corrosionStudyFilterDTO != null)
            {
                if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.LoopNo))
                    query = (from re in query
                             where re.LoopNo == corrosionStudyFilterDTO.LoopNo
                             select re);


                if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.PlantCode))
                    query = (from re in query
                             where re.PlantCode == corrosionStudyFilterDTO.PlantCode
                             select re);

                if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.FluidCode))
                    query = (from re in query
                             where re.FluidCode == corrosionStudyFilterDTO.FluidCode
                             select re);

                if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.ParentPlantCode))
                    query = (from re in query
                             where re.ParentPlantCode == corrosionStudyFilterDTO.ParentPlantCode
                             select re);

                list = query.OrderBy(p => p.LoopNo).ToList();

            }

            response.CorrosionStudyDTO = new CorrosionStudyDTO();

           response.COFMasterDTOList = new List<COFMasterDTO>();

            response.IOWDTOList = new List<IOWDTO>();

            response.PipeClusterPOFDTOList = new List<PipeClusterPOFDTO>();

            CorrosionStudyDTO corrosionStudy = new CorrosionStudyDTO();
            if (list != null && list.Count > 0)
            {
                corrosionStudy.ID = 0;
                corrosionStudy.LoopNo = list.Min(p => p.LoopNo);
                corrosionStudy.MinPressure = list.Min(p => p.MinPressure);
                corrosionStudy.MaxPressure = list.Max(p => p.MinPressure);
                corrosionStudy.MinTemperature = list.Min(p => p.MinTemperature);
                corrosionStudy.MaxTemperature = list.Max(p => p.MinTemperature);
                corrosionStudy.FluidCode = list.Max(p => p.FluidCode);
                corrosionStudy.FluidName = list.Max(p => p.FluidName);
                corrosionStudy.PlantCode = list.Max(p => p.PlantCode);
                corrosionStudy.ParentPlantCode = list.Max(p => p.ParentPlantCode);
                corrosionStudy.ClusterNos = list.Select(p => p.ClusterNo).Distinct().ToList<string>();

                response.CorrosionStudyDTO = corrosionStudy;

                foreach (string cluster in corrosionStudy.ClusterNos)
                {
                    PipeClusterPOFDTO pipeCluster = new PipeClusterPOFDTO();
                    pipeCluster.ID = 0;
                    pipeCluster.Fluid = response.CorrosionStudyDTO.FluidCode;
                    pipeCluster.ClusterNo = cluster;
                    pipeCluster.MaterialCode = list.Where(c => c.ClusterNo == cluster).Select(c => c.MaterialCode).FirstOrDefault();
                    pipeCluster.MinPressure = list.Where(c => c.ClusterNo == cluster).Min(c => c.MinPressure);
                    pipeCluster.MaxPressure = list.Where(c => c.ClusterNo == cluster).Max(c => c.MinPressure);
                    pipeCluster.MinTemperature = list.Where(c => c.ClusterNo == cluster).Min(c => c.MinTemperature);
                    pipeCluster.MaxTemperature = list.Where(c => c.ClusterNo == cluster).Max(c => c.MinTemperature);
                    pipeCluster.CorrosionStudyID = 0;
                    pipeCluster.DMGuideList = new List<DMGuideDTO>();

                    response.PipeClusterPOFDTOList.Add(pipeCluster);

                }
            }  


            return response;
        }

        public CorrosionStudyResponseDTO GetByLoopNo(string LoopNo)
        {
            CorrosionStudyResponseDTO response = new CorrosionStudyResponseDTO();
            try
            {

                CorrosionStudy corrosionStudy = (from s in _unitOfWork.CorrosionStudy.GenerateEntityAsIQueryable()
                                         where s.LoopNo == LoopNo
                                         select s).FirstOrDefault();

                if (corrosionStudy != null)
                {

                    // Corrosion Study
                    response.CorrosionStudyDTO = _mapper.Map<CorrosionStudyDTO>(corrosionStudy);

                    // Pipe Cluster POF
                    List<PipeClusterPOF> pipeClusterPOFList = (from s in _unitOfWork.PipeClusterPOF.GenerateEntityAsIQueryable()
                                                                           where s.CorrosionStudyID == corrosionStudy.ID
                                                                           select s).ToList();

                    if (pipeClusterPOFList != null && pipeClusterPOFList.Count > 0)
                    {
                        response.PipeClusterPOFDTOList = new List<PipeClusterPOFDTO>();
                        List<string> clusters = pipeClusterPOFList.Select(c => c.ClusterNo).Distinct().ToList();
                        foreach (string cluster in clusters)
                        {
                            PipeClusterPOFDTO pipeClusterPOFDTO = new PipeClusterPOFDTO();
                            
                            List<PipeClusterPOF> tempPipeClusterPOFList = pipeClusterPOFList.Where(c => c.ClusterNo == cluster).ToList();
                            if (tempPipeClusterPOFList != null && tempPipeClusterPOFList.Count > 0)
                            {
                                pipeClusterPOFDTO.ID = tempPipeClusterPOFList[0].ID;
                                pipeClusterPOFDTO.Fluid = tempPipeClusterPOFList[0].Fluid;
                                pipeClusterPOFDTO.ClusterNo = cluster;
                                pipeClusterPOFDTO.CorrosionStudyID = tempPipeClusterPOFList[0].CorrosionStudyID;
                                pipeClusterPOFDTO.MaterialCode = tempPipeClusterPOFList[0].MaterialCode;
                                pipeClusterPOFDTO.MinPressure = tempPipeClusterPOFList[0].MinPressure;
                                pipeClusterPOFDTO.MaxPressure = tempPipeClusterPOFList[0].MaxPressure;
                                pipeClusterPOFDTO.MinTemperature = tempPipeClusterPOFList[0].MinTemperature;
                                pipeClusterPOFDTO.MaxTemperature = tempPipeClusterPOFList[0].MaxTemperature;
                                List<DMGuideDTO> dmGuideList = new List<DMGuideDTO>();
                                foreach (PipeClusterPOF pof in tempPipeClusterPOFList)
                                {
                                    
                                    DMGuideDTO dmGuide = new DMGuideDTO();
                                    dmGuide.DMGuideID = pof.ID;
                                    dmGuide.DMCode = pof.DMCode;
                                    dmGuide.DMDescription = pof.DMDescription;
                                    dmGuide.DMRate = pof.DMRate;
                                    dmGuide.DMSeverity = pof.DMSeverity; 
                                    dmGuide.DMType = pof.DMType;
                                    dmGuide.DMSuceptability = pof.DMSuceptability;
                                    dmGuideList.Add(dmGuide);
                                }
                                pipeClusterPOFDTO.DMGuideList = dmGuideList;
                                response.PipeClusterPOFDTOList.Add(pipeClusterPOFDTO);
                            }                            
                        }
                    }
                    else
                    {
                        response.PipeClusterPOFDTOList = new List<PipeClusterPOFDTO>();
                    }

                    // IOW
                    List<IOW> iowList = (from s in _unitOfWork.IOW.GenerateEntityAsIQueryable()
                                                               where s.CorrosionStudyID == corrosionStudy.ID
                                                               select s).ToList();

                    if (iowList != null && iowList.Count > 0)
                    {
                        response.IOWDTOList = new List<IOWDTO>();
                        foreach (IOW iow in iowList)
                        {
                            IOWDTO iowDTO = _mapper.Map<IOWDTO>(iow);
                            response.IOWDTOList.Add(iowDTO);
                        }
                    }
                    else
                    {
                        response.IOWDTOList = new List<IOWDTO>();
                    }

                    // COFMaster
                    List<COFMaster> COFMasterList = (from s in _unitOfWork.COFMaster.GenerateEntityAsIQueryable()
                                         where s.CorrosionStudyID == corrosionStudy.ID
                                         select s).ToList();

                    if (COFMasterList != null && COFMasterList.Count > 0)
                    {
                        response.COFMasterDTOList = new List<COFMasterDTO>();
                        foreach (COFMaster COFMaster in COFMasterList)
                        {
                            COFMasterDTO COFMasterDTO = _mapper.Map<COFMasterDTO>(COFMaster);
                            response.COFMasterDTOList.Add(COFMasterDTO);
                        }
                    }
                    else
                    {
                        response.COFMasterDTOList = new List<COFMasterDTO>();
                    }

                    response.LoopNo = corrosionStudy.LoopNo;
                    response.Status = true;
                    response.StatusMessage = "";
                    response.StatusCode = 200;
                    return response;
                }
                else
                {
                    return new CorrosionStudyResponseDTO
                    {
                        LoopNo = LoopNo,
                        Status = false,
                        StatusMessage = "Report donot exist - " + LoopNo,
                        StatusCode = 200
                    };
                }
            }
            catch (Exception ex)
            {
                return new CorrosionStudyResponseDTO()
                {
                    LoopNo = LoopNo,
                    Status = false,
                    StatusMessage = ex.Message,
                    StatusCode = 200
                };
            }
        }

        public List<CorrosionStudyDTO> GetBySearchFilters(CorrosionStudyFilterDTO corrosionStudyFilterDTO)
        {
            List<CorrosionStudyDTO> list = new List<CorrosionStudyDTO>();

            IQueryable<CorrosionStudyDTO> query = (from p in _unitOfWork.CorrosionStudy.GenerateEntityAsIQueryable()                                             
                                               join l in _context.Plant on p.PlantCode equals l.Code
                                               select new CorrosionStudyDTO
                                               {
                                                   ID = p.ID,
                                                   ParentPlantCode = l.ParentPlant.Code,
                                                   PlantCode = p.PlantCode,
                                                   LoopNo = p.LoopNo,
                                                   FluidCode = p.FluidCode,
                                                   FluidName = p.FluidName,
                                                   SubFluidCode = p.SubFluidCode,
                                                   ProcessDescription = p.ProcessDescription,
                                                   MinPressure = p.MinPressure,
                                                   MaxPressure = p.MaxPressure,
                                                   MinTemperature = p.MinTemperature,
                                                   MaxTemperature = p.MaxTemperature,
                                               });

            if (corrosionStudyFilterDTO != null)
            {
                if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.LoopNo))
                    query = (from re in query
                             where re.LoopNo == corrosionStudyFilterDTO.LoopNo
                             select re);

                
                if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.PlantCode))
                    query = (from re in query
                             where re.PlantCode == corrosionStudyFilterDTO.PlantCode
                             select re);

                if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.FluidCode))
                    query = (from re in query
                             where re.FluidCode == corrosionStudyFilterDTO.FluidCode
                             select re);

                if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.ParentPlantCode))
                    query = (from re in query
                             where re.ParentPlantCode == corrosionStudyFilterDTO.ParentPlantCode
                             select re);                

                list = query.OrderBy(p => p.LoopNo).ToList();

            }


            return list;
        }

        public CorrosionStudyDTO GetByID(int ID)
        {
            return (from p in _unitOfWork.CorrosionStudy.FindAll().Where(p => p.ID == ID)
                    select new CorrosionStudyDTO
                    {
                        ID = p.ID,
                        PlantCode = p.PlantCode,
                        LoopNo = p.LoopNo,
                        FluidCode = p.FluidCode,
                        FluidName = p.FluidName,
                        SubFluidCode = p.SubFluidCode,
                        ProcessDescription = p.ProcessDescription,
                        MinPressure = p.MinPressure,
                        MaxPressure = p.MaxPressure,
                        MinTemperature = p.MinTemperature,
                        MaxTemperature = p.MaxTemperature,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate
                    })
                .FirstOrDefault();
        }
        
        public CorrosionStudyResponseDTO Create(CorrosionStudyRequestDTO CorrosionStudyRequestDTO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    CorrosionStudy tempObj = (from s in _unitOfWork.CorrosionStudy.GenerateEntityAsIQueryable()
                                          where s.LoopNo == CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo
                                              select s).FirstOrDefault();

                    if (tempObj == null)
                    {
                        CorrosionStudy CorrosionStudy = _mapper.Map<CorrosionStudy>(CorrosionStudyRequestDTO.CorrosionStudyDTO);                       
                        CorrosionStudy.ID = 0;
                        CorrosionStudy.CreatedDate = DateTime.Now;                        
                        CorrosionStudy.CreatedBy = "SYSADMIN";
                        CorrosionStudy cr = _unitOfWork.CorrosionStudy.CreateWithReturnEntity(CorrosionStudy);

                        foreach (COFMasterDTO cofMasterDTO in CorrosionStudyRequestDTO.COFMasterDTOList)
                        {
                            COFMaster cofMaster = _mapper.Map<COFMaster>(cofMasterDTO);
                            cofMaster.ID = 0;
                            cofMaster.CorrosionStudyID = cr.ID;
                            cofMaster.LoopNo = CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo;
                            cofMaster.CreatedDate = DateTime.Now;
                            cofMaster.CreatedBy = "SYSADMIN";
                            _unitOfWork.COFMaster.Create(cofMaster);
                        }

                        foreach (IOWDTO iowDTO in CorrosionStudyRequestDTO.IOWDTOList)
                        {
                            IOW iow = _mapper.Map<IOW>(iowDTO);
                            iow.ID = 0;
                            iow.CorrosionStudyID = cr.ID;
                            iow.LoopNo = CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo;
                            iow.CreatedDate = DateTime.Now;
                            iow.CreatedBy = "SYSADMIN";
                            _unitOfWork.IOW.Create(iow);
                        }

                        foreach (PipeClusterPOFDTO pipeClusterPOFDTO in CorrosionStudyRequestDTO.PipeClusterPOFDTOList)
                        {
                            foreach (DMGuideDTO dmGuide in pipeClusterPOFDTO.DMGuideList)
                            {
                                // PipeClusterPOF pipeClusterPOF = _mapper.Map<PipeClusterPOF>(pipeClusterPOFDTO);
                                PipeClusterPOF pipeClusterPOF = new PipeClusterPOF();
                                pipeClusterPOF.ID = 0;
                                pipeClusterPOF.CorrosionStudyID = cr.ID;
                                pipeClusterPOF.CreatedDate = DateTime.Now;
                                pipeClusterPOF.CreatedBy = "SYSADMIN";
                                pipeClusterPOF.ClusterNo = pipeClusterPOFDTO.ClusterNo;
                                pipeClusterPOF.MinPressure = pipeClusterPOFDTO.MinPressure;
                                pipeClusterPOF.MaxPressure = pipeClusterPOFDTO.MaxPressure;
                                pipeClusterPOF.MinTemperature = pipeClusterPOFDTO.MinTemperature;
                                pipeClusterPOF.MaxTemperature = pipeClusterPOFDTO.MaxTemperature;
                                pipeClusterPOF.MaterialCode = pipeClusterPOFDTO.MaterialCode;
                                pipeClusterPOF.Fluid = pipeClusterPOFDTO.Fluid;
                                pipeClusterPOF.DMCode = dmGuide.DMCode;
                                pipeClusterPOF.DMDescription = dmGuide.DMDescription;
                                pipeClusterPOF.DMRate = dmGuide.DMRate;
                                pipeClusterPOF.DMSeverity = dmGuide.DMSeverity;
                                pipeClusterPOF.DMSuceptability = dmGuide.DMSuceptability;
                                pipeClusterPOF.DMType = dmGuide.DMType;
                                pipeClusterPOF.DMGuideDocument = dmGuide.DMGuideDocument;
                                _unitOfWork.PipeClusterPOF.Create(pipeClusterPOF);
                            }
                        }                       

                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new CorrosionStudyResponseDTO
                        {
                            LoopNo = CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo,
                            Status = true,
                            StatusMessage = "Successfully created",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new CorrosionStudyResponseDTO
                        {
                            LoopNo = CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo,
                            Status = false,
                            StatusMessage = "Error - Duplicate Loop No - " + CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo,
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new CorrosionStudyResponseDTO()
                    {
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }


        public CorrosionStudyResponseDTO Update(CorrosionStudyRequestDTO CorrosionStudyRequestDTO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    CorrosionStudy tempObj = _unitOfWork.CorrosionStudy.FindById(CorrosionStudyRequestDTO.CorrosionStudyDTO.ID);
                  
                    if (tempObj != null)
                    {
                        tempObj.ModifiedBy = "SYSADMIN";
                        tempObj.ModifiedDate = DateTime.Now;
                        _unitOfWork.CorrosionStudy.Update(tempObj);

                        foreach (COFMasterDTO cofMasterDTO in CorrosionStudyRequestDTO.COFMasterDTOList)
                        {
                            COFMaster cofMaster = new COFMaster();
                            if (cofMasterDTO.ID > 0)
                            {
                                cofMaster = _unitOfWork.COFMaster.FindById(cofMasterDTO.ID);
                                cofMaster.DetectionRating = cofMasterDTO.DetectionRating;
                                cofMaster.ToxicFluidFraction = cofMasterDTO.ToxicFluidFraction;
                                cofMaster.ToxicReferenceFluid = cofMasterDTO.ToxicReferenceFluid;
                                cofMaster.RefresentativeFluid = cofMasterDTO.RefresentativeFluid;
                                cofMaster.MitigationFactor = cofMasterDTO.MitigationFactor;
                                cofMaster.IsolationRating = cofMasterDTO.IsolationRating;
                                cofMaster.ModifiedBy = "SYSADMIN";
                                cofMaster.ModifiedDate = DateTime.Now;
                                _unitOfWork.COFMaster.Update(cofMaster);
                            }
                            else
                            {
                                cofMaster = _mapper.Map<COFMaster>(cofMasterDTO);
                                cofMaster.ID = 0;
                                cofMaster.LoopNo = CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo;
                                cofMaster.CorrosionStudyID = tempObj.ID;
                                cofMaster.CreatedDate = DateTime.Now;
                                cofMaster.CreatedBy = "SYSADMIN";
                                _unitOfWork.COFMaster.Create(cofMaster);
                            }
                        }

                        foreach (IOWDTO iowDTO in CorrosionStudyRequestDTO.IOWDTOList)
                        {
                            IOW iow = new IOW();
                            if (iowDTO.ID > 0)
                            {
                                iow.Unit = iowDTO.Unit;
                                iow.IOWNo = iowDTO.IOWNo;
                                iow.Min = iowDTO.Min;
                                iow.Max = iowDTO.Max;
                                iow.Parameter = iowDTO.Parameter;
                                iow.TagNo = iowDTO.TagNo;
                                iow.RelatedUnitNo = iowDTO.RelatedUnitNo;
                                iow.ModifiedBy = "SYSADMIN";
                                iow.ModifiedDate = DateTime.Now;
                                _unitOfWork.IOW.Update(iow);
                            }
                            else
                            {
                                iow = _mapper.Map<IOW>(iowDTO);
                                iow.ID = 0;
                                iow.LoopNo = CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo;
                                iow.CorrosionStudyID = tempObj.ID;
                                iow.CreatedDate = DateTime.Now;
                                iow.CreatedBy = "SYSADMIN";
                                _unitOfWork.IOW.Create(iow);
                            }
                        }

                        foreach (PipeClusterPOFDTO pipeClusterPOFDTO in CorrosionStudyRequestDTO.PipeClusterPOFDTOList)
                        {
                            foreach (DMGuideDTO dmGuide in pipeClusterPOFDTO.DMGuideList)
                            {
                                PipeClusterPOF pipeClusterPOF = new PipeClusterPOF();
                                if (dmGuide.DMGuideID.HasValue && dmGuide.DMGuideID.Value > 0)
                                {
                                    pipeClusterPOF = _unitOfWork.PipeClusterPOF.FindById(dmGuide.DMGuideID.Value);                                    
                                    pipeClusterPOF.MinPressure = pipeClusterPOFDTO.MinPressure;
                                    pipeClusterPOF.MaxPressure = pipeClusterPOFDTO.MaxPressure;
                                    pipeClusterPOF.MinTemperature = pipeClusterPOFDTO.MinTemperature;
                                    pipeClusterPOF.MaxTemperature = pipeClusterPOFDTO.MaxTemperature;
                                    pipeClusterPOF.MaterialCode = pipeClusterPOFDTO.MaterialCode;
                                    pipeClusterPOF.Fluid = pipeClusterPOFDTO.Fluid;
                                    pipeClusterPOF.DMCode = dmGuide.DMCode;
                                    pipeClusterPOF.DMDescription = dmGuide.DMDescription;
                                    pipeClusterPOF.DMRate = dmGuide.DMRate;
                                    pipeClusterPOF.DMSeverity = dmGuide.DMSeverity;
                                    pipeClusterPOF.DMSuceptability = dmGuide.DMSuceptability;
                                    pipeClusterPOF.DMType = dmGuide.DMType;
                                    pipeClusterPOF.DMGuideDocument = dmGuide.DMGuideDocument;
                                    pipeClusterPOF.ModifiedDate = DateTime.Now;
                                    pipeClusterPOF.ModifiedBy = "SYSADMIN";                                    
                                    _unitOfWork.PipeClusterPOF.Update(pipeClusterPOF);
                                }
                                else
                                {
                                    pipeClusterPOF.ID = 0;
                                    pipeClusterPOF.CorrosionStudyID = tempObj.ID;                                    
                                    pipeClusterPOF.CreatedDate = DateTime.Now;
                                    pipeClusterPOF.CreatedBy = "SYSADMIN";
                                    pipeClusterPOF.ClusterNo = pipeClusterPOFDTO.ClusterNo;
                                    pipeClusterPOF.MinPressure = pipeClusterPOFDTO.MinPressure;
                                    pipeClusterPOF.MaxPressure = pipeClusterPOFDTO.MaxPressure;
                                    pipeClusterPOF.MinTemperature = pipeClusterPOFDTO.MinTemperature;
                                    pipeClusterPOF.MaxTemperature = pipeClusterPOFDTO.MaxTemperature;
                                    pipeClusterPOF.MaterialCode = pipeClusterPOFDTO.MaterialCode;
                                    pipeClusterPOF.Fluid = pipeClusterPOFDTO.Fluid;
                                    pipeClusterPOF.DMCode = dmGuide.DMCode;
                                    pipeClusterPOF.DMDescription = dmGuide.DMDescription;
                                    pipeClusterPOF.DMRate = dmGuide.DMRate;
                                    pipeClusterPOF.DMSeverity = dmGuide.DMSeverity;
                                    pipeClusterPOF.DMSuceptability = dmGuide.DMSuceptability;
                                    pipeClusterPOF.DMType = dmGuide.DMType;
                                    pipeClusterPOF.DMGuideDocument = dmGuide.DMGuideDocument;
                                    _unitOfWork.PipeClusterPOF.Create(pipeClusterPOF);
                                }
                            }                           
                        }

                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new CorrosionStudyResponseDTO
                        {
                            LoopNo = tempObj.LoopNo,
                            Status = true,
                            StatusMessage = "Successfully created",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new CorrosionStudyResponseDTO
                        {
                            LoopNo = CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo,
                            Status = false,
                            StatusMessage = "Error - Duplicate Loop No - " + CorrosionStudyRequestDTO.CorrosionStudyDTO.LoopNo,
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new CorrosionStudyResponseDTO()
                    {
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }
        public void Update(CorrosionStudyDTO CorrosionStudyDTO)
        {
            var response = _unitOfWork.CorrosionStudy.FindById(CorrosionStudyDTO.ID);
            if (response != null)
            {
                response.PlantCode = CorrosionStudyDTO.PlantCode;
                response.LoopNo = CorrosionStudyDTO.LoopNo;
                response.FluidCode = CorrosionStudyDTO.FluidCode;
                response.FluidName = CorrosionStudyDTO.FluidName;
                response.SubFluidCode = CorrosionStudyDTO.SubFluidCode;
                response.ProcessDescription = CorrosionStudyDTO.ProcessDescription;
                response.MinPressure = CorrosionStudyDTO.MinPressure;
                response.MaxPressure = CorrosionStudyDTO.MaxPressure;
                response.MinTemperature = CorrosionStudyDTO.MinTemperature;
                response.MaxTemperature = CorrosionStudyDTO.MaxTemperature;
                response.CreatedBy = CorrosionStudyDTO.CreatedBy;
                response.CreatedDate = CorrosionStudyDTO.CreatedDate;
                response.ModifiedBy = CorrosionStudyDTO.ModifiedBy;
                response.ModifiedDate = DateTime.Now;             
            }
            _unitOfWork.CorrosionStudy.Update(response);
            _unitOfWork.SaveChanges();
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.CorrosionStudy.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.CorrosionStudy.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public List<DropdownDTO> GetPlantCodeDropdownList(string plantCode)
        {
            List<DropdownDTO> list = (from p in _unitOfWork.PipeMaster.FindAll()
                                      join l in _context.Plant on p.PlantCode equals l.Code
                                      where l.ParentPlant.Code == plantCode
                                      group p by p.PlantCode into g
                                      select new DropdownDTO
                                      {
                                          Value = g.Key,
                                          Text = g.Key
                                      }).OrderBy(p => p.Text)
                .ToList();

            return list.OrderBy(p => p.Text).ToList();
        }

        public List<DropdownDTO> GetFluidCodeDropdownList(string plantCode)
        {
            List<DropdownDTO> list = (from p in _unitOfWork.PipeMaster.FindAll()
                                      join l in _context.Plant on p.PlantCode equals l.Code
                                      where l.ParentPlant.Code == plantCode
                                      group p by p.FluidCode into g                                      
                                      select new DropdownDTO
                                      {
                                          Value = g.Key,
                                          Text = g.Key
                                      }).OrderBy(p => p.Text)
                .ToList();

            return list.OrderBy(p => p.Text).ToList();
        }

        public List<DropdownDTO> GetLoopNoDropdownList(string plantCode)
        {
            List<DropdownDTO> list = (from p in _unitOfWork.PipeMaster.FindAll()
                                      join l in _context.Plant on p.PlantCode equals l.Code
                                      where l.ParentPlant.Code == plantCode
                                      group p by p.CorrosionLoopNo into g
                                      select new DropdownDTO
                                      {
                                          Value = g.Key,
                                          Text = g.Key
                                      }).OrderBy(p => p.Text)
                .ToList();

            return list.OrderBy(p => p.Text).ToList();
        }

    }
}
