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
using Piping.Entities;

namespace Piping.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [EnableCors("AllowMyOrigin")]
    public class POFICController : Controller
    {


        private readonly IPOFICService _POFICService;
        private readonly IMapper _mapper;

        private readonly ILogger<POFICController> _logger;
        public POFICController(IPOFICService POFICService, IMapper mapper, ILogger<POFICController> logger)
        {
            _POFICService = POFICService;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<POFICDTO> GetAll()
        {
            List<POFICDTO> result = new List<POFICDTO>();

            try
            {
                result = _POFICService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }
        [HttpGet]
        [Route("GetPOF_IC_Details")]
        public List<Entities.POF_IC> GetPOF_IC_Details(string EQUIPMENT_NO, string PRESENT_YEAR)
        {
            return _POFICService.GetPOF_IC_Details(EQUIPMENT_NO, PRESENT_YEAR);
        }

        [HttpGet("{ID}")]
        public POFICDTO Get(int ID)
        {
            return _POFICService.GetByID(ID);
        }

        [HttpGet("GetByPipeNo")]
        public POFICDTO GetByPipeNo(string EquipmentNo)
        {
            return _POFICService.GetByPipeNo(EquipmentNo);
        }

        [HttpGet("GetByEquipmentNo")]
        public POF_IC GetByEquipmentNo(string EquipmentNo)
        {
            return _POFICService.GetByEquipmentNo(EquipmentNo);
        }
        [HttpGet("GetByUnitID")]
        public POF_IC GetByUnitID(int UnitID)
        {
            return _POFICService.GetByUnitID(UnitID);
        }

        [HttpPost("CalculateMassPOF")]
        public void CalculateMassPOF()
        {
            _POFICService.CalculateMassPOF();
        }      

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]POFICDTO POFICDTO)
        {
             _POFICService.Create(POFICDTO);
        }

        // PUT api/<controller>
        [HttpPut]
        public void Put([FromBody]POFICDTO POFICDTO)
        {
            _POFICService.Update(POFICDTO);
        }

        // PUT api/<controller>/5
        [HttpPut("Update")]
        public void Update(string EQUIPMENT_NO, decimal PRESENT_YEAR, decimal EFFICIENCY_OF_WELD_E, decimal YOUNGS_MODULUS_Y)
        {
             _POFICService.Update( EQUIPMENT_NO,  PRESENT_YEAR,  EFFICIENCY_OF_WELD_E,  YOUNGS_MODULUS_Y);
        }


        // DELETE api/<controller>/5
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
             _POFICService.Delete(ID);
        }


    }
}
