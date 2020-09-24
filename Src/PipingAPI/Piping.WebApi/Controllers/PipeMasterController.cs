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
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.IO;
using System.Net.Http.Headers;
using Piping.Helper;
using System.Security.Authentication;
using System.Security.Claims;

namespace Piping.WebApi.Controllers
{
    [Route("api/v1/[controller]")]
    [EnableCors("AllowMyOrigin")]
    public class PipeMasterController : Controller
    {
        private readonly IPipeMasterService _pipeMasterService;
        private readonly IMapper _mapper;
        private readonly ILogger<PipeMasterController> _logger;
        public PipeMasterController(IPipeMasterService pipeMasterService, IMapper mapper, ILogger<PipeMasterController> logger)
        {
            _pipeMasterService = pipeMasterService;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<PipeMasterDTO> GetAll()
        {
            List<PipeMasterDTO> result = new List<PipeMasterDTO>();

            try
            {
                result = _pipeMasterService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }

        //GET api/<controller>/5
        [HttpGet("{ID}")]
        public PipeMasterDTO Get(int ID)
        {
            return _pipeMasterService.GetByID(ID);
        }

        //GET api/<controller>/GetByEquipmentNo?EquipmentNo=P01.AL1001
        [HttpGet("GetByEquipmentNo")]
        public PipeMasterDTO GetByEquipmentNo(string EquipmentNo)
        {
            return _pipeMasterService.GetByEquipmentNo(EquipmentNo);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
            _pipeMasterService.Delete(ID);
        }

       
        [HttpPost("Upload")]
        public async Task<IActionResult> UploadAsync(IFormFile formFile)
        {           
            try
            {
                if (!Request.Form.Files.Any())
                {
                    return BadRequest("File is empty");
                }

                IFormFile file = Request.Form.Files["formFile"];
                int rows = 0;
                long size = file.Length;
                string folderName = "Uploads";
                string pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    //var tempFile = Path.GetTempFileName();
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var filePath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    string jsonPipeMaster = Piping.Helper.FileReader.Read(filePath);

                    rows = _pipeMasterService.BulkInsert(jsonPipeMaster);

                    return Ok(new { dbPath, size });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Import")]
        public async Task<IActionResult> ImportAsync(string json)
        {
            try
            {         
                int rows =  _pipeMasterService.BulkInsert(json);

                if(rows > 0)
                    return Ok(new { rows });
                else               
                    return BadRequest();
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region Basic Tab
        // GET api/<controller>/GetBasicData?ID=1
        [HttpGet("GetBasicData")]
        public PipelineBasicDTO GetBasicData(int ID)
        {
            return _pipeMasterService.GetBasicData(ID);
        }

        [HttpPut("UpdateBasicData")]
        public void UpdateBasicData([FromBody]PipelineBasicDTO pipelineBasicDTO)
        {
            pipelineBasicDTO.ModifiedBy = GetLoggedUser();
            _pipeMasterService.UpdateBasicData(pipelineBasicDTO);
        }
        #endregion

        #region Design Tab
        [HttpGet("GetDesignData")]
        public PipelineDesignDTO GetDesignData(int ID)
        {
            return _pipeMasterService.GetDesignData(ID);
        }

        [HttpPost("UpdateDesignData")]
        public void UpdateDesignData([FromBody]PipelineDesignDTO pipelineDesignDTO)
        {
            _pipeMasterService.UpdateDesignData(pipelineDesignDTO);
        }

        [HttpPost("CalculateDesignBulkData")]
        public void CalculateDesignBulkData()
        {
            _pipeMasterService.CalculateDesignBulkData();
        }
        #endregion

        #region COF Tab
        [HttpGet("GetCOFData")]
        public PipeMasterCOFDTO GetCOFData(int ID)
        {
            return _pipeMasterService.GetCOFData(ID);
        }
        #endregion

        string GetLoggedUser()
        {
            if (!User.Identity.IsAuthenticated)
                throw new AuthenticationException();

            string user = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name).Value;

            return user;
        }
    }
}
