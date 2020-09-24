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
    //[EnableCors("AllowMyOrigin")]
    public class PlantController : Controller
    {

       
        private readonly IPlantService _plantService;
        private readonly IMapper _mapper;
        
        private readonly ILogger<PlantController> _logger;
        public PlantController(IPlantService plantService, IMapper mapper, ILogger<PlantController>  logger)
        {
            _plantService = plantService;
            _mapper = mapper;
            _logger = logger ;
        }
       
        [HttpGet]
        [Route("GetPlants")]        
        public List<PlantDTO> GetPlants()
        {
            List<PlantDTO> result = new List<PlantDTO>();

            try
            {
                result = _plantService.GetPlants();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return _plantService.GetPlants();
        }

        
    }
}
