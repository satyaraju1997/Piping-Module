using Piping.DTO;
using System.Collections.Generic;

namespace Piping.Contracts.Services
{
    public interface IRiskAnalysisService
    {
        RiskMatrixDTO GetCurrentRiskMatrix();
        RiskChartDTO GetCurrentRiskChart(int Priority);
        List<RiskAnalysisDTO> GetCurrentRiskSheet(int Priority);
        RiskMatrixDTO GetAnalysisRiskMatrix();
        RiskChartDTO GetAnalysisRiskChart(int Priority);
        List<RiskAnalysisDTO> GetAnalysisRiskSheet(int Priority);
        BaseResponseDTO AnalyzeRisk(RiskAnalysisParameterDTO parameter);
    }
}
