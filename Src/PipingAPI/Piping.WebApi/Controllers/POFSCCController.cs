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
    public class POFSCCController : Controller
    {


        private readonly IPOFSCCService _POFSCCService;
        private readonly IMapper _mapper;

        private readonly ILogger<POFSCCController> _logger;
        public POFSCCController(IPOFSCCService POFSCCService, IMapper mapper, ILogger<POFSCCController> logger)
        {
            _POFSCCService = POFSCCService;
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
                result = _POFSCCService.GetAll();
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
            return _POFSCCService.GetByID(ID);
        }

        [HttpGet("GetByEquipmentNo")]
        public POFDMDTO GetByEquipmentNo(string EquipmentNo)
        {
            return _POFSCCService.GetByEquipmentNo(EquipmentNo);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]POFDMDTO POFSCCDTO)
        {
             _POFSCCService.Create(POFSCCDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]POFDMDTO POFSCCDTO)
        {
             _POFSCCService.Update(POFSCCDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
             _POFSCCService.Delete(ID);
        }


    }
}
