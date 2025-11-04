using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestion_marketing.Data;
using gestion_marketing.Models;
using gestion_marketing.Helpers;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace gestion_marketing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CanauxController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CanauxController(AppDbContext context)
        {
            _context = context;
        }

        // GET : api/Canaux
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var canaux = await _context.Canaux.ToListAsync();
            return Ok(new ApiResponse<IEnumerable<Canal>>(true, "Liste des canaux récupérée avec succès", canaux));
        }

        // GET : api/Canaux/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var canal = await _context.Canaux.FindAsync(id);
            if (canal == null)
                return NotFound(new ApiResponse<Canal>(false, "Canal non trouvé", null));

            return Ok(new ApiResponse<Canal>(true, "Canal trouvé", canal));
        }

        // POST : api/Canaux
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Canal canal)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<string>(false, "Données invalides", null));

            _context.Canaux.Add(canal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = canal.Id },
                new ApiResponse<Canal>(true, "Canal créé avec succès", canal));
        }

        // PUT : api/Canaux/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Canal canal)
        {
            if (id != canal.Id)
                return BadRequest(new ApiResponse<string>(false, "L'ID du canal ne correspond pas", null));

            var existingCanal = await _context.Canaux.FindAsync(id);
            if (existingCanal == null)
                return NotFound(new ApiResponse<Canal>(false, "Canal non trouvé", null));

            // Mise à jour des champs
            existingCanal.Nom = canal.Nom;
            existingCanal.Description = canal.Description;

            _context.Entry(existingCanal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<Canal>(true, "Canal mis à jour avec succès", existingCanal));
        }

        // DELETE : api/Canaux/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var canal = await _context.Canaux.FindAsync(id);
            if (canal == null)
                return NotFound(new ApiResponse<string>(false, "Canal non trouvé", null));

            _context.Canaux.Remove(canal);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string>(true, "Canal supprimé avec succès", null));
        }
    }
}
