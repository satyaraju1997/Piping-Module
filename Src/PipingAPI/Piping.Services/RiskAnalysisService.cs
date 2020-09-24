using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class RiskAnalysisService : IRiskAnalysisService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly PipingContext _context;
        public RiskAnalysisService(IUnitOfWork unitOfWork, IMapper mapper, PipingContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        public RiskMatrixDTO GetCurrentRiskMatrix()
        {
        RiskMatrixDTO riskMatrix = new RiskMatrixDTO();

        List <RiskLineChartDTO> list = (from p in _unitOfWork.RiskAnalysis.FindAll()

                                           group p by new
                                           {
                                               p.COF,
                                               p.CurrentPOF
                                           } into g
                                           select new RiskLineChartDTO
                                           {
                                               Failure = g.Key.COF + g.Key.CurrentPOF.Value.ToString(),
                                               Count = g.Count()
                                           })
                                            .ToList();           

            foreach (RiskLineChartDTO item in list)
            {
                switch (item.Failure)
                {
                    case "A1":
                        riskMatrix.A1 = item.Count;
                        break;
                    case "A2":
                        riskMatrix.A2 = item.Count;
                        break;
                    case "A3":
                        riskMatrix.A3 = item.Count;
                        break;
                    case "A4":
                        riskMatrix.A4 = item.Count;
                        break;
                    case "A5":
                        riskMatrix.A5 = item.Count;
                        break;

                    case "B1":
                        riskMatrix.B1 = item.Count;
                        break;
                    case "B2":
                        riskMatrix.B2 = item.Count;
                        break;
                    case "B3":
                        riskMatrix.B3 = item.Count;
                        break;
                    case "B4":
                        riskMatrix.B4 = item.Count;
                        break;
                    case "B5":
                        riskMatrix.B5 = item.Count;
                        break;

                    case "C1":
                        riskMatrix.C1 = item.Count;
                        break;
                    case "C2":
                        riskMatrix.C2 = item.Count;
                        break;
                    case "C3":
                        riskMatrix.C3 = item.Count;
                        break;
                    case "C4":
                        riskMatrix.C4 = item.Count;
                        break;
                    case "C5":
                        riskMatrix.C5 = item.Count;
                        break;

                    case "D1":
                        riskMatrix.D1 = item.Count;
                        break;
                    case "D2":
                        riskMatrix.D2 = item.Count;
                        break;
                    case "D3":
                        riskMatrix.D3 = item.Count;
                        break;
                    case "D4":
                        riskMatrix.D4 = item.Count;
                        break;
                    case "D5":
                        riskMatrix.D5 = item.Count;
                        break;

                    case "E1":
                        riskMatrix.E1 = item.Count;
                        break;
                    case "E2":
                        riskMatrix.E2 = item.Count;
                        break;
                    case "E3":
                        riskMatrix.E3 = item.Count;
                        break;
                    case "E4":
                        riskMatrix.E4 = item.Count;
                        break;
                    case "E5":
                        riskMatrix.E5 = item.Count;
                        break;
                }
            }

            return riskMatrix;
        }

        public RiskMatrixDTO GetCurrentRiskMatrix(RiskAnalysisFilterDTO filter)
        {
            string PlantCode = "";
            string ParentPlantCode = "";
            string FluidCode = "";
            string Priority = "";

            RiskMatrixDTO riskMatrix = new RiskMatrixDTO();

            //IQueryable<RiskAnalysis> query = (from r in _unitOfWork.RiskAnalysis.GenerateEntityAsIQueryable()
            //                                  join p in _context.PipeMaster on r.EquipmentNo equals l.Code
            //                                  join l in _context.Plant on p.PlantCode equals l.Code
            //                                  select r);

            //List<RiskLineChartDTO> list = (from p in _unitOfWork.RiskAnalysis.FindAll()

            //                               group p by new
            //                               {
            //                                   p.COF,
            //                                   p.CurrentPOF
            //                               } into g
            //                               select new RiskLineChartDTO
            //                               {
            //                                   Failure = g.Key.COF + g.Key.CurrentPOF.Value.ToString(),
            //                                   Count = g.Count()
            //                               })
            //                                      .ToList();

            //if (filter != null)
            //{
            //    if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.LoopNo))
            //        query = (from re in query
            //                 where re.LoopNo == corrosionStudyFilterDTO.LoopNo
            //                 select re);


            //    if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.PlantCode))
            //        query = (from re in query
            //                 where re.PlantCode == corrosionStudyFilterDTO.PlantCode
            //                 select re);

            //    if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.FluidCode))
            //        query = (from re in query
            //                 where re.FluidCode == corrosionStudyFilterDTO.FluidCode
            //                 select re);

            //    if (!string.IsNullOrWhiteSpace(corrosionStudyFilterDTO.ParentPlantCode))
            //        query = (from re in query
            //                 where re.ParentPlantCode == corrosionStudyFilterDTO.ParentPlantCode
            //                 select re);

            //    list = query.OrderBy(p => p.LoopNo).ToList();

            //}

            //foreach (RiskLineChartDTO item in list)
            //{
            //    switch (item.Failure)
            //    {
            //        case "A1":
            //            riskMatrix.A1 = item.Count;
            //            break;
            //        case "A2":
            //            riskMatrix.A2 = item.Count;
            //            break;
            //        case "A3":
            //            riskMatrix.A3 = item.Count;
            //            break;
            //        case "A4":
            //            riskMatrix.A4 = item.Count;
            //            break;
            //        case "A5":
            //            riskMatrix.A5 = item.Count;
            //            break;

            //        case "B1":
            //            riskMatrix.B1 = item.Count;
            //            break;
            //        case "B2":
            //            riskMatrix.B2 = item.Count;
            //            break;
            //        case "B3":
            //            riskMatrix.B3 = item.Count;
            //            break;
            //        case "B4":
            //            riskMatrix.B4 = item.Count;
            //            break;
            //        case "B5":
            //            riskMatrix.B5 = item.Count;
            //            break;

            //        case "C1":
            //            riskMatrix.C1 = item.Count;
            //            break;
            //        case "C2":
            //            riskMatrix.C2 = item.Count;
            //            break;
            //        case "C3":
            //            riskMatrix.C3 = item.Count;
            //            break;
            //        case "C4":
            //            riskMatrix.C4 = item.Count;
            //            break;
            //        case "C5":
            //            riskMatrix.C5 = item.Count;
            //            break;

            //        case "D1":
            //            riskMatrix.D1 = item.Count;
            //            break;
            //        case "D2":
            //            riskMatrix.D2 = item.Count;
            //            break;
            //        case "D3":
            //            riskMatrix.D3 = item.Count;
            //            break;
            //        case "D4":
            //            riskMatrix.D4 = item.Count;
            //            break;
            //        case "D5":
            //            riskMatrix.D5 = item.Count;
            //            break;

            //        case "E1":
            //            riskMatrix.E1 = item.Count;
            //            break;
            //        case "E2":
            //            riskMatrix.E2 = item.Count;
            //            break;
            //        case "E3":
            //            riskMatrix.E3 = item.Count;
            //            break;
            //        case "E4":
            //            riskMatrix.E4 = item.Count;
            //            break;
            //        case "E5":
            //            riskMatrix.E5 = item.Count;
            //            break;
            //    }
            //}

            return riskMatrix;
        }

        public RiskChartDTO GetCurrentRiskChart(int priority = 0)
        {
            RiskChartDTO riskChart = new RiskChartDTO();
            riskChart.EquipmentID = new List<string>();
            riskChart.CummulativeRisk = new List<int>();
            int[] list;

            if (priority > 0)
            {
                List<RiskAnalysis> riskList = (from p in _unitOfWork.RiskAnalysis.FindAll().Where(c => c.CurrentPriority == priority)
                                               orderby p.CurrentFinancialRisk.Value descending
                                               select p
                                    ).ToList();
                int cumulativeRisk = 0;
                foreach (RiskAnalysis risk in riskList)
                {
                    risk.CurrentCummulativeRisk = risk.CurrentFinancialRisk + cumulativeRisk;
                    cumulativeRisk = risk.CurrentCummulativeRisk.Value;
                }

                list = (from p in riskList
                        orderby p.CurrentCummulativeRisk.Value
                        select p.CurrentCummulativeRisk.Value
                                    ).ToArray();
            }
            else
                list = (from p in _unitOfWork.RiskAnalysis.FindAll()
                        orderby p.CurrentCummulativeRisk.Value
                        select p.CurrentCummulativeRisk.Value
                                     ).ToArray();



            int increment = list.Count() / 10;
            for (int index = 1; index < list.Count(); index = index + increment)
            {
                riskChart.EquipmentID.Add(index.ToString());
                riskChart.CummulativeRisk.Add(list[index - 1]);
            }
            return riskChart;
        }

        public List<RiskAnalysisDTO> GetCurrentRiskSheet(int priority = 0)
        {
            List<RiskAnalysisDTO> riskSheetList = new List<RiskAnalysisDTO>();          

            List<RiskAnalysis> riskAnalysisList = new List<RiskAnalysis>();

            if (priority == 0)
                riskAnalysisList = (from p in _unitOfWork.RiskAnalysis.FindAll() select p).OrderByDescending(c=> c.CurrentFinancialRisk).ToList();
            else
            {
                riskAnalysisList = (from p in _unitOfWork.RiskAnalysis.FindAll().Where(c => c.CurrentPriority == priority) select p).OrderByDescending(c => c.CurrentFinancialRisk).ToList();
            }
            int cumulativeRisk = 0;
            foreach (RiskAnalysis riskAnalysis in riskAnalysisList)
            {
                riskAnalysis.CurrentCummulativeRisk = riskAnalysis.CurrentFinancialRisk + cumulativeRisk;
                cumulativeRisk = riskAnalysis.CurrentCummulativeRisk.Value;
                RiskAnalysisDTO riskAnalysisDTO = _mapper.Map<RiskAnalysisDTO>(riskAnalysis);
                riskAnalysisDTO.AnalysisCummulativeRisk = riskAnalysisDTO.CurrentCummulativeRisk;
                riskAnalysisDTO.AnalysisPOF = riskAnalysisDTO.CurrentPOF;
                riskAnalysisDTO.AnalysisRisk = riskAnalysisDTO.CurrentRisk;
                riskAnalysisDTO.AnalysisYear = riskAnalysisDTO.CurrentYear;
                riskAnalysisDTO.AnalysisFinancial = riskAnalysisDTO.CurrentFinancial;
                riskAnalysisDTO.AnalysisFinancialRisk = riskAnalysisDTO.CurrentFinancialRisk;
                riskSheetList.Add(riskAnalysisDTO);
            }


            return riskSheetList;
        }

        public RiskMatrixDTO GetAnalysisRiskMatrix()
        {
            RiskMatrixDTO riskMatrix = new RiskMatrixDTO();

            List<RiskLineChartDTO> list = (from p in _unitOfWork.RiskAnalysis.FindAll()

                                           group p by new
                                           {
                                               p.COF,
                                               p.AnalysisPOF
                                           } into g
                                           select new RiskLineChartDTO
                                           {
                                               Failure = g.Key.COF + g.Key.AnalysisPOF.Value.ToString(),                                               
                                               Count = g.Count()
                                           })
                                            .ToList();

            foreach(RiskLineChartDTO item in list)
            {
                switch(item.Failure)
                {
                    case "A1":
                        riskMatrix.A1 = item.Count;
                        break;
                    case "A2":
                        riskMatrix.A2 = item.Count;
                        break;
                    case "A3":
                        riskMatrix.A3 = item.Count;
                        break;
                    case "A4":
                        riskMatrix.A4 = item.Count;
                        break;
                    case "A5":
                        riskMatrix.A5 = item.Count;
                        break;

                    case "B1":
                        riskMatrix.B1 = item.Count;
                        break;
                    case "B2":
                        riskMatrix.B2 = item.Count;
                        break;
                    case "B3":
                        riskMatrix.B3 = item.Count;
                        break;
                    case "B4":
                        riskMatrix.B4 = item.Count;
                        break;
                    case "B5":
                        riskMatrix.B5 = item.Count;
                        break;

                    case "C1":
                        riskMatrix.C1 = item.Count;
                        break;
                    case "C2":
                        riskMatrix.C2 = item.Count;
                        break;
                    case "C3":
                        riskMatrix.C3 = item.Count;
                        break;
                    case "C4":
                        riskMatrix.C4 = item.Count;
                        break;
                    case "C5":
                        riskMatrix.C5 = item.Count;
                        break;

                    case "D1":
                        riskMatrix.D1 = item.Count;
                        break;
                    case "D2":
                        riskMatrix.D2 = item.Count;
                        break;
                    case "D3":
                        riskMatrix.D3 = item.Count;
                        break;
                    case "D4":
                        riskMatrix.D4 = item.Count;
                        break;
                    case "D5":
                        riskMatrix.D5 = item.Count;
                        break;

                    case "E1":
                        riskMatrix.E1 = item.Count;
                        break;
                    case "E2":
                        riskMatrix.E2 = item.Count;
                        break;
                    case "E3":
                        riskMatrix.E3 = item.Count;
                        break;
                    case "E4":
                        riskMatrix.E4 = item.Count;
                        break;
                    case "E5":
                        riskMatrix.E5 = item.Count;
                        break;
                }
            }



            return riskMatrix;
        }

        public RiskChartDTO GetAnalysisRiskChart(int priority = 0)
        {
            RiskChartDTO riskChart = new RiskChartDTO();
            riskChart.EquipmentID = new List<string>();
            riskChart.CummulativeRisk = new List<int>();
            int[] list;

            //if (priority > 0)
            //    list = (from p in _unitOfWork.RiskAnalysis.FindAll().Where(c => c.AnalysisPriority == priority)
            //            orderby p.CurrentCummulativeRisk.Value
            //            select p.CurrentCummulativeRisk.Value
            //                        ).ToArray();
            if (priority > 0)
            {
                List<RiskAnalysis> riskList = (from p in _unitOfWork.RiskAnalysis.FindAll().Where(c => c.AnalysisPriority == priority)
                                               orderby p.AnalysisFinancialRisk.Value descending
                                               select p
                                    ).ToList();
                int cumulativeRisk = 0;
                foreach (RiskAnalysis risk in riskList)
                {
                    risk.AnalysisCummulativeRisk = risk.AnalysisFinancialRisk + cumulativeRisk;
                    cumulativeRisk = risk.AnalysisCummulativeRisk.Value;
                }

                list = (from p in riskList
                        orderby p.AnalysisCummulativeRisk.Value
                        select p.AnalysisCummulativeRisk.Value
                                    ).ToArray();
            }
            else
                list = (from p in _unitOfWork.RiskAnalysis.FindAll()
                        orderby p.AnalysisCummulativeRisk.Value
                        select p.AnalysisCummulativeRisk.Value
                                     ).ToArray();

            int increment = list.Count() / 10;
            for (int index = 1; index < list.Count(); index = index + increment)
            {
                riskChart.EquipmentID.Add(index.ToString());
                riskChart.CummulativeRisk.Add(list[index - 1]);
            }
            return riskChart;
        }

        public List<RiskAnalysisDTO> GetAnalysisRiskSheet(int priority = 0)
        {
            List<RiskAnalysisDTO> riskSheetList = new List<RiskAnalysisDTO>();

            List<RiskAnalysis> riskAnalysisList = new List<RiskAnalysis>();

            if (priority == 0)
                riskAnalysisList = (from p in _unitOfWork.RiskAnalysis.FindAll() select p).OrderByDescending(c => c.AnalysisFinancialRisk).ToList();
            else
            {
                riskAnalysisList = (from p in _unitOfWork.RiskAnalysis.FindAll().Where(c => c.AnalysisPriority == priority) select p).OrderByDescending(c => c.AnalysisFinancialRisk).ToList();
            }
            int currentCumulativeRisk = 0;
            int analysisCumulativeRisk = 0;
            foreach (RiskAnalysis riskAnalysis in riskAnalysisList)
            {
                riskAnalysis.CurrentCummulativeRisk = riskAnalysis.CurrentFinancialRisk + currentCumulativeRisk;
                currentCumulativeRisk = riskAnalysis.CurrentCummulativeRisk.Value;
                riskAnalysis.AnalysisCummulativeRisk = riskAnalysis.AnalysisFinancialRisk + analysisCumulativeRisk;
                analysisCumulativeRisk = riskAnalysis.AnalysisCummulativeRisk.Value;
                RiskAnalysisDTO riskAnalysisDTO = _mapper.Map<RiskAnalysisDTO>(riskAnalysis);
                
                riskSheetList.Add(riskAnalysisDTO);
            }


            return riskSheetList;
        }

        public BaseResponseDTO AnalyzeRisk(RiskAnalysisParameterDTO parameter)
        {
            try
            {
                int year = Convert.ToInt32(parameter.Year);
                int priority = Convert.ToInt32(parameter.Priority);                
                    priority = (priority == 0 ? 25 : priority);
                int veryHigh = 0, high = 0, medium = 0, low = 0;

                switch (parameter.Confidence)
                {
                    case "2":
                        veryHigh = 1;
                        break;
                    case "3":
                        high = 1;
                        break;
                    case "4":
                        medium = 1;
                        break;
                    case "5":
                        low = 1;
                        break;
                }

                var param1 = new Npgsql.NpgsqlParameter("I_ANALYSISYEAR", NpgsqlTypes.NpgsqlDbType.Integer);
                param1.Value = year;

                var param2 = new Npgsql.NpgsqlParameter("I_PRIORIRY", NpgsqlTypes.NpgsqlDbType.Integer);
                param2.Value = priority;

                var param3 = new Npgsql.NpgsqlParameter("I_VERY_HIGH", NpgsqlTypes.NpgsqlDbType.Integer);
                param3.Value = veryHigh;

                var param4 = new Npgsql.NpgsqlParameter("I_HIGH", NpgsqlTypes.NpgsqlDbType.Integer);
                param4.Value = high;

                var param5 = new Npgsql.NpgsqlParameter("I_MEDIUM", NpgsqlTypes.NpgsqlDbType.Integer);
                param5.Value = medium;

                var param6 = new Npgsql.NpgsqlParameter("I_LOW", NpgsqlTypes.NpgsqlDbType.Integer);
                param6.Value = low;

                var parameters = new[] {
                param1,param2,param3,param4,param5,param6
            };
                _context.Database.ExecuteSqlRaw("call USP_WhatIfAnalysis(@I_ANALYSISYEAR, @I_PRIORIRY, @I_VERY_HIGH, @I_HIGH, @I_MEDIUM, @I_LOW);", parameters);

                return new BaseResponseDTO()
                {
                    Status = true,
                    StatusMessage = "Success",
                    StatusCode = 200
                };
            }
            catch (Exception ex)
            {                
                return new BaseResponseDTO()
                {
                    Status = false,
                    StatusMessage = ex.Message,
                    StatusCode = 200
                };
            }
        }
    }
}
