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
using Microsoft.EntityFrameworkCore;

namespace Piping.Services
{
    public class PipeMasterService : IPipeMasterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public PipeMasterService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;          
            _mapper = mapper;
            _context = context;
        }

        public List<PipeMasterDTO> GetAll()
        {
            var response = _unitOfWork.PipeMaster.FindAll();
            var result = _mapper.Map<List<PipeMasterDTO>>(response);
            return result;
        }

        public PipeMasterDTO GetByID(int ID)
        {
            PipeMaster pipe = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.ID == ID) select p).FirstOrDefault();
            PipeMasterDTO pipeline = _mapper.Map<PipeMasterDTO>(pipe);
            return pipeline;
        }

        public PipeMasterDTO GetByEquipmentNo(string EquipmentNo)
        {
            PipeMaster pipe = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.EquipmentNo == EquipmentNo) select p).FirstOrDefault();
            
            PipeMasterDTO pipeline = _mapper.Map<PipeMasterDTO>(pipe);
            return pipeline;
        }

        public PipelineBasicDTO GetBasicData(int ID)
        {
            PipelineBasicDTO pipelineBasicDTO = new PipelineBasicDTO();

            pipelineBasicDTO = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.ID == ID)
                                select new PipelineBasicDTO
                                {
                                    ID = p.ID,
                                    EquipmentNo = p.EquipmentNo,
                                    Description = p.Description,
                                    FromTo = p.FromTo,
                                    PlantCode = p.PlantCode,
                                    Train = p.Train,
                                    PandIDNo = p.PandIDNo,
                                    AreaCode = p.AreaCode,
                                    Fluid = p.Fluid,
                                    FluidCode = p.FluidCode,
                                    FluidName = p.FluidName,
                                    SubFluid = p.SubFluid,
                                    YearInService = p.YearInService,
                                    NextInspectionDate = p.NextInspectionDate,
                                    NextFollowDate = p.NextFollowDate,
                                    OverallStatus = (p.OverallStatus == "RP" ? "Risk calculation pending" : p.OverallStatus) ,
                                    PipeClusterNo = p.PipeClusterNo,
                                    CorrosionLoopNo = p.CorrosionLoopNo
                                }
                                ).FirstOrDefault();

            return pipelineBasicDTO;
        }
        public PipelineDesignDTO GetDesignData(int ID)
        {
            PipelineDesignDTO pipelineDesignDTO = new PipelineDesignDTO();

            pipelineDesignDTO = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.ID == ID)
                                 select new PipelineDesignDTO
                                 {
                                     ID = p.ID,
                                     DesignTemperature = p.DesignTemperature,
                                     DesignPressure = p.DesignPressure,
                                     OperatingTemperature = p.OperatingTemperature,
                                     OperatingPressure = p.OperatingPressure,
                                     PWHT = p.PWHT,
                                     MaterialCode = p.MaterialCode,
                                     MaterialStd = p.MaterialStd,
                                     MaterialGrade = p.MaterialGrade,
                                     PipeSpec = p.PipeSpec,
                                     NominalDiameter = p.NominalDiameter,
                                     NominalThick = p.NominalThick,
                                     Length = p.Length,
                                     JointEfficiency = p.JointEfficiency,
                                     Insulated = p.Insulated,
                                     InsulationType = p.InsulationType,
                                     CorrosionAllowance = p.CorrosionAllowance,
                                     MDMT = p.MDMT,
                                     ConstructionCode = p.ConstructionCode,
                                     UseLastMeasuredThick_ULMT = p.UseLastMeasuredThick_ULMT,
                                     MinReqThkOption_MRTO = p.MinReqThkOption_MRTO,
                                     AllowableStressMPA_S = p.AllowableStressMPA_S,
                                     YieldStrengthMPA_YS = p.YieldStrengthMPA_YS,
                                     TensileStrengthMPA_TS = p.TensileStrengthMPA_TS,
                                     FlowStress_FS = p.FlowStress_FS,
                                     StengthRatio_SR = p.StengthRatio_SR,
                                     LastMeasuredThick_LMT = p.LastMeasuredThick_LMT,
                                     LastMeasuredYear_LMY = p.LastMeasuredYear_LMY,
                                     PrMinReqThkInternal_PMTI = p.PrMinReqThkInternal_PMTI,
                                     PrMinReqThkExternal_PMTE = p.PrMinReqThkExternal_PMTE,
                                     UserCalPrMinReqThk_UMT = p.UserCalPrMinReqThk_UMT,
                                     StructuralMinThk_SMT = p.StructuralMinThk_SMT,
                                     EffectiveMinReqThk_EMRT = p.EffectiveMinReqThk_EMRT,
                                     EffectiveThk_ETHK = p.EffectiveThk_ETHK
                                 }
                                ).FirstOrDefault();

            return pipelineDesignDTO;
        }
        public void Create(PipeMasterDTO pipelineDTO)
        {
            PipeMaster obj = _mapper.Map<PipeMaster>(pipelineDTO);

            _unitOfWork.PipeMaster.Create(obj);
            _unitOfWork.SaveChanges();
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.PipeMaster.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.PipeMaster.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public void UpdateBasicData(PipelineBasicDTO pipelineBasicDTO)
        {
            int ID = pipelineBasicDTO.ID;
            PipeMaster pipeline = _unitOfWork.PipeMaster.FindById(ID);
            if (pipeline != null)
            {
                pipeline.EquipmentNo = pipelineBasicDTO.EquipmentNo;
                pipeline.Description = pipelineBasicDTO.Description;
                pipeline.FromTo = pipelineBasicDTO.FromTo;
                pipeline.PlantCode = pipelineBasicDTO.PlantCode;
                pipeline.Train = pipelineBasicDTO.Train;
                pipeline.PandIDNo = pipelineBasicDTO.PandIDNo;
                pipeline.AreaCode = pipelineBasicDTO.AreaCode;
                pipeline.Fluid = pipelineBasicDTO.Fluid;
                pipeline.YearInService = pipelineBasicDTO.YearInService;
                pipeline.FluidCode = pipelineBasicDTO.FluidCode;
                pipeline.FluidName = pipelineBasicDTO.FluidName;
                pipeline.SubFluid = pipelineBasicDTO.SubFluid;
                //pipeline.NextInspectionDate = pipelineBasicDTO.NextInspectionDate;
                //pipeline.NextFollowDate = pipelineBasicDTO.NextFollowDate;
                //  pipeline.OverallStatus = pipelineBasicDTO.OverallStatus;
                pipeline.PipeClusterNo = pipelineBasicDTO.PipeClusterNo;
                pipeline.CorrosionLoopNo = pipelineBasicDTO.CorrosionLoopNo;
                pipeline.ModifiedBy = pipelineBasicDTO.ModifiedBy;
                pipeline.ModifiedDate = DateTime.Now;
            }
            _unitOfWork.PipeMaster.Update(pipeline);
            _unitOfWork.SaveChanges();
        }

        public void UpdateDesignData(PipelineDesignDTO pipelineDesignDTO)
        {
            int ID = pipelineDesignDTO.ID;
            PipeMaster pipeline = _unitOfWork.PipeMaster.FindById(ID);
            if (pipeline != null)
            {
                CalculateDesignData(pipelineDesignDTO);
                pipeline.DesignTemperature = pipelineDesignDTO.DesignTemperature;
                pipeline.DesignPressure = pipelineDesignDTO.DesignPressure;
                pipeline.OperatingTemperature = pipelineDesignDTO.OperatingTemperature;
                pipeline.OperatingPressure = pipelineDesignDTO.OperatingPressure;
                pipeline.PWHT = pipelineDesignDTO.PWHT;
                pipeline.MaterialCode = pipelineDesignDTO.MaterialCode;
                pipeline.MaterialStd = pipelineDesignDTO.MaterialStd;
                pipeline.MaterialGrade = pipelineDesignDTO.MaterialGrade;
                pipeline.PipeSpec = pipelineDesignDTO.PipeSpec;
                pipeline.NominalDiameter = pipelineDesignDTO.NominalDiameter;
                pipeline.NominalThick = pipelineDesignDTO.NominalThick;
                pipeline.Length = pipelineDesignDTO.Length;
                pipeline.JointEfficiency = pipelineDesignDTO.JointEfficiency;
                pipeline.Insulated = pipelineDesignDTO.Insulated;
                pipeline.InsulationType = pipelineDesignDTO.InsulationType;
                pipeline.CorrosionAllowance = pipelineDesignDTO.CorrosionAllowance;
                pipeline.MDMT = pipelineDesignDTO.MDMT;
                pipeline.ConstructionCode = pipelineDesignDTO.ConstructionCode;
                pipeline.UseLastMeasuredThick_ULMT = pipelineDesignDTO.UseLastMeasuredThick_ULMT;
                pipeline.MinReqThkOption_MRTO = pipelineDesignDTO.MinReqThkOption_MRTO;
                pipeline.AllowableStressMPA_S = pipelineDesignDTO.AllowableStressMPA_S;
                pipeline.YieldStrengthMPA_YS = pipelineDesignDTO.YieldStrengthMPA_YS;
                pipeline.TensileStrengthMPA_TS = pipelineDesignDTO.TensileStrengthMPA_TS;
                pipeline.FlowStress_FS = pipelineDesignDTO.FlowStress_FS;
                pipeline.StengthRatio_SR = pipelineDesignDTO.StengthRatio_SR;
                pipeline.LastMeasuredThick_LMT = pipelineDesignDTO.LastMeasuredThick_LMT;
                pipeline.LastMeasuredYear_LMY = pipelineDesignDTO.LastMeasuredYear_LMY;
                pipeline.PrMinReqThkInternal_PMTI = pipelineDesignDTO.PrMinReqThkInternal_PMTI;
                pipeline.PrMinReqThkExternal_PMTE = pipelineDesignDTO.PrMinReqThkExternal_PMTE;
                pipeline.UserCalPrMinReqThk_UMT = pipelineDesignDTO.UserCalPrMinReqThk_UMT;
                pipeline.StructuralMinThk_SMT = pipelineDesignDTO.StructuralMinThk_SMT;
                pipeline.EffectiveMinReqThk_EMRT = pipelineDesignDTO.EffectiveMinReqThk_EMRT;
                pipeline.EffectiveThk_ETHK = pipelineDesignDTO.EffectiveThk_ETHK;
                pipeline.ModifiedBy = pipelineDesignDTO.ModifiedBy;
                pipeline.ModifiedDate = DateTime.Now;
                _unitOfWork.PipeMaster.Update(pipeline);
                _unitOfWork.SaveChanges();
            }
        }

        public void CalculateDesignBulkData()
        {
            List<PipeMaster> pipeMasterList = (from p in _unitOfWork.PipeMaster.FindAll() select p).ToList<PipeMaster>();

            foreach (PipeMaster designData in pipeMasterList)
            {
                CalculatePipeMasterDesignData(designData);

                _unitOfWork.PipeMaster.Update(designData);
                _unitOfWork.SaveChanges();
            }
        }

        private void CalculateDesignData(PipelineDesignDTO pipelineDesignDTO)
        {
            // Material Master
            if (!pipelineDesignDTO.AllowableStressMPA_S.HasValue)
            {
                if (pipelineDesignDTO.DesignTemperature.Value <= 40.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
                p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_40).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 40.0M && pipelineDesignDTO.DesignTemperature.Value <= 65.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_41_UPTO_65).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 65.0M && pipelineDesignDTO.DesignTemperature.Value <= 100.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_66_UPTO_100).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 100.0M && pipelineDesignDTO.DesignTemperature.Value <= 125.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_101_UPTO_125).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 125.0M && pipelineDesignDTO.DesignTemperature.Value <= 150.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_126_UPTO_150).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 150.0M && pipelineDesignDTO.DesignTemperature.Value <= 175.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_151_UPTO_175).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 175.0M && pipelineDesignDTO.DesignTemperature.Value <= 200.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_176_UPTO_200).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 200.0M && pipelineDesignDTO.DesignTemperature.Value <= 225.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_201_UPTO_225).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 225.0M && pipelineDesignDTO.DesignTemperature.Value <= 250.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_226_UPTO_250).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 250.0M && pipelineDesignDTO.DesignTemperature.Value <= 275.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_251_UPTO_275).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 275.0M && pipelineDesignDTO.DesignTemperature.Value <= 300.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_276_UPTO_300).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 300.0M && pipelineDesignDTO.DesignTemperature.Value <= 325.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_301_UPTO_325).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 325.0M && pipelineDesignDTO.DesignTemperature.Value <= 350.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_326_UPTO_350).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 350.0M && pipelineDesignDTO.DesignTemperature.Value <= 375.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_351_UPTO_375).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 375.0M && pipelineDesignDTO.DesignTemperature.Value <= 400.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_376_UPTO_400).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 400.0M && pipelineDesignDTO.DesignTemperature.Value <= 425.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_401_UPTO_425).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 425.0M && pipelineDesignDTO.DesignTemperature.Value <= 450.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_426_UPTO_450).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 450.0M && pipelineDesignDTO.DesignTemperature.Value <= 475.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_451_UPTO_475).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 475.0M && pipelineDesignDTO.DesignTemperature.Value <= 500.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_476_UPTO_500).FirstOrDefault());

                else if (pipelineDesignDTO.DesignTemperature.Value > 500.0M && pipelineDesignDTO.DesignTemperature.Value <= 525.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_501_UPTO_525).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 525.0M && pipelineDesignDTO.DesignTemperature.Value <= 550.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_526_UPTO_550).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 550.0M && pipelineDesignDTO.DesignTemperature.Value <= 575.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_551_UPTO_575).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 575.0M && pipelineDesignDTO.DesignTemperature.Value <= 600.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_576_UPTO_600).FirstOrDefault());

                else if (pipelineDesignDTO.DesignTemperature.Value > 600.0M && pipelineDesignDTO.DesignTemperature.Value <= 625.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_601_UPTO_625).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 625.0M && pipelineDesignDTO.DesignTemperature.Value <= 650.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_626_UPTO_650).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 650.0M && pipelineDesignDTO.DesignTemperature.Value <= 675.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_651_UPTO_675).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 675.0M && pipelineDesignDTO.DesignTemperature.Value <= 700.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_676_UPTO_700).FirstOrDefault());


                else if (pipelineDesignDTO.DesignTemperature.Value > 700.0M && pipelineDesignDTO.DesignTemperature.Value <= 725.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_701_UPTO_725).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 725.0M && pipelineDesignDTO.DesignTemperature.Value <= 750.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_726_UPTO_750).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 750.0M && pipelineDesignDTO.DesignTemperature.Value <= 775.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_751_UPTO_775).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 775.0M && pipelineDesignDTO.DesignTemperature.Value <= 800.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_776_UPTO_800).FirstOrDefault());

                else if (pipelineDesignDTO.DesignTemperature.Value > 800.0M && pipelineDesignDTO.DesignTemperature.Value <= 825.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_801_UPTO_825).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 825.0M && pipelineDesignDTO.DesignTemperature.Value <= 850.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_826_UPTO_850).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 850.0M && pipelineDesignDTO.DesignTemperature.Value <= 875.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_851_UPTO_875).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 875.0M && pipelineDesignDTO.DesignTemperature.Value <= 900.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_876_UPTO_900).FirstOrDefault());

                else if (pipelineDesignDTO.DesignTemperature.Value > 900.0M && pipelineDesignDTO.DesignTemperature.Value <= 925.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_901_UPTO_925).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 925.0M && pipelineDesignDTO.DesignTemperature.Value <= 950.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_926_UPTO_950).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 950.0M && pipelineDesignDTO.DesignTemperature.Value <= 975.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_951_UPTO_975).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 975.0M && pipelineDesignDTO.DesignTemperature.Value <= 1000.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_976_UPTO_1000).FirstOrDefault());

                else if (pipelineDesignDTO.DesignTemperature.Value > 1000.0M && pipelineDesignDTO.DesignTemperature.Value <= 1025.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_1001_UPTO_1025).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 1025.0M && pipelineDesignDTO.DesignTemperature.Value <= 1050.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_1026_UPTO_1050).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 1050.0M && pipelineDesignDTO.DesignTemperature.Value <= 1075.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_1051_UPTO_1075).FirstOrDefault());
                else if (pipelineDesignDTO.DesignTemperature.Value > 1075.0M && pipelineDesignDTO.DesignTemperature.Value <= 1100.0M)
                    pipelineDesignDTO.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
               p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.DTEMP_UPTO_1076_UPTO_1100).FirstOrDefault());

                pipelineDesignDTO.AllowableStressMPA_S = Math.Round(pipelineDesignDTO.AllowableStressMPA_S.Value * 1000, 0);

                pipelineDesignDTO.YieldStrengthMPA_YS = Math.Round(Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
                p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.YIELD_STRENGTH_MPA).FirstOrDefault()), 0);

                pipelineDesignDTO.TensileStrengthMPA_TS = Math.Round(Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipelineDesignDTO.MaterialStd &&
                p.TYPE_GRADE == pipelineDesignDTO.MaterialGrade).Select(p => p.TENSILE_STRENGTH_MPA).FirstOrDefault()), 0);
            }

            
            pipelineDesignDTO.StructuralMinThk_SMT = _unitOfWork.StructuralMinThk.GenerateEntityAsIQueryable().Where(p => p.OutsideDiameterMM >= pipelineDesignDTO.NominalDiameter).Select(p => p.StructureWallThicknessMM).FirstOrDefault();

            // ( ( YS + TS ) / 2 ) * 1.1 * E
            pipelineDesignDTO.FlowStress_FS = Math.Round(((pipelineDesignDTO.YieldStrengthMPA_YS.Value + pipelineDesignDTO.TensileStrengthMPA_TS.Value) / 2M) * 1.1M * pipelineDesignDTO.JointEfficiency,5);
                                  
            //( P * D ) / 2 (( S * E ) - 0.6 P )
            pipelineDesignDTO.PrMinReqThkInternal_PMTI = Math.Round((pipelineDesignDTO.DesignPressure.Value * pipelineDesignDTO.NominalDiameter.Value) / (2M * ((pipelineDesignDTO.AllowableStressMPA_S.Value * pipelineDesignDTO.JointEfficiency) - (0.6M * pipelineDesignDTO.DesignPressure.Value))), 5); 

            switch (pipelineDesignDTO.MinReqThkOption_MRTO)
            {
                case "Pr Min Thk":
                    if (pipelineDesignDTO.UserCalPrMinReqThk_UMT.HasValue)
                        pipelineDesignDTO.EffectiveMinReqThk_EMRT = pipelineDesignDTO.UserCalPrMinReqThk_UMT;
                    else if (!pipelineDesignDTO.UserCalPrMinReqThk_UMT.HasValue && pipelineDesignDTO.PrMinReqThkInternal_PMTI.HasValue)
                        pipelineDesignDTO.EffectiveMinReqThk_EMRT = pipelineDesignDTO.PrMinReqThkInternal_PMTI;
                    else
                        pipelineDesignDTO.EffectiveMinReqThk_EMRT = 0.00M;
                    break;
                case "Nom Thk - CA":
                    if (pipelineDesignDTO.CorrosionAllowance <= 0)
                        pipelineDesignDTO.EffectiveMinReqThk_EMRT = pipelineDesignDTO.NominalThick * 0.9M;
                    else if (pipelineDesignDTO.CorrosionAllowance > 0)
                        pipelineDesignDTO.EffectiveMinReqThk_EMRT = pipelineDesignDTO.NominalThick - pipelineDesignDTO.CorrosionAllowance;
                    break;
                default:
                    pipelineDesignDTO.EffectiveMinReqThk_EMRT = 0.00M;
                    break;
            }

            if (pipelineDesignDTO.LastMeasuredYear_LMY.HasValue)
                pipelineDesignDTO.EffectiveThk_ETHK = pipelineDesignDTO.LastMeasuredThick_LMT;
            else
                pipelineDesignDTO.EffectiveThk_ETHK = pipelineDesignDTO.NominalThick;

            // ( S * E * EMRT ) / ( FS * ETHK )
            pipelineDesignDTO.StengthRatio_SR = Math.Round(((pipelineDesignDTO.AllowableStressMPA_S.Value / 1000) * pipelineDesignDTO.JointEfficiency * pipelineDesignDTO.EffectiveMinReqThk_EMRT.Value) / (pipelineDesignDTO.FlowStress_FS.Value * pipelineDesignDTO.EffectiveThk_ETHK.Value), 5);
        }

        private void CalculatePipeMasterDesignData(PipeMaster pipeMaster)
        {
            // Material Master
            if (pipeMaster.DesignTemperature.Value <= 40.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
            p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_40).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 40.0M && pipeMaster.DesignTemperature.Value <= 65.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_41_UPTO_65).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 65.0M && pipeMaster.DesignTemperature.Value <= 100.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_66_UPTO_100).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 100.0M && pipeMaster.DesignTemperature.Value <= 125.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_101_UPTO_125).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 125.0M && pipeMaster.DesignTemperature.Value <= 150.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_126_UPTO_150).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 150.0M && pipeMaster.DesignTemperature.Value <= 175.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_151_UPTO_175).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 175.0M && pipeMaster.DesignTemperature.Value <= 200.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_176_UPTO_200).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 200.0M && pipeMaster.DesignTemperature.Value <= 225.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_201_UPTO_225).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 225.0M && pipeMaster.DesignTemperature.Value <= 250.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_226_UPTO_250).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 250.0M && pipeMaster.DesignTemperature.Value <= 275.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_251_UPTO_275).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 275.0M && pipeMaster.DesignTemperature.Value <= 300.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_276_UPTO_300).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 300.0M && pipeMaster.DesignTemperature.Value <= 325.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_301_UPTO_325).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 325.0M && pipeMaster.DesignTemperature.Value <= 350.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_326_UPTO_350).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 350.0M && pipeMaster.DesignTemperature.Value <= 375.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_351_UPTO_375).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 375.0M && pipeMaster.DesignTemperature.Value <= 400.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_376_UPTO_400).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 400.0M && pipeMaster.DesignTemperature.Value <= 425.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_401_UPTO_425).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 425.0M && pipeMaster.DesignTemperature.Value <= 450.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_426_UPTO_450).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 450.0M && pipeMaster.DesignTemperature.Value <= 475.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_451_UPTO_475).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 475.0M && pipeMaster.DesignTemperature.Value <= 500.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_476_UPTO_500).FirstOrDefault());

            else if (pipeMaster.DesignTemperature.Value > 500.0M && pipeMaster.DesignTemperature.Value <= 525.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_501_UPTO_525).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 525.0M && pipeMaster.DesignTemperature.Value <= 550.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_526_UPTO_550).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 550.0M && pipeMaster.DesignTemperature.Value <= 575.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_551_UPTO_575).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 575.0M && pipeMaster.DesignTemperature.Value <= 600.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_576_UPTO_600).FirstOrDefault());

            else if (pipeMaster.DesignTemperature.Value > 600.0M && pipeMaster.DesignTemperature.Value <= 625.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_601_UPTO_625).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 625.0M && pipeMaster.DesignTemperature.Value <= 650.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_626_UPTO_650).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 650.0M && pipeMaster.DesignTemperature.Value <= 675.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_651_UPTO_675).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 675.0M && pipeMaster.DesignTemperature.Value <= 700.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_676_UPTO_700).FirstOrDefault());


            else if (pipeMaster.DesignTemperature.Value > 700.0M && pipeMaster.DesignTemperature.Value <= 725.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_701_UPTO_725).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 725.0M && pipeMaster.DesignTemperature.Value <= 750.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_726_UPTO_750).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 750.0M && pipeMaster.DesignTemperature.Value <= 775.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_751_UPTO_775).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 775.0M && pipeMaster.DesignTemperature.Value <= 800.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_776_UPTO_800).FirstOrDefault());

            else if (pipeMaster.DesignTemperature.Value > 800.0M && pipeMaster.DesignTemperature.Value <= 825.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_801_UPTO_825).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 825.0M && pipeMaster.DesignTemperature.Value <= 850.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_826_UPTO_850).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 850.0M && pipeMaster.DesignTemperature.Value <= 875.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_851_UPTO_875).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 875.0M && pipeMaster.DesignTemperature.Value <= 900.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_876_UPTO_900).FirstOrDefault());

            else if (pipeMaster.DesignTemperature.Value > 900.0M && pipeMaster.DesignTemperature.Value <= 925.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_901_UPTO_925).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 925.0M && pipeMaster.DesignTemperature.Value <= 950.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_926_UPTO_950).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 950.0M && pipeMaster.DesignTemperature.Value <= 975.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_951_UPTO_975).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 975.0M && pipeMaster.DesignTemperature.Value <= 1000.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_976_UPTO_1000).FirstOrDefault());

            else if (pipeMaster.DesignTemperature.Value > 1000.0M && pipeMaster.DesignTemperature.Value <= 1025.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_1001_UPTO_1025).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 1025.0M && pipeMaster.DesignTemperature.Value <= 1050.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_1026_UPTO_1050).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 1050.0M && pipeMaster.DesignTemperature.Value <= 1075.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_1051_UPTO_1075).FirstOrDefault());
            else if (pipeMaster.DesignTemperature.Value > 1075.0M && pipeMaster.DesignTemperature.Value <= 1100.0M)
                pipeMaster.AllowableStressMPA_S = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
           p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.DTEMP_UPTO_1076_UPTO_1100).FirstOrDefault());

            pipeMaster.YieldStrengthMPA_YS = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
            p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.YIELD_STRENGTH_MPA).FirstOrDefault());

            pipeMaster.TensileStrengthMPA_TS = Convert.ToDecimal(_unitOfWork.MaterialMaster.GenerateEntityAsIQueryable().Where(p => p.SPEC_NO == pipeMaster.MaterialStd &&
            p.TYPE_GRADE == pipeMaster.MaterialGrade).Select(p => p.TENSILE_STRENGTH_MPA).FirstOrDefault());

            pipeMaster.StructuralMinThk_SMT = _unitOfWork.StructuralMinThk.GenerateEntityAsIQueryable().Where(p => p.OutsideDiameterInches == pipeMaster.NominalDiameter).Select(p => p.StructureWallThicknessMM).FirstOrDefault();

            // ( ( YS + TS ) / 2 ) * 1.1 * E
            pipeMaster.FlowStress_FS = ((pipeMaster.YieldStrengthMPA_YS + pipeMaster.TensileStrengthMPA_TS) / 2M) * 1.1M * pipeMaster.JointEfficiency;

            //( P * D / 2 ( S * E - 0.6 P )
            pipeMaster.PrMinReqThkInternal_PMTI = (pipeMaster.DesignPressure * pipeMaster.NominalDiameter / 2M * (pipeMaster.AllowableStressMPA_S * pipeMaster.JointEfficiency - (0.6M * pipeMaster.DesignPressure)));

            switch (pipeMaster.MinReqThkOption_MRTO)
            {
                case "Pr Min Thk":
                    if (pipeMaster.UserCalPrMinReqThk_UMT.HasValue)
                        pipeMaster.EffectiveMinReqThk_EMRT = pipeMaster.UserCalPrMinReqThk_UMT;
                    else if (!pipeMaster.UserCalPrMinReqThk_UMT.HasValue && pipeMaster.PrMinReqThkInternal_PMTI.HasValue)
                        pipeMaster.EffectiveMinReqThk_EMRT = pipeMaster.PrMinReqThkInternal_PMTI;
                    else
                        pipeMaster.EffectiveMinReqThk_EMRT = 0.00M;
                    break;
                case "Nom Thk - CA":
                    if (pipeMaster.CorrosionAllowance <= 0)
                        pipeMaster.EffectiveMinReqThk_EMRT = pipeMaster.NominalThick * 0.9M;
                    else if (pipeMaster.CorrosionAllowance > 0)
                        pipeMaster.EffectiveMinReqThk_EMRT = pipeMaster.NominalThick - pipeMaster.CorrosionAllowance;
                    break;
                default:
                    pipeMaster.EffectiveMinReqThk_EMRT = 0.00M;
                    break;
            }

            if (pipeMaster.LastMeasuredYear_LMY.HasValue)
                pipeMaster.EffectiveThk_ETHK = pipeMaster.LastMeasuredThick_LMT;
            else
                pipeMaster.EffectiveThk_ETHK = pipeMaster.NominalThick;

            // ( S * E * EMRT ) / ( FS * ETHK )
            pipeMaster.StengthRatio_SR = (pipeMaster.AllowableStressMPA_S * pipeMaster.JointEfficiency * pipeMaster.EffectiveMinReqThk_EMRT) / (pipeMaster.FlowStress_FS * pipeMaster.EffectiveThk_ETHK);
                
        }

        public int BulkInsert(string jsonPipeMasterList)
        {
            int affectedRows = 0;
            try
            {
                var param1 = new Npgsql.NpgsqlParameter("json_pipemaster", NpgsqlTypes.NpgsqlDbType.Json);
                param1.Value = jsonPipeMasterList;

                var parameters = new[] {
                param1
            };
                affectedRows = _context.Database.ExecuteSqlRaw("call USP_bulk_insert_pipe_master(@json_pipemaster);", parameters);

                return affectedRows;
            }
            catch(Exception ex)
            {
                return affectedRows;
            }
        }

        public PipeMasterCOFDTO GetCOFData(int ID)
        {
            PipeMasterCOFDTO pipeMasterCOFDTO = new PipeMasterCOFDTO();
            PipeMasterCOF cof = (from p in _unitOfWork.PipeMasterCOF.FindAll().Where(p => p.PipeMasterID == ID)
                                select p).FirstOrDefault();
            pipeMasterCOFDTO = _mapper.Map<PipeMasterCOFDTO>(cof);
            return pipeMasterCOFDTO;
        }

    }
}
