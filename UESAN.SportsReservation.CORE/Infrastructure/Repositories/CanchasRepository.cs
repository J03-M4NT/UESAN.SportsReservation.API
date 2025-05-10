using Microsoft.EntityFrameworkCore;
using UESAN.Ecommerce.CORE.Infrastructure.Repositories;
using UESAN.SportsReservation.API.Infrastructure.Data;
using UESAN.SportsReservation.CORE.Core.Entities;


namespace UESAN.SportsReservation.CORE.Infrastructure.Repositories
{
    public class CanchasRepository : ICanchaRepository
    {
        private readonly SportsReservationDbContext _context;

        public CanchasRepository(SportsReservationDbContext context)
        {
            _context = context;
        }

        // Obtener todas las canchas
        public IEnumerable<Canchas> GetAllCanchas()
        {
            var canchas = _context.Canchas.Where(x => x.IsActive == true).ToList();
            return canchas;
        }

        public async Task<IEnumerable<Canchas>> GetAllCanchasAsync()
        {
            return await _context.Canchas.Where(x => x.IsActive == true).ToListAsync();
        }

        // Obtener cancha por ID
        public async Task<Canchas> GetCanchaByIdAsync(int id)
        {
            var cancha = await _context.Canchas.FindAsync(id);
            return cancha;
        }

        // Crear cancha
        public async Task<int> CreateCancha(Canchas cancha)
        {
            await _context.Canchas.AddAsync(cancha);
            await _context.SaveChangesAsync();
            return cancha.Id;
        }

        // Eliminar cancha (eliminación física)
        public async Task DeleteCanchaAsync(int id)
        {
            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha != null)
            {
                _context.Canchas.Remove(cancha);
                await _context.SaveChangesAsync();
            }
        }

        // Eliminar cancha (eliminación lógica)
        public async Task DeleteCanchaSoft(int id)
        {
            var cancha = await _context.Canchas.FindAsync(id);
            if (cancha != null)
            {
                cancha.IsActive = false;
                _context.Canchas.Update(cancha);
                await _context.SaveChangesAsync();
            }
        }

        // Actualizar cancha
        public async Task<bool> UpdateCanchaAsync(Canchas cancha)
        {
            bool result = false;
            var existingCancha = await _context.Canchas.FindAsync(cancha.Id);
            if (existingCancha != null)
            {
                existingCancha.Nombre = cancha.Nombre;
                existingCancha.Tipo = cancha.Tipo;
                existingCancha.Ubicacion = cancha.Ubicacion;
                existingCancha.IsActive = cancha.IsActive;
                _context.Canchas.Update(existingCancha);
                await _context.SaveChangesAsync();
                result = true;
            }
            return result;
        }
    }
}

