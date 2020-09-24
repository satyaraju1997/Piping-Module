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
    public class POFICService : IPOFICService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public POFICService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public List<POFICDTO> GetAll()
        {
            return (from p in _unitOfWork.POFIC.FindAll()
                    select new POFICDTO
                    {
                        ID = p.ID,
                        PipeMasterID = p.PipeMasterID,
                        EquipmentNo = p.EquipmentNo,
                        InjectionPoints = p.InjectionPoints,
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
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy
                    })
                .ToList();
        }

        public POFICDTO GetByID(int ID)
        {
            return (from p in _unitOfWork.POFIC.FindAll().Where(p => p.ID == ID)
                    select new POFICDTO
                    {
                        ID = p.ID,
                        PipeMasterID = p.PipeMasterID,
                        EquipmentNo = p.EquipmentNo,
                        InjectionPoints = p.InjectionPoints,
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
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy
                    })
                .FirstOrDefault();
        }

        public POFICDTO GetByPipeNo(string EquipmentNo)
        {
            return (from p in _unitOfWork.POFIC.GenerateEntityAsIQueryable().Where(p => p.EquipmentNo == EquipmentNo).OrderByDescending(p => p.CreatedDate)
                    select new POFICDTO
                    {
                        ID = p.ID,
                        PipeMasterID = p.PipeMasterID,
                        EquipmentNo = p.EquipmentNo,
                        InjectionPoints = p.InjectionPoints,
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
                        CreatedBy = p.CreatedBy,
                        ModifiedBy = p.ModifiedBy
                    })
                .FirstOrDefault();
        }

        public void Create(POFICDTO POFICDTO)
        {
            POFIC obj = _mapper.Map<POFIC>(POFICDTO);
            obj.CreatedDate = DateTime.Now;
            _unitOfWork.POFIC.Create(obj);
            _unitOfWork.SaveChanges();           
        }
        public void Update(POFICDTO POFICDTO)
        {
            int ID = POFICDTO.ID;
            POFIC pipeline = _unitOfWork.POFIC.FindById(ID);
            
            if (pipeline != null)
            {
                
                int yearInService = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.EquipmentNo == pipeline.EquipmentNo)
                                     select p.YearInService                                    
                                    ).FirstOrDefault();


                int? lastMeasuredYear = (from p in _unitOfWork.PipeMaster.FindAll().Where(p => p.EquipmentNo == pipeline.EquipmentNo)
                                     select p.LastMeasuredYear_LMY
                                  ).FirstOrDefault();

                if (!pipeline.AnalysisYear.HasValue)
                    pipeline.AnalysisYear = DateTime.Now.Year;
                pipeline.InjectionPoints = POFICDTO.InjectionPoints;
                pipeline.TheoriticalCR = POFICDTO.TheoriticalCR;
                pipeline.EffectiveCR = POFICDTO.EffectiveCR;
                pipeline.EffectiveAge = POFICDTO.EffectiveAge;
                pipeline.MeasuredLCR = POFICDTO.MeasuredLCR;
                pipeline.MeasuredSCR = POFICDTO.MeasuredSCR;
                pipeline.UseMeasuredLCR = POFICDTO.UseMeasuredLCR;
                pipeline.UseMeasuredSCR = POFICDTO.UseMeasuredSCR;
                pipeline.VeryHigh = POFICDTO.VeryHigh;
                pipeline.High = POFICDTO.High;
                pipeline.Medium = POFICDTO.Medium;
                pipeline.Low = POFICDTO.Low;
                pipeline.Found = POFICDTO.Found;
                pipeline.DamageFactor = POFICDTO.DamageFactor;
                pipeline.POF = POFICDTO.POF;
                pipeline.LastMeasuredYear = POFICDTO.LastMeasuredYear;               
                
                pipeline.ModifiedBy = POFICDTO.ModifiedBy;
                pipeline.ModifiedDate = DateTime.Now;
                // EffectiveCR
                if (pipeline.UseMeasuredLCR == "Y")
                    pipeline.EffectiveCR = pipeline.MeasuredLCR;
                else if (pipeline.UseMeasuredSCR == "Y")
                    pipeline.EffectiveCR = pipeline.MeasuredSCR;
                else if (pipeline.InjectionPoints == "Y")
                    pipeline.EffectiveCR = 2 * pipeline.TheoriticalCR;
                else if (pipeline.InjectionPoints == "N")
                    pipeline.EffectiveCR = pipeline.TheoriticalCR;

                // EffectiveAge 
                if (lastMeasuredYear.HasValue)
                    pipeline.EffectiveAge = pipeline.AnalysisYear - lastMeasuredYear;
                else 
                    pipeline.EffectiveAge = pipeline.AnalysisYear - yearInService;               
            }
            _unitOfWork.POFIC.Update(pipeline);
            _unitOfWork.SaveChanges();

            Update(pipeline.EquipmentNo, pipeline.AnalysisYear.Value);
        }
        public void Delete(int ID)
        {
            var entity = _unitOfWork.POFIC.FindById(ID);
            if (entity != null)
            {
                _unitOfWork.POFIC.Delete(entity);
                _unitOfWork.SaveChanges();
            }
        }

        public void CalculateMassPOF()
        {
            List<PipeMaster> pipeMasterList = (from p in _unitOfWork.PipeMaster.FindAll() select p).ToList<PipeMaster>();

            foreach (PipeMaster pipe in pipeMasterList)
            {
                POFIC pof = new POFIC
                {
                    ID = 0,
                    PipeMasterID = pipe.ID,
                    EquipmentNo = pipe.EquipmentNo,
                    InjectionPoints = "N",
                    TheoriticalCR = 1M,
                    EffectiveCR = 1M,
                    EffectiveAge = DateTime.Now.Year - pipe.YearInService,
                    MeasuredLCR = 1M,
                    MeasuredSCR = 1M,
                    UseMeasuredLCR = "N",
                    UseMeasuredSCR = "N",
                    VeryHigh = 0,
                    High = 0,
                    Medium = 0,
                    Low = 0,
                    Found = 0,
                    DamageFactor = 1,
                    POF = 1,
                    LastMeasuredYear = null
                };               

                _unitOfWork.POFIC.Create(pof);
                _unitOfWork.SaveChanges();
            }
        }

        public POF_IC GetByEquipmentNo(string EquipmentNo)
        {
            POF_IC  pofic = new POF_IC();

            pofic = (from p in _unitOfWork.POF_IC.GenerateEntityAsIQueryable().Where(p => p.EQUIPMENT_NO == EquipmentNo).OrderByDescending(p => p.CreatedDate)
                    select p).FirstOrDefault();

            return pofic;
        }

        public POF_IC GetByUnitID(int UnitID)
        {
            POF_IC pofic = new POF_IC();

            string EquipmentNo = (from p in _unitOfWork.PipeMaster.GenerateEntityAsIQueryable().Where(p => p.ID == UnitID).OrderByDescending(p => p.CreatedDate)
                                  select p.EquipmentNo).FirstOrDefault();

            pofic = (from p in _unitOfWork.POF_IC.GenerateEntityAsIQueryable().Where(p => p.EQUIPMENT_NO == EquipmentNo).OrderByDescending(p => p.CreatedDate)
                     select p).FirstOrDefault();

            return pofic;
        }

        public void Update(string EQUIPMENT_NO,decimal PRESENT_YEAR, decimal EFFICIENCY_OF_WELD_E = 1, decimal YOUNGS_MODULUS_Y = 1)
        {
            
            var param1 = new Npgsql.NpgsqlParameter("I_EQUIPMENT_NO", NpgsqlTypes.NpgsqlDbType.Varchar);
            param1.Value = EQUIPMENT_NO;

            var param2 = new Npgsql.NpgsqlParameter("I_PRESENT_YEAR", NpgsqlTypes.NpgsqlDbType.Numeric);
            param2.Value = PRESENT_YEAR;

            //var param3 = new Npgsql.NpgsqlParameter("I_EFFICIENCY_OF_WELD_E", NpgsqlTypes.NpgsqlDbType.Numeric);
            //param3.Value = EFFICIENCY_OF_WELD_E;

            //var param4 = new Npgsql.NpgsqlParameter("I_YOUNGS_MODULUS_Y", NpgsqlTypes.NpgsqlDbType.Numeric);
            //param4.Value = YOUNGS_MODULUS_Y;

            var parameters = new[] {
                param1,param2
            };
            _context.Database.ExecuteSqlRaw("call sp_upd_pof_ic(@I_EQUIPMENT_NO,@I_PRESENT_YEAR);", parameters);
        }

        public List<POF_IC> GetPOF_IC_Details(string EQUIPMENT_NO, string PRESENT_YEAR)
        {

            List<POF_IC> pofic = new List<POF_IC>();
            List<POF_EC> pofec = new List<POF_EC>();

            if (!string.IsNullOrWhiteSpace(EQUIPMENT_NO) && !string.IsNullOrWhiteSpace(PRESENT_YEAR))
            {
                pofic = (from p in _unitOfWork.POF_IC.FindAll().Where(p => p.EQUIPMENT_NO == EQUIPMENT_NO && p.PRESENT_YEAR == PRESENT_YEAR)
                         select p).ToList();

                pofec = (from p in _unitOfWork.POF_EC.FindAll().Where(p => p.EQUIPMENT_NO == EQUIPMENT_NO && p.PRESENT_YEAR == PRESENT_YEAR)
                         select p).ToList();
            }
            else
            {

                pofic = (from p in _unitOfWork.POF_IC.FindAll()
                         select p).ToList();

                pofec = (from p in _unitOfWork.POF_EC.FindAll()
                         select p).ToList();
            }
            foreach (POF_EC temppof in pofec)
            {
                POF_IC pof = new POF_IC();


                pof.ID = temppof.ID;
                pof.EQUIPMENT_NO = temppof.EQUIPMENT_NO;

                pof.PRESENT_YEAR = temppof.PRESENT_YEAR;
                pof.CORROSION_TYPE = temppof.CORROSION_TYPE;

                pof.YEAR_IN_SERVICE = temppof.YEAR_IN_SERVICE;

                pof.NOM_DIA_D_INCHES = temppof.NOM_DIA_D_INCHES;

                pof.NOM_THK_NT_INCHES = temppof.NOM_THK_NT_INCHES;

                pof.DESIGN_TEMP_DEGF = temppof.DESIGN_TEMP_DEGF;

                pof.DESIGN_PRESSURE_P_PSI = temppof.DESIGN_PRESSURE_P_PSI;

                pof.EFFECTIVE_CORROSION_RATE = temppof.EFFECTIVE_CORROSION_RATE;

                pof.MATERIAL_STD = temppof.MATERIAL_STD;

                pof.MATERIAL_GRADE = temppof.MATERIAL_GRADE;

                pof.INJECTION_POINTS_INTERMITENT = temppof.INJECTION_POINTS_INTERMITENT;

                pof.CORROSION_ALLOWANCE = temppof.CORROSION_ALLOWANCE;

                pof.VERY_HIGH = temppof.VERY_HIGH;

                pof.HIGH = temppof.HIGH;

                pof.MEDIUM = temppof.MEDIUM;

                pof.LOW = temppof.LOW;

                pof.NO = temppof.NO;


                pof.THEORETICAL_CORROSION_RATE_TICR = temppof.THEORETICAL_CORROSION_RATE_TICR;

                pof.MEASURED_LONGTERM_CORROSION_RATE_LICR = temppof.MEASURED_LONGTERM_CORROSION_RATE_LICR;

                pof.MEASURED_SHORTTERM_CORROSION_RATE_SICR = temppof.MEASURED_SHORTTERM_CORROSION_RATE_SICR;

                pof.USE_LICR = temppof.USE_LICR;

                pof.USE_SICR = temppof.USE_SICR;


                pof.LAST_MEASURED_THK_FOR_DIA_LMT = temppof.LAST_MEASURED_THK_FOR_DIA_LMT;

                pof.LAST_MEASURED_YEAR_FOR_DIA_LMY = temppof.LAST_MEASURED_YEAR_FOR_DIA_LMY;

                pof.YIELD_STRENGTH_KSI = temppof.YIELD_STRENGTH_KSI;

                pof.TENSILE_STREGTH_KSI = temppof.TENSILE_STREGTH_KSI;

                pof.EFFICIENCY_OF_WELD_E = temppof.EFFICIENCY_OF_WELD_E;

                pof.YOUNGS_MODULUS_Y = temppof.YOUNGS_MODULUS_Y;

                pof.ALLOWABLE_STRESS_PSI = temppof.ALLOWABLE_STRESS_PSI;

                pof.PRP_1 = temppof.PRP_1;

                pof.PRP_2 = temppof.PRP_2;

                pof.PRP_3 = temppof.PRP_3;

                pof.CONDITIONAL_PROBABILITY_1_A = temppof.CONDITIONAL_PROBABILITY_1_A;

                pof.CONDITIONAL_PROBABILITY_1_B = temppof.CONDITIONAL_PROBABILITY_1_B;

                pof.CONDITIONAL_PROBABILITY_1_C = temppof.CONDITIONAL_PROBABILITY_1_C;

                pof.CONDITIONAL_PROBABILITY_1_D = temppof.CONDITIONAL_PROBABILITY_1_D;

                pof.CONDITIONAL_PROBABILITY_1_E = temppof.CONDITIONAL_PROBABILITY_1_E;

                pof.CONDITIONAL_PROBABILITY_2_A = temppof.CONDITIONAL_PROBABILITY_2_A;

                pof.CONDITIONAL_PROBABILITY_2_B = temppof.CONDITIONAL_PROBABILITY_2_B;

                pof.CONDITIONAL_PROBABILITY_2_C = temppof.CONDITIONAL_PROBABILITY_2_C;

                pof.CONDITIONAL_PROBABILITY_2_D = temppof.CONDITIONAL_PROBABILITY_2_D;

                pof.CONDITIONAL_PROBABILITY_2_E = temppof.CONDITIONAL_PROBABILITY_2_E;

                pof.CONDITIONAL_PROBABILITY_3_A = temppof.CONDITIONAL_PROBABILITY_3_A;

                pof.CONDITIONAL_PROBABILITY_3_B = temppof.CONDITIONAL_PROBABILITY_3_B;

                pof.CONDITIONAL_PROBABILITY_3_C = temppof.CONDITIONAL_PROBABILITY_3_C;

                pof.CONDITIONAL_PROBABILITY_3_D = temppof.CONDITIONAL_PROBABILITY_3_D;

                pof.CONDITIONAL_PROBABILITY_3_E = temppof.CONDITIONAL_PROBABILITY_3_E;

                pof.EFFECTIVE_AGE = temppof.EFFECTIVE_AGE;

                pof.EFFECTIVE_THK = temppof.EFFECTIVE_THK;

                pof.MIN_REQ_THK = temppof.MIN_REQ_THK;

                pof.EFFECTIVE_CORR_RATE = temppof.EFFECTIVE_CORR_RATE;

                pof.ART = temppof.ART;

                pof.FLOW_STRESS = temppof.FLOW_STRESS;

                pof.STENGTH_RATIO = temppof.STENGTH_RATIO;

                pof.INSPECTION_EFFECTIVENESS_1 = temppof.INSPECTION_EFFECTIVENESS_1;

                pof.INSPECTION_EFFECTIVENESS_2 = temppof.INSPECTION_EFFECTIVENESS_2;

                pof.INSPECTION_EFFECTIVENESS_3 = temppof.INSPECTION_EFFECTIVENESS_3;

                pof.POSTERIOR_PROBABILITY_1 = temppof.POSTERIOR_PROBABILITY_1;

                pof.POSTERIOR_PROBABILITY_2 = temppof.POSTERIOR_PROBABILITY_2;

                pof.POSTERIOR_PROBABILITY_3 = temppof.POSTERIOR_PROBABILITY_3;

                pof.CAL_OF_BETA_COVT = temppof.CAL_OF_BETA_COVT;

                pof.CAL_OF_BETA_COVSF = temppof.CAL_OF_BETA_COVSF;

                pof.CAL_OF_BETA_COVP = temppof.CAL_OF_BETA_COVP;

                pof.CAL_OF_BETA_CONST_1 = temppof.CAL_OF_BETA_CONST_1;

                pof.CAL_OF_BETA_CONST_2 = temppof.CAL_OF_BETA_CONST_2;

                pof.CAL_OF_BETA_CONST_3 = temppof.CAL_OF_BETA_CONST_3;

                pof.CAL_OF_BETA_1 = temppof.CAL_OF_BETA_1;

                pof.CAL_OF_BETA_2 = temppof.CAL_OF_BETA_2;

                pof.CAL_OF_BETA_3 = temppof.CAL_OF_BETA_3;

                pof.CAL_OF_BETA_DS_VALUES_1 = temppof.CAL_OF_BETA_DS_VALUES_1;

                pof.CAL_OF_BETA_DS_VALUES_2 = temppof.CAL_OF_BETA_DS_VALUES_2;

                pof.CAL_OF_BETA_DS_VALUES_3 = temppof.CAL_OF_BETA_DS_VALUES_3;

                pof.DAMAGE_FACTOR = temppof.DAMAGE_FACTOR;

                pof.POF = temppof.POF;

                pof.POF_EXPO = temppof.POF_EXPO;

                pof.AVAILABLE_THK = temppof.AVAILABLE_THK;

                pof.REMAINING_LIFE = temppof.REMAINING_LIFE;

                pof.HALF_LIFE = temppof.HALF_LIFE;

                pof.POF_HALF_LIFE = temppof.POF_HALF_LIFE;

                pof.OVERALL_POF = temppof.OVERALL_POF;

                pofic.Add(pof);
            }

            pofic = pofic.OrderBy(p => p.EQUIPMENT_NO).ThenBy(p => p.PRESENT_YEAR).ToList();

            return pofic;
        }
    }
}
