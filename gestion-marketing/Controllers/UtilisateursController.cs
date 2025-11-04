using Microsoft.AspNetCore.Mvc;
using gestion_marketing.Data;
using gestion_marketing.Models;
using gestion_marketing.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace gestion_marketing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UtilisateursController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UtilisateursController(AppDbContext context)
        {
            _context = context;
        }

        // GET : api/Utilisateurs
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var utilisateurs = await _context.Utilisateurs.ToListAsync();
            return Ok(new ApiResponse<IEnumerable<Utilisateur>>(true, "Liste des utilisateurs récupérée avec succès", utilisateurs));
        }

        // GET : api/Utilisateurs/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
                return NotFound(new ApiResponse<Utilisateur>(false, "Utilisateur non trouvé", null));

            return Ok(new ApiResponse<Utilisateur>(true, "Utilisateur trouvé", utilisateur));
        }

        // POST : api/Utilisateurs
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Utilisateur utilisateur)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ApiResponse<string>(false, "Données invalides", null));

            _context.Utilisateurs.Add(utilisateur);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = utilisateur.Id },
                new ApiResponse<Utilisateur>(true, "Utilisateur créé avec succès", utilisateur));
        }

        // PUT : api/Utilisateurs/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Utilisateur utilisateur)
        {
            if (id != utilisateur.Id)
                return BadRequest(new ApiResponse<string>(false, "L'ID de l'utilisateur ne correspond pas", null));

            if (!await _context.Utilisateurs.AnyAsync(u => u.Id == id))
                return NotFound(new ApiResponse<string>(false, "Utilisateur non trouvé", null));

            _context.Entry(utilisateur).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<Utilisateur>(true, "Utilisateur mis à jour avec succès", utilisateur));
        }

        // DELETE : api/Utilisateurs/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var utilisateur = await _context.Utilisateurs.FindAsync(id);
            if (utilisateur == null)
                return NotFound(new ApiResponse<string>(false, "Utilisateur non trouvé", null));

            _context.Utilisateurs.Remove(utilisateur);
            await _context.SaveChangesAsync();

            return Ok(new ApiResponse<string>(true, "Utilisateur supprimé avec succès", null));
        }
    }
}
