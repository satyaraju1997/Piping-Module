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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace Piping.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [EnableCors("AllowMyOrigin")]
    public class CorrosionStudyController : Controller
    {


        private readonly ICorrosionStudyService _CorrosionStudyService;
        private readonly IMapper _mapper;

        private readonly ILogger<CorrosionStudyController> _logger;
        public CorrosionStudyController(ICorrosionStudyService CorrosionStudyService, IMapper mapper, ILogger<CorrosionStudyController> logger)
        {
            _CorrosionStudyService = CorrosionStudyService;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<CorrosionStudyDTO> GetAll()
        {
            List<CorrosionStudyDTO> result = new List<CorrosionStudyDTO>();

            try
            {
                result = _CorrosionStudyService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }

        [HttpPost]
        [Route("GetBySearchFilters")]
        public List<CorrosionStudyDTO> GetBySearchFilters([FromBody]CorrosionStudyFilterDTO corrosionStudyFilterDTO)
        {
            return _CorrosionStudyService.GetBySearchFilters(corrosionStudyFilterDTO);
        }


        [HttpGet("{ID}")]
        public CorrosionStudyDTO Get(int ID)
        {
            return _CorrosionStudyService.GetByID(ID);
        }

        [HttpPost]
        [Route("GetPipeClustersByLoopNo")]
        public CorrosionStudyResponseDTO GetPipeClustersByLoopNo([FromBody]CorrosionStudyFilterDTO corrosionStudyFilterDTO)
        {
            CorrosionStudyResponseDTO result = new CorrosionStudyResponseDTO();

            try
            {
                result = _CorrosionStudyService.GetPipeClustersByLoopNo(corrosionStudyFilterDTO);
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
        [Route("GetByLoopNo")]
        public CorrosionStudyResponseDTO GetByLoopNo(string LoopNo)
        {
            CorrosionStudyResponseDTO result = new CorrosionStudyResponseDTO();

            try
            {
                result = _CorrosionStudyService.GetByLoopNo(LoopNo);
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }

        // POST api/<controller>
        [HttpPost]
        public CorrosionStudyResponseDTO Post([FromForm]IFormCollection formCollections)
        {


            CorrosionStudyRequestDTO CorrosionStudyRequestDTO = new CorrosionStudyRequestDTO();
            if (formCollections.TryGetValue("CorrosionStudyInfo", out var CorrosionStudyRequest))
            {
                CorrosionStudyRequestDTO = JsonConvert.DeserializeObject<CorrosionStudyRequestDTO>(CorrosionStudyRequest[0]);
            }

            return _CorrosionStudyService.Create(CorrosionStudyRequestDTO);
        }     

        // PUT api/<controller>/5
        [HttpPut]
        public CorrosionStudyResponseDTO Put([FromForm]IFormCollection formCollections)
        {
            CorrosionStudyRequestDTO CorrosionStudyRequestDTO = new CorrosionStudyRequestDTO();
            if (formCollections.TryGetValue("CorrosionStudyInfo", out var CorrosionStudyRequest))
            {
                CorrosionStudyRequestDTO = JsonConvert.DeserializeObject<CorrosionStudyRequestDTO>(CorrosionStudyRequest[0]);
            }

            return _CorrosionStudyService.Update(CorrosionStudyRequestDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
             _CorrosionStudyService.Delete(ID);
        }


    }
}
