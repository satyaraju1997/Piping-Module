using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace Piping.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [EnableCors("AllowMyOrigin")]
    public class PipeReportController : Controller
    {
        private readonly IPipeReportService _PipeReportService;
        private readonly IMapper _mapper;
        private readonly ILogger<PipeReportController> _logger;
        private IMemoryCache _cache;
        public PipeReportController(IPipeReportService PipeReportService, IMapper mapper, ILogger<PipeReportController> logger, IMemoryCache memoryCache)
        {
            _PipeReportService = PipeReportService;
            _mapper = mapper;
            _logger = logger;
            _cache = memoryCache;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<PipeReportDTO> GetAll()
        {
            List<PipeReportDTO> result = new List<PipeReportDTO>();

            try
            {
                result = _PipeReportService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetByEquipmentNo")]
        public List<PipeReportDTO> GetByEquipmentNo(string EquipmentNo)
        {
            List<PipeReportDTO> result = new List<PipeReportDTO>();

            try
            {
                result = _PipeReportService.GetByEquipmentNo(EquipmentNo);
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetByReportNo")]
        public PipeReportResponseDTO GetByReportNo(string ReportNo)
        {
            PipeReportResponseDTO result = new PipeReportResponseDTO();

            try
            {
                result = _PipeReportService.GetByReportNo(ReportNo);
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }


        [HttpGet("{ID}")]
        public PipeReportDTO Get(int ID)
        {
            return _PipeReportService.GetByID(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public PipeReportResponseDTO Post([FromForm]IFormCollection formCollections)
        {
            PipeReportRequestDTO pipeReportRequestDTO = new PipeReportRequestDTO();
            if (formCollections.TryGetValue("PipeReportInfo", out var pipeReportRequest))
            {
                pipeReportRequestDTO = JsonConvert.DeserializeObject<PipeReportRequestDTO>(pipeReportRequest[0]);
            }

                return _PipeReportService.Create(pipeReportRequestDTO);
        }

        // PUT api/<controller>               
        [HttpPut]
        public PipeReportResponseDTO Put([FromForm]IFormCollection formCollections)
        {
            PipeReportRequestDTO pipeReportRequestDTO = new PipeReportRequestDTO();
            if (formCollections.TryGetValue("PipeReportInfo", out var pipeReportRequest))
            {
                pipeReportRequestDTO = JsonConvert.DeserializeObject<PipeReportRequestDTO>(pipeReportRequest[0]);
            }

            return _PipeReportService.Update(pipeReportRequestDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
            _PipeReportService.Delete(ID);
        }
        [HttpGet]
        [Route("GetAllObservations")]
        public List<ObservationMasterDTO> GetAllObservations() 
        {
            return _PipeReportService.GetAllObservations();
        }
        [HttpPost]
        [Route("GetBySearchFilters")]
        public List<PipeReportDTO> GetBySearchFilters([FromBody]PipeReportFilterDTO pipeReportFilterDTO)
        {
            return _PipeReportService.GetBySearchFilters(pipeReportFilterDTO);
        }
        [HttpGet]
        [Route("GenerateReportNo")]
        public string GenerateReportNo(string year)
        {
            return _PipeReportService.GenerateReportNo(year);
        }

    }
}
