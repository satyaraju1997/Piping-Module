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
    public class DocumentMasterController : Controller
    {
        private readonly IDocumentService _documentService;
        private readonly IMapper _mapper;
        private readonly ILogger<DocumentMasterController> _logger;
        public DocumentMasterController(IDocumentService documentService, IMapper mapper, ILogger<DocumentMasterController> logger)
        {
            _documentService = documentService;
            _mapper = mapper;
            _logger = logger;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<DocumentDTO> GetByReferenceNo(string DocumentType, string ReferenceNo)
        {
            List<DocumentDTO> result = new List<DocumentDTO>();

            try
            {
                result = _documentService.GetByReferenceNo(DocumentType, ReferenceNo);
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }

        [HttpGet("Get/{id}")]
        public DocumentDTO Get(int ID)
        {
            return _documentService.GetByID(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]DocumentDTO documentDTO)
        {
            _documentService.Create(documentDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]DocumentDTO documentDTO)
        {
            _documentService.Update(documentDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
            _documentService.Delete(ID);
        }


    }
}
