using Application.Interfaces.IServices;
using Application.Models.DTOs.Region;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FRMTRI.Extensions;
using Application.Wrappers;
using Application.Constants;

namespace FRMTRI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _regionService;
        private readonly ILogger<RegionController> _logger;
        public RegionController(IRegionService regionService, ILogger<RegionController> logger)
        {
            _regionService = regionService;
            _logger = logger;

        }
        // GET: api/<RegionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionForListDto>>> Get()
        {
            try
            {
                var region = (await _regionService.GetAllRegion()).ToList();
                return region;
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, controller: this);
                return BadRequest(ex.Message);
            }
        }

        // GET api/<RegionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegionForDetailDto>> Get(int id)
        {
            return await _regionService.GetRegionById(id);
        }


        [HttpPost("Register")]
        public async Task<ActionResult> Register(RegionForInsertDto regionForInsertDto)
        {
            try
            {
                Response<bool> response = await _regionService.Insert(regionForInsertDto);
                if (response.Succeeded)
                    return Ok(response);
                else
                    return BadRequest(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, controller: this);
                return BadRequest(ErrorMessage.SERVICE_UNAVAILABLE);
            }
        }

        // PUT api/<RegionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
