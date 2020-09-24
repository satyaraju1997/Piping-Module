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
    public class POFODMController : Controller
    {


        private readonly IPOFODMService _POFODMService;
        private readonly IMapper _mapper;

        private readonly ILogger<POFODMController> _logger;
        public POFODMController(IPOFODMService POFODMService, IMapper mapper, ILogger<POFODMController> logger)
        {
            _POFODMService = POFODMService;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<POFDMDTO> GetAll()
        {
            List<POFDMDTO> result = new List<POFDMDTO>();

            try
            {
                result = _POFODMService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }

        [HttpGet("Get/{id}")]
        public POFDMDTO Get(int ID)
        {
            return _POFODMService.GetByID(ID);
        }

        [HttpGet("GetByEquipmentNo")]
        public POFDMDTO GetByEquipmentNo(string EquipmentNo)
        {
            return _POFODMService.GetByEquipmentNo(EquipmentNo);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]POFDMDTO POFODMDTO)
        {
             _POFODMService.Create(POFODMDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]POFDMDTO POFODMDTO)
        {
             _POFODMService.Update(POFODMDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
             _POFODMService.Delete(ID);
        }


    }
}
