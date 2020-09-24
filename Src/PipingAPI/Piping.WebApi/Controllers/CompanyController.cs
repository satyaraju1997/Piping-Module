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
    public class CompanyController : Controller
    {


        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        private readonly ILogger<CompanyController> _logger;
        public CompanyController(ICompanyService companyService, IMapper mapper, ILogger<CompanyController> logger)
        {
            _companyService = companyService;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<CompanyDTO> GetAll()
        {
            List<CompanyDTO> result = new List<CompanyDTO>();

            try
            {
                result = _companyService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }
        
        [HttpGet("{ID}")]
        public CompanyDTO Get(int ID)
        {
            return _companyService.GetByCompanyID(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]CompanyRequestDTO companyRequestDTO)
        {
             _companyService.CreateCompany(companyRequestDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]CompanyRequestDTO companyRequestDTO)
        {
             _companyService.UpdateCompany(companyRequestDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{ID}")]
        public void Delete(int ID)
        {
             _companyService.DeleteCompany(ID);
        }


    }
}
