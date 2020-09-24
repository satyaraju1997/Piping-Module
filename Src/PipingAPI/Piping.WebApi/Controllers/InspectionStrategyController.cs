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
    public class InspectionStrategyController : Controller
    {


        private readonly IInspectionStrategyService _InspectionStrategyService;
        private readonly IMapper _mapper;

        private readonly ILogger<InspectionStrategyController> _logger;
        public InspectionStrategyController(IInspectionStrategyService InspectionStrategyService, IMapper mapper, ILogger<InspectionStrategyController> logger)
        {
            _InspectionStrategyService = InspectionStrategyService;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<InspectionStrategyDTO> GetAll()
        {
            List<InspectionStrategyDTO> result = new List<InspectionStrategyDTO>();

            try
            {
                result = _InspectionStrategyService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }
       
        [HttpGet("{ID}")]
        public InspectionStrategyDTO Get(int ID)
        {
            return _InspectionStrategyService.GetByID(ID);
        }
        [HttpGet("GetByEquipmentNo")]
        public List<InspectionStrategyDTO> GetByEquipmentNo(string EquipmentNo)
        {
            return _InspectionStrategyService.GetByEquipmentNo(EquipmentNo);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]InspectionStrategyDTO comanyDTO)
        {
             _InspectionStrategyService.Create(comanyDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]InspectionStrategyDTO comanyDTO)
        {
             _InspectionStrategyService.Update(comanyDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
             _InspectionStrategyService.Delete(ID);
        }


    }
}
