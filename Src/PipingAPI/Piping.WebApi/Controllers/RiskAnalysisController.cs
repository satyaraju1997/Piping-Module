using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Piping.Contracts.Services;
using Piping.DTO;
using System;
using System.Collections.Generic;
using AutoMapper;
using Serilog;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Piping.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [EnableCors("AllowMyOrigin")]
    public class RiskAnalysisController : Controller
    {


        private readonly IRiskAnalysisService _riskAnalysisService;
        private readonly IMapper _mapper;
        private readonly ILogger<RiskAnalysisController> _logger;
        public RiskAnalysisController(IRiskAnalysisService riskAnalysisService, IMapper mapper, ILogger<RiskAnalysisController> logger)
        {
            _riskAnalysisService = riskAnalysisService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCurrentRiskMatrix")]
        public RiskMatrixDTO GetCurrentRiskMatrix()
        {
            RiskMatrixDTO result = new RiskMatrixDTO();
            try
            {
                result = _riskAnalysisService.GetCurrentRiskMatrix();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;

        }
        [HttpGet]
        [Route("GetCurrentRiskChart")]
        public RiskChartDTO GetCurrentRiskChart(int Priority)
        {
            RiskChartDTO result = new RiskChartDTO();
            try
            {
                result = _riskAnalysisService.GetCurrentRiskChart(Priority);
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;

        }
        [HttpGet]
        [Route("GetCurrentRiskSheet")]
        public List<RiskAnalysisDTO> GetCurrentRiskSheet(int Priority)
        {
            List<RiskAnalysisDTO> result = new List<RiskAnalysisDTO>();
            try
            {
                result = _riskAnalysisService.GetCurrentRiskSheet(Priority);
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;

        }

        [HttpGet]
        [Route("GetAnalysisRiskMatrix")]
        public RiskMatrixDTO GetAnalysisRiskMatrix()
        {
            RiskMatrixDTO result = new RiskMatrixDTO();
            try
            {
                result = _riskAnalysisService.GetAnalysisRiskMatrix();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;

        }
        [HttpGet]
        [Route("GetAnalysisRiskChart")]
        public RiskChartDTO GetAnalysisRiskChart(int Priority)
        {
            RiskChartDTO result = new RiskChartDTO();
        try
        {
            result = _riskAnalysisService.GetAnalysisRiskChart(Priority);
            _logger.LogDebug("Result returned");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "");
        }

        return result;
        }


    [HttpGet]
    [Route("GetAnalysisRiskSheet")]
    public List<RiskAnalysisDTO> GetAnalysisRiskSheet(int Priority)
        {
        List<RiskAnalysisDTO> result = new List<RiskAnalysisDTO>();
        try
        {
            result = _riskAnalysisService.GetAnalysisRiskSheet(Priority);
            _logger.LogDebug("Result returned");
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "");
        }

        return result;
    }


        [HttpPost]
        [Route("AnalyzeRisk")]
        public BaseResponseDTO AnalyzeRisk([FromBody]RiskAnalysisParameterDTO parameter)
        {
            BaseResponseDTO result = new BaseResponseDTO();
            try
            {
                result = _riskAnalysisService.AnalyzeRisk(parameter);
               
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }
            return result;
         }
        



    }
}
