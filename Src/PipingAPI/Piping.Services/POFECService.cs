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
    public class POFECService : IPOFECService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;

        public POFECService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }
        public List<POFECDTO> GetAll()
        {
            return (from p in _unitOfWork.POFEC.FindAll()
                    select new POFECDTO
                    {
                        ID = p.ID,
                        PipeMasterID = p.PipeMasterID,
                        EquipmentNo = p.EquipmentNo,                        
                        TheoriticalCR = p.TheoriticalCR,
                        EffectiveCR = p.EffectiveCR,
                        EffectiveAge = p.EffectiveAge,
                        MeasuredLCR = p.MeasuredLCR,
                        MeasuredSCR = p.MeasuredSCR,
                        UseMeasuredLCR = p.UseMeasuredLCR,
                        UseMeasuredSCR = p.UseMeasuredSCR,
                        VeryHigh = p.VeryHigh,
                        High = p.High,
                        Medium = p.Medium,
                        Low = p.Low,
                        Found = p.Found,
                        DamageFactor = p.DamageFactor,
                        POF = p.POF,
                        Art = p.Art,
                        FlowStress = p.FlowStress,
                        StrengthRatio = p.StrengthRatio,
                        LastMeasuredYear = p.LastMeasuredYear,                        
                        SoilInterfaceCondensation = p.SoilInterfaceCondensation,
                        PipeDirectBeamComplexDesign = p.PipeDirectBeamComplexDesign,
                        RepaintedYear = p.RepaintedYear,
                        Driver = p.Driver,
                        CoatingQuality = p.CoatingQuality,
                        CoatingAge = p.CoatingAge,
                        CoatAdjustment = p.CoatAdjustment,
                        CorrosionType = p.CorrosionType,
                        ExternalProcess = p.ExternalProcess,
                        LineAge = p.LineAge,
                        Suceptability = p.Suceptability,
                        AdjustedSuceptability = p.AdjustedSuceptability,
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy
                    })
                .ToList();
        }
        public POFECDTO GetByID(int ID)
        {
            return (from p in _unitOfWork.POFEC.FindAll().Where(p => p.ID == ID)
                    select new POFECDTO
                    {
                        ID = p.ID,
                        PipeMasterID = p.PipeMasterID,
                        EquipmentNo = p.EquipmentNo,
                        TheoriticalCR = p.TheoriticalCR,
                        EffectiveCR = p.EffectiveCR,
                        EffectiveAge = p.EffectiveAge,
                        MeasuredLCR = p.MeasuredLCR,
                        MeasuredSCR = p.MeasuredSCR,
                        UseMeasuredLCR = p.UseMeasuredLCR,
                        UseMeasuredSCR = p.UseMeasuredSCR,
                        VeryHigh = p.VeryHigh,
                        High = p.High,
                        Medium = p.Medium,
                        Low = p.Low,
                        Found = p.Found,
                        DamageFactor = p.DamageFactor,
                        POF = p.POF,
                        Art = p.Art,
                        FlowStress = p.FlowStress,
                        StrengthRatio = p.StrengthRatio,
                        LastMeasuredYear = p.LastMeasuredYear,
                        SoilInterfaceCondensation = p.SoilInterfaceCondensation,
                        PipeDirectBeamComplexDesign = p.PipeDirectBeamComplexDesign,
                        RepaintedYear = p.RepaintedYear,
                        Driver = p.Driver,
                        CoatingQuality = p.CoatingQuality,
                        CoatingAge = p.CoatingAge,
                        CoatAdjustment = p.CoatAdjustment,
                        CorrosionType = p.CorrosionType,
                        ExternalProcess = p.ExternalProcess,
                        LineAge = p.LineAge,
                        Suceptability = p.Suceptability,
                        AdjustedSuceptability = p.AdjustedSuceptability,
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy
                    })
                .FirstOrDefault();
        }
        public POFECDTO GetByEquipmentNo(string EquipmentNo)
        {
            return (from p in _unitOfWork.POFEC.GenerateEntityAsIQueryable().Where(p => p.EquipmentNo == EquipmentNo).OrderByDescending(p => p.CreatedDate)
                    select new POFECDTO
                    {
                        ID = p.ID,
                        PipeMasterID = p.PipeMasterID,
                        EquipmentNo = p.EquipmentNo,
                        TheoriticalCR = p.TheoriticalCR,
                        EffectiveCR = p.EffectiveCR,
                        EffectiveAge = p.EffectiveAge,
                        MeasuredLCR = p.MeasuredLCR,
                        MeasuredSCR = p.MeasuredSCR,
                        UseMeasuredLCR = p.UseMeasuredLCR,
                        UseMeasuredSCR = p.UseMeasuredSCR,
                        VeryHigh = p.VeryHigh,
                        High = p.High,
                        Medium = p.Medium,
                        Low = p.Low,
                        Found = p.Found,
                        DamageFactor = p.DamageFactor,
                        POF = p.POF,
                        Art = p.Art,
                        FlowStress = p.FlowStress,
                        StrengthRatio = p.StrengthRatio,
                        LastMeasuredYear = p.LastMeasuredYear,
                        SoilInterfaceCondensation = p.SoilInterfaceCondensation,
                        PipeDirectBeamComplexDesign = p.PipeDirectBeamComplexDesign,
                        RepaintedYear = p.RepaintedYear,
                        Driver = p.Driver,
                        CoatingQuality = p.CoatingQuality,
                        CoatingAge = p.CoatingAge,
                        CoatAdjustment = p.CoatAdjustment,
                        CorrosionType = p.CorrosionType,
                        ExternalProcess = p.ExternalProcess,
                        LineAge = p.LineAge,
                        Suceptability = p.Suceptability,
                        AdjustedSuceptability = p.AdjustedSuceptability,
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy
                    })
                .FirstOrDefault();
        }
        public void Create(POFECDTO POFECDTO)
        {
            POFEC obj = _mapper.Map<POFEC>(POFECDTO);
            obj.CreatedDate = DateTime.Now;
            _unitOfWork.POFEC.Create(obj);
            _unitOfWork.SaveChanges();           
        }
        public void Update(POFECDTO POFECDTO)
        {
            int ID = POFECDTO.ID;
            POFEC pipeline = _unitOfWork.POFEC.FindById(ID);
            if (pipeline != null)
            {
                int yearInService = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.EquipmentNo == pipeline.EquipmentNo)
                                     select p.YearInService
                                    ).FirstOrDefault();
                decimal operatingTemperature = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.EquipmentNo == pipeline.EquipmentNo)
                                                select p.OperatingTemperature.Value
                                    ).FirstOrDefault();

                string lastMeasuredThick = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.EquipmentNo == pipeline.EquipmentNo)
                                            select p.UseLastMeasuredThick_ULMT
                                    ).FirstOrDefault();

                int? lastMeasuredYear = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.EquipmentNo == pipeline.EquipmentNo)
                                         select p.LastMeasuredYear_LMY
                                    ).FirstOrDefault();

                if (!pipeline.AnalysisYear.HasValue)
                    pipeline.AnalysisYear = DateTime.Now.Year;
                pipeline.TheoriticalCR = POFECDTO.TheoriticalCR;
                pipeline.EffectiveCR = POFECDTO.EffectiveCR;
                pipeline.EffectiveAge = POFECDTO.EffectiveAge;
                pipeline.MeasuredLCR = POFECDTO.MeasuredLCR;
                pipeline.MeasuredSCR = POFECDTO.MeasuredSCR;
                pipeline.UseMeasuredLCR = POFECDTO.UseMeasuredLCR;
                pipeline.UseMeasuredSCR = POFECDTO.UseMeasuredSCR;
                pipeline.VeryHigh = POFECDTO.VeryHigh;
                pipeline.High = POFECDTO.High;
                pipeline.Medium = POFECDTO.Medium;
                pipeline.Low = POFECDTO.Low;
                pipeline.Found = POFECDTO.Found;
                pipeline.DamageFactor = POFECDTO.DamageFactor;
                pipeline.POF = POFECDTO.POF;
                pipeline.LastMeasuredYear = POFECDTO.LastMeasuredYear;
                pipeline.SoilInterfaceCondensation = POFECDTO.SoilInterfaceCondensation;
                pipeline.PipeDirectBeamComplexDesign = POFECDTO.PipeDirectBeamComplexDesign;
                pipeline.RepaintedYear = POFECDTO.RepaintedYear;
                pipeline.Driver = POFECDTO.Driver;
                pipeline.CoatingQuality = POFECDTO.CoatingQuality;
                pipeline.CoatingAge = POFECDTO.CoatingAge;
                pipeline.CoatAdjustment = POFECDTO.CoatAdjustment;
                pipeline.CorrosionType = POFECDTO.CorrosionType;
                pipeline.ExternalProcess = POFECDTO.ExternalProcess;
                pipeline.LineAge = POFECDTO.LineAge;

                pipeline.ModifiedBy = POFECDTO.ModifiedBy;
                pipeline.ModifiedDate = DateTime.Now;

                // Repainted Year
                // TODO: Add Repainted column
                // update from Pipe report if repainted=Y then Report Year else YIS from pipe master
                if(!pipeline.RepaintedYear.HasValue)
                pipeline.RepaintedYear = yearInService;

                // Coating Age
                if (pipeline.RepaintedYear.HasValue && pipeline.RepaintedYear.Value > 0)
                    pipeline.CoatingAge = pipeline.AnalysisYear - pipeline.RepaintedYear;
                else
                    pipeline.CoatingAge = pipeline.AnalysisYear - yearInService;

                // Line External Age
                if(lastMeasuredThick == "Y" && lastMeasuredYear.HasValue)
                    pipeline.LineAge = pipeline.AnalysisYear - lastMeasuredYear.Value;
                else
                pipeline.LineAge = pipeline.AnalysisYear - yearInService;

                if (pipeline.LineAge >= pipeline.CoatingAge && pipeline.CoatingQuality == "L")
                    pipeline.CoatAdjustment = 0;
                else if (pipeline.LineAge >= pipeline.CoatingAge && pipeline.CoatingQuality == "M")
                    pipeline.CoatAdjustment = Math.Min(5, pipeline.CoatingAge.Value);
                else if (pipeline.LineAge >= pipeline.CoatingAge && pipeline.CoatingQuality == "H")
                    pipeline.CoatAdjustment = Math.Min(15, pipeline.CoatingAge.Value);
                else if (pipeline.LineAge < pipeline.CoatingAge && pipeline.CoatingQuality == "L")
                    pipeline.CoatAdjustment = 0;
                else if (pipeline.LineAge < pipeline.CoatingAge && pipeline.CoatingQuality == "M")
                    pipeline.CoatAdjustment = Math.Min(5, (pipeline.CoatingAge.Value - pipeline.LineAge.Value));
                else if (pipeline.LineAge < pipeline.CoatingAge && pipeline.CoatingQuality == "H")
                    pipeline.CoatAdjustment = Math.Min(15, (pipeline.CoatingAge.Value - pipeline.LineAge.Value));

                pipeline.EffectiveAge = pipeline.LineAge - pipeline.CoatAdjustment;

                // Theoretical CR
                if (pipeline.CorrosionType == "EC")
                    pipeline.TheoriticalCR = (from p in _unitOfWork.ExternalCorrosionRate.FindAll().Where(p => p.OperatingTemperatureInDegC >= operatingTemperature && p.Driver == pipeline.Driver)
                                                select p.CorrosionRate
                                 ).FirstOrDefault();
                else if (pipeline.CorrosionType == "CUI")
                    pipeline.TheoriticalCR = (from p in _unitOfWork.CUICorrosionRate.FindAll().Where(p => p.OperatingTemperatureInDegC >= operatingTemperature && p.Driver == pipeline.Driver)
                                              select p.CorrosionRate
                                 ).FirstOrDefault();

                // EffectiveCR
                if (pipeline.UseMeasuredLCR == "Y")
                    pipeline.EffectiveCR = pipeline.MeasuredLCR;
                else if (pipeline.UseMeasuredSCR == "Y")
                    pipeline.EffectiveCR = pipeline.MeasuredSCR;
                else if (pipeline.SoilInterfaceCondensation == "Y")
                    pipeline.EffectiveCR = 2 * pipeline.TheoriticalCR;
                else if (pipeline.PipeDirectBeamComplexDesign == "Y")
                    pipeline.EffectiveCR = 2 * pipeline.TheoriticalCR;
                else
                    pipeline.EffectiveCR = pipeline.TheoriticalCR;

                // Suceptability 
                if (pipeline.CorrosionType == "EC")
                    pipeline.Suceptability = (from p in _unitOfWork.ExternalSuceptablity.FindAll().Where(p => p.OperatingTemperatureInDegC_From < operatingTemperature && p.OperatingTemperatureInDegC_To >= operatingTemperature && p.Driver == pipeline.Driver)
                                              select p.Suceptability
                                    ).FirstOrDefault();
                else if (pipeline.CorrosionType == "CUI")
                    pipeline.Suceptability = (from p in _unitOfWork.CUISuceptablity.FindAll().Where(p => p.OperatingTemperatureInDegC_From < operatingTemperature && p.OperatingTemperatureInDegC_To >= operatingTemperature && p.Driver == pipeline.Driver)
                                              select p.Suceptability
                                   ).FirstOrDefault();


                // Adjusted Suceptability 
                if (pipeline.CorrosionType == "EC")
                    pipeline.AdjustedSuceptability = pipeline.Suceptability;
                else if (pipeline.CorrosionType == "CUI")
                {
                    if (pipeline.InsulationCondition == "Y" || pipeline.PipeDirectBeamComplexDesign == "Y")
                        pipeline.AdjustedSuceptability = pipeline.Suceptability;
                    else
                        pipeline.AdjustedSuceptability = pipeline.Suceptability;
                }
            }
            _unitOfWork.POFEC.Update(pipeline);
            _unitOfWork.SaveChanges();

            Update(pipeline.EquipmentNo, pipeline.AnalysisYear.Value);
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.POFEC.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.POFEC.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public void Update(string EQUIPMENT_NO, decimal PRESENT_YEAR, decimal EFFICIENCY_OF_WELD_E = 1, decimal YOUNGS_MODULUS_Y = 1)
        {
            var param1 = new Npgsql.NpgsqlParameter("I_EQUIPMENT_NO", NpgsqlTypes.NpgsqlDbType.Varchar);
            param1.Value = EQUIPMENT_NO;

            var param2 = new Npgsql.NpgsqlParameter("I_PRESENT_YEAR", NpgsqlTypes.NpgsqlDbType.Numeric);
            param2.Value = PRESENT_YEAR;           

            var parameters = new[] {
                param1,param2
            };
            _context.Database.ExecuteSqlRaw("call sp_upd_pof_ec(@I_EQUIPMENT_NO,@I_PRESENT_YEAR);", parameters);
        }

        public List<POF_EC> GetPOF_EC_Details(string EQUIPMENT_NO, string PRESENT_YEAR)
        {

            List<POF_EC> pofic = new List<POF_EC>();
            if (!string.IsNullOrWhiteSpace(EQUIPMENT_NO) && !string.IsNullOrWhiteSpace(PRESENT_YEAR))
            {
                pofic = (from p in _unitOfWork.POF_EC.FindAll().Where(p => p.EQUIPMENT_NO == EQUIPMENT_NO && p.PRESENT_YEAR == PRESENT_YEAR)
                         select p).ToList();
            }
            else
            {

                pofic = (from p in _unitOfWork.POF_EC.FindAll()
                         select p).ToList();
            }

            pofic = pofic.OrderBy(p => p.EQUIPMENT_NO).ThenBy(p => p.PRESENT_YEAR).ToList();

            return pofic;
        }

    }
}
