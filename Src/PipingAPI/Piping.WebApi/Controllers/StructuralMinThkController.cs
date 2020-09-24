using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
    public class StructuralMinThkController : Controller
    {
        private readonly IStructuralMinThkService _structuralMinThkService;
        private readonly IMapper _mapper;
        private readonly ILogger<StructuralMinThkController> _logger;
        private IMemoryCache _cache;
        public StructuralMinThkController(IStructuralMinThkService structuralMinThkService, IMapper mapper, ILogger<StructuralMinThkController> logger, IMemoryCache memoryCache)
        {
            _structuralMinThkService = structuralMinThkService;
            _mapper = mapper;
            _logger = logger;
            _cache = memoryCache;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<StructuralMinThkDTO> GetAll()
        {
            List<StructuralMinThkDTO> result = new List<StructuralMinThkDTO>();

            try
            {
                result = _structuralMinThkService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }
        
        [HttpGet("Get")]
        public StructuralMinThkDTO Get(int ID)
        {
            return _structuralMinThkService.GetByID(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public StructuralMinThkDTO Post([FromBody]StructuralMinThkDTO structuralMinThkDTO)
        {
            return _structuralMinThkService.Create(structuralMinThkDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public StructuralMinThkDTO Put([FromBody]StructuralMinThkDTO structuralMinThkDTO)
        {
          return  _structuralMinThkService.Update(structuralMinThkDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
            _structuralMinThkService.Delete(ID);
        }

        /// <summary>
        /// Gets the dropdown values.
        /// </summary>
        /// <returns></returns>
        [HttpGet("DropdownList")]
        public IActionResult GetDropdownList()
        {
            ICollection<DropdownDTO> result = new List<DropdownDTO>();

            if (!_cache.TryGetValue(CacheKeys.STRUCTURAL_MIN_THK_DROPDOWN_LIST, out result))
            {
                // Key not in cache, so get data.
                try
                {
                    result = _structuralMinThkService.GetDropdownList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromSeconds(CacheKeys.CACHING_EXPIRATION));
                    _cache.Set(CacheKeys.STRUCTURAL_MIN_THK_DROPDOWN_LIST, result, cacheEntryOptions);

                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, string.Empty);
                }
            }
            return Ok(result);
        }


    }
}
