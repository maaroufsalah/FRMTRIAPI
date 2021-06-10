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
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<VilleForDetailDto>> Get(int id)
        {
            return await _villeService.GetVilleById(id);
        }

        // POST api/<VilleController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VilleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
