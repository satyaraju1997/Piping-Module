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
    public class PipeReportService : IPipeReportService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public PipeReportService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<PipeReportDTO> GetAll()
        {
            List <PipeReportDTO>  list = (from p in _unitOfWork.PipeReport.FindAll()
                    select new PipeReportDTO
                    {
                        ID = p.ID,
                        EquipmentNo = p.EquipmentNo,
                        ReportNo = p.ReportNo,
                        FromTo = p.FromTo,
                        OverallCondition = p.OverallCondition,
                        OverallStatus = p.OverallStatus,
                        ConsequenceRank = p.ConsequenceRank,
                        NextFollowUpDate = p.NextFollowUpDate,
                        ResultedInto = p.ResultedInto,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedDate = p.ModifiedDate
                    }).OrderBy(p => p.ID)
                .ToList();

            return list.OrderBy(p => p.ID).ToList();
        }

        public List<ObservationMasterDTO> GetAllObservations()
        {
            List<ObservationMasterDTO> list = (from p in _unitOfWork.ObservationMaster.FindAll()
                                        select new ObservationMasterDTO
                                        {
                                            ID = p.ID,
                                            Description = p.Description,
                                            Active= p.Active
                                        }).OrderBy(p => p.Description)
                .ToList();

            return list.OrderBy(p => p.ID).ToList();
        }
        public List<PipeReportDTO> GetByEquipmentNo(string EquipmentNo)
        {
            List<PipeReportDTO> list = (from p in _unitOfWork.PipeReport.GenerateEntityAsIQueryable()
                                        where p.EquipmentNo == EquipmentNo
                                        select new PipeReportDTO
                                        {
                                            ID = p.ID,
                                            EquipmentNo = p.EquipmentNo,
                                            ReportNo = p.ReportNo,
                                            FromTo = p.FromTo,
                                            OverallCondition = p.OverallCondition,
                                            OverallStatus = p.OverallStatus,
                                            ConsequenceRank = p.ConsequenceRank,
                                            NextFollowUpDate = p.NextFollowUpDate,
                                            ResultedInto = p.ResultedInto,
                                            CreatedBy = p.CreatedBy,
                                            CreatedDate = p.CreatedDate,
                                            ModifiedBy = p.ModifiedBy,
                                            ModifiedDate = p.ModifiedDate
                                        }).OrderBy(p => p.ID)
                .ToList();

            return list.OrderBy(p => p.ReportNo).ToList();
        }

         public List<PipeReportDTO> GetBySearchFilters(PipeReportFilterDTO pipeReportFilterDTO)
        {
            List<PipeReportDTO> reportList = new List<PipeReportDTO>();

            IQueryable<PipeReportDTO> query = (from p in _unitOfWork.PipeReport.GenerateEntityAsIQueryable()
                                               join m in _context.PipeMaster on p.PipeMasterID equals m.ID
                                               join l in _context.Plant on p.PlantCode equals l.Code
                                               select new PipeReportDTO
                                               {
                                                   ID = p.ID,
                                                   EquipmentNo = p.EquipmentNo,
                                                   ReportNo = p.ReportNo,
                                                   PipeMasterID = p.PipeMasterID,
                                                   FromTo = p.FromTo,
                                                   FluidCode = m.FluidCode,
                                                   ParentPlantCode = l.ParentPlant.Code,
                                                   PlantCode = m.PlantCode,                                                   
                                                   OverallCondition = p.OverallCondition,
                                                   OverallStatus = p.OverallStatus,
                                                   ConsequenceRank = p.ConsequenceRank,
                                                   InspectionYear = p.InspectionYear,
                                                   DefectCode = p.DefectCode,                                                   
                                                   NextFollowUpDate = p.NextFollowUpDate,
                                                   ResultedInto = p.ResultedInto,
                                                   CreatedBy = p.CreatedBy,
                                                   CreatedDate = p.CreatedDate,
                                                   ModifiedBy = p.ModifiedBy,
                                                   ModifiedDate = p.ModifiedDate
                                               });

            if (pipeReportFilterDTO != null)
            {
                if (!string.IsNullOrWhiteSpace(pipeReportFilterDTO.EquipmentNo))
                    query = (from re in query
                             where re.EquipmentNo == pipeReportFilterDTO.EquipmentNo
                             select re);

                if (!string.IsNullOrWhiteSpace(pipeReportFilterDTO.ReportNo))
                    query = (from re in query
                             where re.ReportNo == pipeReportFilterDTO.ReportNo
                             select re);

                if (!string.IsNullOrWhiteSpace(pipeReportFilterDTO.PlantCode))
                    query = (from re in query
                             where re.PlantCode == pipeReportFilterDTO.PlantCode
                             select re);

                if (!string.IsNullOrWhiteSpace(pipeReportFilterDTO.FluidCode))
                    query = (from re in query
                             where re.FluidCode == pipeReportFilterDTO.FluidCode
                             select re);

                if (!string.IsNullOrWhiteSpace(pipeReportFilterDTO.ParentPlantCode))
                    query = (from re in query
                             where re.ParentPlantCode == pipeReportFilterDTO.ParentPlantCode
                             select re);

                if (!string.IsNullOrWhiteSpace(pipeReportFilterDTO.DefectCode))
                    query = (from re in query
                             where re.DefectCode == pipeReportFilterDTO.DefectCode
                             select re);

                if (!string.IsNullOrWhiteSpace(pipeReportFilterDTO.Status))
                    query = (from re in query
                             where re.OverallStatus == pipeReportFilterDTO.Status
                             select re);

                if (pipeReportFilterDTO.InspectionYear.HasValue)
                    query = (from re in query
                             where re.InspectionYear == pipeReportFilterDTO.InspectionYear
                             select re);




                reportList = query.OrderBy(p => p.ReportNo).ToList();

            }
            

            return reportList;            
        }
        public PipeReportDTO GetByID(int ID)
        {
            PipeReport pipeReport = _unitOfWork.PipeReport.FindById(ID);
            PipeReportDTO pipeReportDTO = _mapper.Map<PipeReportDTO>(pipeReport);
            return pipeReportDTO;
        }       
        public PipeReportResponseDTO GetByReportNo(string ReportNo)
        {
            PipeReportResponseDTO response = new PipeReportResponseDTO();
                try
                {

                    PipeReport pipeReport = (from s in _unitOfWork.PipeReport.GenerateEntityAsIQueryable()
                                          where s.ReportNo == ReportNo
                                          select s).FirstOrDefault();

                if (pipeReport != null)
                {

                    // Pipe Report
                    response.PipeReport = _mapper.Map<PipeReportDTO>(pipeReport);

                    // Inspection Confidence
                    List<InspectionConfidence> inspectionConfidenceList = (from s in _unitOfWork.InspectionConfidence.GenerateEntityAsIQueryable()
                                                                           where s.PipeReportID == pipeReport.ID
                                                                           select s).ToList();

                    if (inspectionConfidenceList != null && inspectionConfidenceList.Count > 0)
                    {
                        response.InspectionConfidenceList = new List<InspectionConfidenceDTO>();
                        foreach (InspectionConfidence confidence in inspectionConfidenceList)
                        {
                            InspectionConfidenceDTO inspectionConfidenceDTO = _mapper.Map<InspectionConfidenceDTO>(confidence);
                            response.InspectionConfidenceList.Add(inspectionConfidenceDTO);
                        }
                    }

                    // Inspection Observation
                    List<InspectionObservation> inspectionObservationList = (from s in _unitOfWork.InspectionObservation.GenerateEntityAsIQueryable()
                                                                             where s.PipeReportID == pipeReport.ID
                                                                             select s).ToList();

                    if (inspectionObservationList != null && inspectionObservationList.Count > 0)
                    {
                        response.InspectionObservationList = new List<InspectionObservationDTO>();
                        foreach (InspectionObservation observation in inspectionObservationList)
                        {
                            InspectionObservationDTO inspectionObservationDTO = _mapper.Map<InspectionObservationDTO>(observation);
                            response.InspectionObservationList.Add(inspectionObservationDTO);
                        }
                    }

                    // Inspection Program
                    List<InspectionProgram> inspectionProgramList = (from s in _unitOfWork.InspectionProgram.GenerateEntityAsIQueryable()
                                                                     where s.PipeReportID == pipeReport.ID
                                                                     select s).ToList();

                    if (inspectionProgramList != null && inspectionProgramList.Count > 0)
                    {
                        response.InspectionProgramList = new List<InspectionProgramDTO>();
                        foreach (InspectionProgram program in inspectionProgramList)
                        {
                            InspectionProgramDTO inspectionProgramDTO = _mapper.Map<InspectionProgramDTO>(program);
                            response.InspectionProgramList.Add(inspectionProgramDTO);
                        }
                    }

                    // Inspection Document
                    List<InspectionDocument> inspectionDocumentList = (from s in _unitOfWork.InspectionDocument.GenerateEntityAsIQueryable()
                                                                       where s.PipeReportID == pipeReport.ID
                                                                       select s).ToList();

                    if (inspectionDocumentList != null && inspectionDocumentList.Count > 0)
                    {
                        response.InspectionDocumentList = new List<InspectionDocumentDTO>();
                        foreach (InspectionDocument document in inspectionDocumentList)
                        {
                            InspectionDocumentDTO inspectionDocumentDTO = _mapper.Map<InspectionDocumentDTO>(document);
                            response.InspectionDocumentList.Add(inspectionDocumentDTO);
                        }
                    }

                    // Inspection Recommendation
                    List<InspectionRecommendation> inspectionRecommendationList = (from s in _unitOfWork.InspectionRecommendation.GenerateEntityAsIQueryable()
                                                                                   where s.PipeReportID == pipeReport.ID
                                                                                   select s).ToList();

                    if (inspectionRecommendationList != null && inspectionRecommendationList.Count > 0)
                    {
                        response.InspectionRecommendationList = new List<InspectionRecommendationDTO>();
                        foreach (InspectionRecommendation recommendation in inspectionRecommendationList)
                        {
                            InspectionRecommendationDTO inspectionRecommendationDTO = _mapper.Map<InspectionRecommendationDTO>(recommendation);
                            response.InspectionRecommendationList.Add(inspectionRecommendationDTO);
                        }
                    }

                    // Inspection Distribution
                    List<InspectionDistribution> inspectionDistributionList = (from s in _unitOfWork.InspectionDistribution.GenerateEntityAsIQueryable()
                                                                               where s.PipeReportID == pipeReport.ID
                                                                               select s).ToList();

                    if (inspectionDistributionList != null && inspectionDistributionList.Count > 0)
                    {
                        response.InspectionDistributionList = new List<InspectionDistributionDTO>();
                        foreach (InspectionDistribution distribution in inspectionDistributionList)
                        {
                            InspectionDistributionDTO inspectionDistributionDTO = _mapper.Map<InspectionDistributionDTO>(distribution);
                            response.InspectionDistributionList.Add(inspectionDistributionDTO);
                        }
                    }

                    // TML
                    List<TML> TMLList = (from s in _unitOfWork.TML.GenerateEntityAsIQueryable()
                                         where s.PipeReportID == pipeReport.ID
                                         select s).ToList();

                    if (TMLList != null && TMLList.Count > 0)
                    {
                        response.TMLList = new List<TMLDTO>();
                        foreach (TML tml in TMLList)
                        {
                            TMLDTO TMLDTO = _mapper.Map<TMLDTO>(tml);
                            response.TMLList.Add(TMLDTO);
                        }
                    }

                    response.ReportNo = pipeReport.ReportNo;
                    response.Status = true;
                    response.StatusMessage = "";
                    response.StatusCode = 200;
                    return response;
                }
                else
                {
                    return new PipeReportResponseDTO
                    {
                        Status = false,
                        StatusMessage = "Report donot exist - " + ReportNo,
                        StatusCode = 200
                    };
                }
                }
                catch (Exception ex)
                {                    
                    return new PipeReportResponseDTO()
                    {
                        ReportNo = ReportNo,
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }            
        }               
        public PipeReportResponseDTO Create(PipeReportRequestDTO PipeReportRequestDTO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    PipeReport tempObj = (from s in _unitOfWork.PipeReport.GenerateEntityAsIQueryable()
                                                 where s.ReportNo == PipeReportRequestDTO.PipeReport.ReportNo 
                                                 select s).FirstOrDefault();

                    if (tempObj == null)
                    {

                        PipeReport pipeReport = _mapper.Map<PipeReport>(PipeReportRequestDTO.PipeReport);
                        pipeReport.ID = 0;
                        pipeReport.CreatedDate = DateTime.Now;
                        pipeReport.ReportNo = GenerateReportNo(DateTime.Now.Year.ToString());
                        pipeReport.CreatedBy = "SYSADMIN";
                        PipeReport report = _unitOfWork.PipeReport.CreateWithReturnEntity(pipeReport);
                        if (PipeReportRequestDTO.InspectionConfidenceList != null && PipeReportRequestDTO.InspectionConfidenceList.Count > 0)
                        {
                            foreach (InspectionConfidenceDTO confidence in PipeReportRequestDTO.InspectionConfidenceList)
                            {
                                InspectionConfidence inspectionConfidence = _mapper.Map<InspectionConfidence>(confidence);
                                inspectionConfidence.ID = 0;
                                inspectionConfidence.PipeReportID = report.ID;
                                inspectionConfidence.PipeMasterID = report.PipeMasterID;
                                inspectionConfidence.ReportNo = report.ReportNo;
                                inspectionConfidence.EquipmentNo = report.EquipmentNo;
                                inspectionConfidence.CreatedDate = DateTime.Now;
                                inspectionConfidence.CreatedBy = "SYSADMIN";
                                _unitOfWork.InspectionConfidence.Create(inspectionConfidence);
                            }
                        }
                        if (PipeReportRequestDTO.InspectionObservationList != null && PipeReportRequestDTO.InspectionObservationList.Count > 0)
                        {
                            foreach (InspectionObservationDTO inspectionObservationDTO in PipeReportRequestDTO.InspectionObservationList)
                            {
                                InspectionObservation inspectionObservation = _mapper.Map<InspectionObservation>(inspectionObservationDTO);
                                inspectionObservation.ID = 0;
                                inspectionObservation.PipeReportID = report.ID;
                                inspectionObservation.PipeMasterID = report.PipeMasterID;
                                inspectionObservation.ReportNo = report.ReportNo;
                                inspectionObservation.EquipmentNo = report.EquipmentNo;
                                inspectionObservation.CreatedDate = DateTime.Now;
                                inspectionObservation.CreatedBy = "SYSADMIN";
                                _unitOfWork.InspectionObservation.Create(inspectionObservation);
                            }
                        }

                        if (PipeReportRequestDTO.InspectionRecommendationList != null && PipeReportRequestDTO.InspectionRecommendationList.Count > 0)
                        {
                            foreach (InspectionRecommendationDTO inspectionRecommendationDTO in PipeReportRequestDTO.InspectionRecommendationList)
                            {
                                InspectionRecommendation inspectionRecommendation = _mapper.Map<InspectionRecommendation>(inspectionRecommendationDTO);
                                inspectionRecommendation.ID = 0;
                                inspectionRecommendation.PipeReportID = report.ID;
                                inspectionRecommendation.PipeMasterID = report.PipeMasterID;
                                inspectionRecommendation.ReportNo = report.ReportNo;
                                inspectionRecommendation.EquipmentNo = report.EquipmentNo;
                                inspectionRecommendation.CreatedDate = DateTime.Now;
                                inspectionRecommendation.CreatedBy = "SYSADMIN";
                                _unitOfWork.InspectionRecommendation.Create(inspectionRecommendation);
                            }
                        }
                        if (PipeReportRequestDTO.InspectionDistributionList != null && PipeReportRequestDTO.InspectionDistributionList.Count > 0)
                        {
                            foreach (InspectionDistributionDTO inspectionDistributionDTO in PipeReportRequestDTO.InspectionDistributionList)
                            {
                                InspectionDistribution inspectionDistribution = _mapper.Map<InspectionDistribution>(inspectionDistributionDTO);
                                inspectionDistribution.ID = 0;
                                inspectionDistribution.PipeReportID = report.ID;
                                inspectionDistribution.CreatedDate = DateTime.Now;
                                inspectionDistribution.CreatedBy = "SYSADMIN";
                                _unitOfWork.InspectionDistribution.Create(inspectionDistribution);
                            }
                        }
                        if (PipeReportRequestDTO.InspectionProgramList != null && PipeReportRequestDTO.InspectionProgramList.Count > 0)
                        {
                            foreach (InspectionProgramDTO inspectionProgramDTO in PipeReportRequestDTO.InspectionProgramList)
                            {
                                InspectionProgram inspectionProgram = _mapper.Map<InspectionProgram>(inspectionProgramDTO);
                                inspectionProgram.ID = 0;
                                inspectionProgram.PipeReportID = report.ID;
                                inspectionProgram.PipeMasterID = report.PipeMasterID;
                                inspectionProgram.ReportNo = report.ReportNo;
                                inspectionProgram.EquipmentNo = report.EquipmentNo;
                                inspectionProgram.CreatedDate = DateTime.Now;
                                inspectionProgram.CreatedBy = "SYSADMIN";
                                _unitOfWork.InspectionProgram.Create(inspectionProgram);
                            }
                        }
                        if (PipeReportRequestDTO.TMLList != null && PipeReportRequestDTO.TMLList.Count > 0)
                        {
                            foreach (TMLDTO tmlDTO in PipeReportRequestDTO.TMLList)
                            {
                                TML tml = _mapper.Map<TML>(tmlDTO);
                                tml.ID = 0;
                                tml.PipeReportID = report.ID;
                                tml.PipeMasterID = report.PipeMasterID;
                                tml.ReportNo = report.ReportNo;
                                tml.EquipmentNo = report.EquipmentNo;
                                tml.CreatedDate = DateTime.Now;
                                tml.CreatedBy = "SYSADMIN";
                                _unitOfWork.TML.Create(tml);
                            }
                        }

                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new PipeReportResponseDTO
                        {           
                            ReportNo = PipeReportRequestDTO.PipeReport.ReportNo,
                            Status = true,
                            StatusMessage = "Successfully created",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new PipeReportResponseDTO
                        {        
                            ReportNo = PipeReportRequestDTO.PipeReport.ReportNo,
                            Status = false,
                            StatusMessage = "Error - Duplicate Report - " + PipeReportRequestDTO.PipeReport.ReportNo,
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new PipeReportResponseDTO()
                    {                       
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }
        public PipeReportResponseDTO Update(PipeReportRequestDTO PipeReportRequestDTO)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    PipeReport tempObj = (from s in _unitOfWork.PipeReport.GenerateEntityAsIQueryable()
                                          where s.ReportNo == PipeReportRequestDTO.PipeReport.ReportNo
                                          select s).FirstOrDefault();

                    if (tempObj != null)
                    {

                      //  PipeReport pipeReport = _mapper.Map<PipeReport>(PipeReportRequestDTO.PipeReport);
                        tempObj.ModifiedBy = "SYSADMIN";
                        tempObj.ModifiedDate = DateTime.Now;
                        _unitOfWork.PipeReport.Update(tempObj);

                        foreach (InspectionConfidenceDTO confidence in PipeReportRequestDTO.InspectionConfidenceList)
                        {
                            InspectionConfidence inspectionConfidence = _mapper.Map<InspectionConfidence>(confidence);
                            if (inspectionConfidence.ID > 0)
                            {
                                inspectionConfidence.ModifiedBy = "SYSADMIN";
                                inspectionConfidence.ModifiedDate = DateTime.Now;
                                _unitOfWork.InspectionConfidence.Update(inspectionConfidence);
                            }                           
                        }

                        foreach (InspectionObservationDTO inspectionObservationDTO in PipeReportRequestDTO.InspectionObservationList)
                        {
                            InspectionObservation inspectionObservation = _mapper.Map<InspectionObservation>(inspectionObservationDTO);
                           
                            if (inspectionObservation.ID > 0)
                            {
                                inspectionObservation.ModifiedBy = "SYSADMIN";
                                inspectionObservation.ModifiedDate = DateTime.Now;
                                _unitOfWork.InspectionObservation.Update(inspectionObservation);
                            }
                            else
                            {                             
                                inspectionObservation.ID = 0;
                                inspectionObservation.PipeReportID = tempObj.ID;
                                inspectionObservation.CreatedDate = DateTime.Now;
                                inspectionObservation.CreatedBy = "SYSADMIN";
                                _unitOfWork.InspectionObservation.Create(inspectionObservation);
                            }
                        }

                        

                        foreach (InspectionRecommendationDTO inspectionRecommendationDTO in PipeReportRequestDTO.InspectionRecommendationList)
                        {
                            InspectionRecommendation inspectionRecommendation = _mapper.Map<InspectionRecommendation>(inspectionRecommendationDTO);
                            if (inspectionRecommendation.ID > 0)
                            {
                                inspectionRecommendation.ModifiedBy = "SYSADMIN";
                                inspectionRecommendation.ModifiedDate = DateTime.Now;
                                _unitOfWork.InspectionRecommendation.Update(inspectionRecommendation);
                            }
                            else
                            {
                                inspectionRecommendation.ID = 0;
                                inspectionRecommendation.PipeReportID = tempObj.ID;
                                inspectionRecommendation.CreatedDate = DateTime.Now;
                                inspectionRecommendation.CreatedBy = "SYSADMIN";
                                _unitOfWork.InspectionRecommendation.Create(inspectionRecommendation);
                            }                           
                        }

                        //foreach (InspectionDistributionDTO inspectionDistributionDTO in PipeReportRequestDTO.InspectionDistributionList)
                        //{
                        //    InspectionDistribution inspectionDistribution = _mapper.Map<InspectionDistribution>(inspectionDistributionDTO);
                        //    if (inspectionDistribution.ID > 0)
                        //    {
                        //        inspectionDistribution.ModifiedDate = DateTime.Now;
                        //        _unitOfWork.InspectionDistribution.Create(inspectionDistribution);
                        //    }
                        //    else
                        //    {
                        //        inspectionDistribution.PipeReportID = pipeReport.ID;
                        //        inspectionDistribution.CreatedDate = DateTime.Now;
                        //        _unitOfWork.InspectionDistribution.Create(inspectionDistribution);
                        //    }
                        //}

                        //foreach (InspectionProgramDTO inspectionProgramDTO in PipeReportRequestDTO.InspectionProgramList)
                        //{
                        //    InspectionProgram inspectionProgram = _mapper.Map<InspectionProgram>(inspectionProgramDTO);
                        //    if (inspectionProgram.ID > 0)
                        //    {
                        //        inspectionProgram.ModifiedBy = "SYSADMIN";
                        //        inspectionProgram.ModifiedDate = DateTime.Now;
                        //        _unitOfWork.InspectionProgram.Create(inspectionProgram);
                        //    }
                        //    else
                        //    {
                        //        inspectionProgram.PipeReportID = pipeReport.ID;
                        //        inspectionProgram.CreatedDate = DateTime.Now;
                        //        _unitOfWork.InspectionProgram.Create(inspectionProgram);
                        //    }
                        //}

                        foreach (TMLDTO tmlDTO in PipeReportRequestDTO.TMLList)
                        {
                            TML tml = _mapper.Map<TML>(tmlDTO);
                            if (tml.ID > 0)
                            {
                                tml.ModifiedBy = "SYSADMIN";
                                tml.ModifiedDate = DateTime.Now;
                                _unitOfWork.TML.Update(tml);
                            }
                            else
                            {
                                tml.ID = 0;
                                tml.PipeReportID = tempObj.ID;
                                tml.CreatedDate = DateTime.Now;
                                tml.CreatedBy = "SYSADMIN";                               
                                _unitOfWork.TML.Create(tml);
                            }
                        }                       

                        _unitOfWork.SaveChanges();
                        transaction.Commit();
                        return new PipeReportResponseDTO
                        {
                            Status = true,
                            StatusMessage = "Successfully created",
                            StatusCode = 200
                        };
                    }
                    else
                    {
                        return new PipeReportResponseDTO
                        {
                            Status = false,
                            StatusMessage = "Error - Duplicate Report - " + tempObj.ReportNo,
                            StatusCode = 200
                        };
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return new PipeReportResponseDTO()
                    {
                        Status = false,
                        StatusMessage = ex.Message,
                        StatusCode = 200
                    };
                }
            }
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.PipeReport.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.PipeReport.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }     

        public string GenerateReportNo(string year)
        {
            string reportNo = "00001/" + year;

            int count = (from s in _unitOfWork.PipeReport.FindAll()
                         where s.InspectionYear == Convert.ToInt32(year)
                         select s.ID).Count();

            if (count > 0)
            {
                int nextSlno = (from s in _unitOfWork.PipeReport.FindAll()
                                where s.ReportNo.Substring(6, 4) == year
                                select Convert.ToInt32(s.ReportNo.Substring(0, 5))
                 ).Max();

                reportNo = string.Format("{0}/{1}", Convert.ToString(nextSlno + 1).PadLeft(5, '0'), year);
            }
            return reportNo;
        }
    }
}
