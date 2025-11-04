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
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _clientService.GetAllAsync();
            return Ok(new ApiResponse<IEnumerable<ClientDto>>(true, "Liste des clients récupérée", clients));
        }

        // GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _clientService.GetByIdAsync(id);
            if (client == null)
                return NotFound(new ApiResponse<ClientDto>(false, "Client non trouvé", null));

            return Ok(new ApiResponse<ClientDto>(true, "Client trouvé", client));
        }

        // CREATE
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateClientDto dto)
        {
            var createdClient = await _clientService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdClient.Id },
                new ApiResponse<ClientDto>(true, "Client créé avec succès", createdClient));
        }

        // UPDATE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateClientDto dto)
        {
            var updatedClient = await _clientService.UpdateAsync(id, dto);
            if (updatedClient == null)
                return NotFound(new ApiResponse<ClientDto>(false, "Client non trouvé", null));

            return Ok(new ApiResponse<ClientDto>(true, "Client mis à jour", updatedClient));
        }

        // DELETE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _clientService.DeleteAsync(id);
            if (!deleted)
                return NotFound(new ApiResponse<string>(false, "Client non trouvé", null));

            return Ok(new ApiResponse<string>(true, "Client supprimé avec succès", null));
        }
    }
}
