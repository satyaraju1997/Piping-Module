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
    public class MaterialMasterController : Controller
    {
        private readonly IMaterialMasterService _MaterialMasterService;
        private readonly IMapper _mapper;
        private readonly ILogger<MaterialMasterController> _logger;
        private IMemoryCache _cache;
        public MaterialMasterController(IMaterialMasterService MaterialMasterService, IMapper mapper, ILogger<MaterialMasterController> logger, IMemoryCache memoryCache)
        {
            _MaterialMasterService = MaterialMasterService;
            _mapper = mapper;
            _logger = logger;
            _cache = memoryCache;
        }

        //GET api/<controller>
        [HttpGet]
        [Route("GetAll")]
        public List<MaterialMasterDTO> GetAll()
        {
            List<MaterialMasterDTO> result = new List<MaterialMasterDTO>();

            try
            {
                result = _MaterialMasterService.GetAll();
                _logger.LogDebug("Result returned");
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "");
            }

            return result;
        }
        
        [HttpGet("Get")]
        public MaterialMasterDTO Get(int ID)
        {
            return _MaterialMasterService.GetByID(ID);
        }

        // POST api/<controller>
        [HttpPost]
        public MaterialMasterDTO Post([FromBody]MaterialMasterDTO MaterialMasterDTO)
        {
            return _MaterialMasterService.Create(MaterialMasterDTO);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public MaterialMasterDTO Put([FromBody]MaterialMasterDTO MaterialMasterDTO)
        {
          return  _MaterialMasterService.Update(MaterialMasterDTO);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int ID)
        {
            _MaterialMasterService.Delete(ID);
        }

        /// <summary>
        /// Gets the Material Std list for dropdown values.
        /// </summary>
        /// <returns></returns>
        [HttpGet("MaterialStdDropdownList")]
        public IActionResult GetMaterialStdDropdownList()
        {
            ICollection<DropdownDTO> result = new List<DropdownDTO>();

            if (!_cache.TryGetValue(CacheKeys.MATERIAL_STD_DROPDOWN_LIST, out result))
            {
                // Key not in cache, so get data.
                try
                {
                    result = _MaterialMasterService.GetMaterialStdDropdownList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromSeconds(CacheKeys.CACHING_EXPIRATION));
                    _cache.Set(CacheKeys.MATERIAL_STD_DROPDOWN_LIST, result, cacheEntryOptions);

                }
                catch (Exception exception)
                {
                    _logger.LogError(exception, string.Empty);
                }
            }
            return Ok(result);
        }

        /// <summary>
        /// Gets the Material Grade list for dropdown values.
        /// </summary>
        /// <returns></returns>
        [HttpGet("MaterialGradeDropdownList")]
        public IActionResult GetMaterialGradeDropdownList()
        {
            ICollection<DropdownDTO> result = new List<DropdownDTO>();

            if (!_cache.TryGetValue(CacheKeys.MATERIAL_GRADE_DROPDOWN_LIST, out result))
            {
                // Key not in cache, so get data.
                try
                {
                    result = _MaterialMasterService.GetMaterialGradeDropdownList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromSeconds(CacheKeys.CACHING_EXPIRATION));
                    _cache.Set(CacheKeys.MATERIAL_GRADE_DROPDOWN_LIST, result, cacheEntryOptions);

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
