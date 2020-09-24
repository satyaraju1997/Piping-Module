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
    public class InsulationTypeController : Controller
    {
        private readonly IInsulationTypeService _InsulationTypeService;
        private readonly IMapper _mapper;
        private readonly ILogger<InsulationTypeController> _logger;
        private IMemoryCache _cache;
        public InsulationTypeController(IInsulationTypeService InsulationTypeService, IMapper mapper, ILogger<InsulationTypeController> logger,IMemoryCache memoryCache)
        {
            _InsulationTypeService = InsulationTypeService;
            _mapper = mapper;
            _logger = logger;
            _cache = memoryCache;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<InsulationTypeDTO> GetAll()
        {
            List<InsulationTypeDTO> result = new List<InsulationTypeDTO>();

            try
            {
                result = _InsulationTypeService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }
        
        [HttpGet("Get")]
        public InsulationTypeDTO Get(int ID)
        {
            return _InsulationTypeService.GetByID(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public InsulationTypeDTO Post([FromBody]InsulationTypeDTO InsulationTypeDTO)
        {
            return _InsulationTypeService.Create(InsulationTypeDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public InsulationTypeDTO Put([FromBody]InsulationTypeDTO InsulationTypeDTO)
        {
          return  _InsulationTypeService.Update(InsulationTypeDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
            _InsulationTypeService.Delete(ID);
        }

        /// <summary>
        /// Gets the dropdown values.
        /// </summary>
        /// <returns></returns>
        [HttpGet("DropdownList")]
        public IActionResult GetDropdownList()
        {
            ICollection<DropdownDTO> result = new List<DropdownDTO>();

            if (!_cache.TryGetValue(CacheKeys.INSULATION_TYPE_DROPDOWN_LIST, out result))
            {
                // Key not in cache, so get data.
                try
                {
                    result = _InsulationTypeService.GetDropdownList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromSeconds(CacheKeys.CACHING_EXPIRATION));
                    _cache.Set(CacheKeys.INSULATION_TYPE_DROPDOWN_LIST, result, cacheEntryOptions);

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
