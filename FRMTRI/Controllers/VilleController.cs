using Application.Interfaces.IServices;
using Application.Models.DTOs.Ville;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FRMTRI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Application.Constants;
using Application.Wrappers;

namespace FRMTRI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VilleController : ControllerBase
    {
        #region Header
        private readonly IVilleService _villeService;
        private readonly ILogger<VilleController> _logger;
        public VilleController(IVilleService villeService, ILogger<VilleController> logger)
        {
            _villeService = villeService;
            _logger = logger;
        }
        #endregion

        #region Actions

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VilleForListDto>>> Get()
        {
            try
            {
                var villes = (await _villeService.GetAllVilles()).ToList();
                return villes;
            }
            catch (Exception ex)
            {
                _logger.LogError(exception: ex, controller: this);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VilleForDetailDto>> Get(int id)
        {
            return await _villeService.GetVilleById(id);
        }

        
        [HttpPost("Register")]
        public async Task<ActionResult> RegisterVille(VilleForInsertDto villeForInsertDto)
        {
            try
            {
                Response<bool> response = await _villeService.Insert(villeForInsertDto);
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

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateVille(int id, VilleForUpdateDto villeForUpdateDto)
        {
            try
            {
                Response<bool> response = await _villeService.Update(villeForUpdateDto);
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

        // DELETE api/<VilleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion

        #region Functions

        #endregion

    }
}
