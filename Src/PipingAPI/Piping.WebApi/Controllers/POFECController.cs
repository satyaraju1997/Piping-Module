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
    public class POFECController : Controller
    {


        private readonly IPOFECService _POFECService;
        private readonly IMapper _mapper;

        private readonly ILogger<POFECController> _logger;
        public POFECController(IPOFECService POFECService, IMapper mapper, ILogger<POFECController> logger)
        {
            _POFECService = POFECService;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<POFECDTO> GetAll()
        {
            List<POFECDTO> result = new List<POFECDTO>();

            try
            {
                result = _POFECService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }

        [HttpGet("{ID}")]
        public POFECDTO Get(int ID)
        {
            return _POFECService.GetByID(ID);
        }

        [HttpGet("GetByEquipmentNo")]
        public POFECDTO GetByEquipmentNo(string EquipmentNo)
        {
            return _POFECService.GetByEquipmentNo(EquipmentNo);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]POFECDTO POFECDTO)
        {
             _POFECService.Create(POFECDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]POFECDTO POFECDTO)
        {
             _POFECService.Update(POFECDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
             _POFECService.Delete(ID);
        }


    }
}
