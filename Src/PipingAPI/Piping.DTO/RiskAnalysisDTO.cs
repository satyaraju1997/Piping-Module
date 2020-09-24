using System;
using System.Collections.Generic;
using System.Text;

namespace Piping.DTO
{
    public class RiskMatrixDTO
    {
        public int A1 { get; set; }
        public int A2 { get; set; }
        public int A3 { get; set; }
        public int A4 { get; set; }
        public int A5 { get; set; }
        public int B1 { get; set; }
        public int B2 { get; set; }
        public int B3 { get; set; }
        public int B4 { get; set; }
        public int B5 { get; set; }

        public int C1 { get; set; }
        public int C2 { get; set; }
        public int C3 { get; set; }
        public int C4 { get; set; }
        public int C5 { get; set; }

        public int D1 { get; set; }
        public int D2 { get; set; }
        public int D3 { get; set; }
        public int D4 { get; set; }
        public int D5 { get; set; }

        public int E1 { get; set; }
        public int E2 { get; set; }
        public int E3 { get; set; }
        public int E4 { get; set; }
        public int E5 { get; set; }
    }

    public class RiskChartDTO
    {
        public List<string> EquipmentID { get; set; }
        public List<int> CummulativeRisk { get; set; }
    }   


    public class RiskLineChartDTO
    {
        public string Failure { get; set; }        
        public int Count { get; set; }
    }
    public class RiskAnalysisDTO
    {
        public int ID { get; set; }
        public string EquipmentNo { get; set; }
        public string COF { get; set; }
        public int? CurrentPOF { get; set; }
        
        public int? CurrentYear { get; set; }
      
        public int? CurrentPriority { get; set; }
       
        public string CurrentRisk { get; set; }
        
        public int? CurrentFinancial { get; set; }
       
        public int? CurrentFinancialRisk { get; set; }
       
        public int? CurrentCummulativeRisk { get; set; }

       
        public int? AnalysisPOF { get; set; }
     
        public int? AnalysisYear { get; set; }
       
        public int? AnalysisPriority { get; set; }
      
        public string AnalysisRisk { get; set; }
       
        public int? AnalysisFinancial { get; set; }
       
        public int? AnalysisFinancialRisk { get; set; }
       
        public int? AnalysisCummulativeRisk { get; set; }
    }

    public class RiskAnalysisParameterDTO
    {
        public string Confidence { get; set; }
        public string Year { get; set; }
        public string Priority { get; set; }       
    }

    public class RiskAnalysisFilterDTO
    {
        public string PlantCode { get; set; }
        public string ParentPlantCode { get; set; }
        public string FluidCode { get; set; }
        public string Confidence { get; set; }
        public string Year { get; set; }
        public string Priority { get; set; }
    }
}
