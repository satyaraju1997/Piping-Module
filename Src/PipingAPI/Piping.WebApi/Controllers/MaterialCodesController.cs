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
    public class MaterialCodesController : Controller
    {
        private readonly IMaterialCodesService _MaterialCodesService;
        private readonly IMapper _mapper;
        private readonly ILogger<MaterialCodesController> _logger;
        private IMemoryCache _cache;
        public MaterialCodesController(IMaterialCodesService MaterialCodesService, IMapper mapper, ILogger<MaterialCodesController> logger, IMemoryCache memoryCache)
        {
            _MaterialCodesService = MaterialCodesService;
            _mapper = mapper;
            _logger = logger;
            _cache = memoryCache;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<MaterialCodesDTO> GetAll()
        {
            List<MaterialCodesDTO> result = new List<MaterialCodesDTO>();

            try
            {
                result = _MaterialCodesService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }
        
        [HttpGet("Get")]
        public MaterialCodesDTO Get(int ID)
        {
            return _MaterialCodesService.GetByID(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public MaterialCodesDTO Post([FromBody]MaterialCodesDTO MaterialCodesDTO)
        {
            return _MaterialCodesService.Create(MaterialCodesDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public MaterialCodesDTO Put([FromBody]MaterialCodesDTO MaterialCodesDTO)
        {
          return  _MaterialCodesService.Update(MaterialCodesDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
            _MaterialCodesService.Delete(ID);
        }

        /// <summary>
        /// Gets the Material Code list for dropdown values.
        /// </summary>
        /// <returns></returns>
        [HttpGet("DropdownList")]
        public IActionResult GetDropdownList()
        {
            ICollection<DropdownDTO> result = new List<DropdownDTO>();

            if (!_cache.TryGetValue(CacheKeys.MATERIAL_CODES_DROPDOWN_LIST, out result))
            {
                // Key not in cache, so get data.
                try
                {
                    result = _MaterialCodesService.GetDropdownList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromSeconds(CacheKeys.CACHING_EXPIRATION));
                    _cache.Set(CacheKeys.MATERIAL_CODES_DROPDOWN_LIST, result, cacheEntryOptions);

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
