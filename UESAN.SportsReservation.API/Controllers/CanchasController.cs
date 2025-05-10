using Microsoft.AspNetCore.Mvc;
using UESAN.SportsReservation.CORE.Core.Entities;
using UESAN.SportsReservation.CORE.Core.Interfaces;

namespace UESAN.SportsReservation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanchasController : ControllerBase
    {
        private readonly ICanchaRepository _canchaRepository;

        public CanchasController(ICanchaRepository canchaRepository)
        {
            _canchaRepository = canchaRepository;
        }

        // GET: api/Canchas
        [HttpGet]
        public async Task<IActionResult> GetCanchas()
        {
            var canchas = await _canchaRepository.GetAllCanchasAsync();
            return Ok(canchas);
        }

        // GET: api/Canchas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCancha(int id)
        {
            var cancha = await _canchaRepository.GetCanchaByIdAsync(id);
            if (cancha == null)
            {
                return NotFound();
            }
            return Ok(cancha);
        }

        // POST: api/Canchas
        [HttpPost]
        public async Task<IActionResult> CreateCancha([FromBody] Canchas cancha)
        {
            if (cancha == null)
            {
                return BadRequest("Cancha is null");
            }
            var newCanchaId = await _canchaRepository.CreateCancha(cancha);
            return Ok(newCanchaId);
        }

        // PUT: api/Canchas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCancha(int id, [FromBody] Canchas cancha)
        {
            if (cancha == null || cancha.Id != id)
            {
                return BadRequest("Cancha is null or ID mismatch");
            }
            var updatedCancha = await _canchaRepository.UpdateCanchaAsync(cancha);
            if (!updatedCancha)
            {
                return NotFound();
            }
            return Ok(updatedCancha);
        }

        // DELETE: api/Canchas/5 (Eliminación física)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCancha(int id)
        {
            var cancha = await _canchaRepository.GetCanchaByIdAsync(id);
            if (cancha == null)
            {
                return NotFound();
            }
            await _canchaRepository.DeleteCanchaAsync(id);
            return NoContent();
        }

        // DELETE: api/Canchas/soft/5 (Eliminación lógica)
        [HttpDelete("soft/{id}")]
        public async Task<IActionResult> DeleteCanchaSoft(int id)
        {
            var cancha = await _canchaRepository.GetCanchaByIdAsync(id);
            if (cancha == null)
            {
                return NotFound();
            }
            await _canchaRepository.DeleteCanchaSoft(id);
            return NoContent();
        }
    }
}
