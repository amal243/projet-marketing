using Microsoft.AspNetCore.Mvc;
using gestion_marketing.Services.Interfaces;
using gestion_marketing.DTOs;
using gestion_marketing.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestion_marketing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CampagnesController : ControllerBase
    {
        private readonly ICampagneService _campagneService;

        public CampagnesController(ICampagneService campagneService)
        {
            _campagneService = campagneService;
        }

        // GET: api/Campagnes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var campagnes = await _campagneService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<CampagneDto>>(true, "Liste des campagnes récupérée", campagnes));
        }

        // GET: api/Campagnes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var campagne = await _campagneService.GetByIdAsync(id);
            if (campagne == null)
                return NotFound(new ApiResponse<CampagneDto>(false, "Campagne non trouvée", null));

            return Ok(new ApiResponse<CampagneDto>(true, "Campagne trouvée", campagne));
        }

        // POST: api/Campagnes
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCampagneDto dto)
        {
            var created = await _campagneService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id },
                new ApiResponse<CampagneDto>(true, "Campagne créée", created));
        }

        // PUT: api/Campagnes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateCampagneDto dto)
        {
            var updated = await _campagneService.UpdateAsync(id, dto);
            if (!updated)
                return NotFound(new ApiResponse<string>(false, "Campagne non trouvée", null));

            return Ok(new ApiResponse<string>(true, "Campagne mise à jour", null));
        }

        // DELETE: api/Campagnes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _campagneService.DeleteAsync(id);
            if (!result)
                return NotFound(new ApiResponse<string>(false, "Campagne non trouvée", null));

            return Ok(new ApiResponse<string>(true, "Campagne supprimée", null));
        }
    }
}
