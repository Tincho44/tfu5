using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiProyectoAPI.Models;

namespace MiProyectoAPI.Repositories
{
    public class ParticipanteRepository : IParticipanteRepository
    {
        private readonly AppDbContext _context;

        public ParticipanteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Participante>> GetAllAsync()
        {
            return await _context.Participantes.Include(p => p.Disciplina).ToListAsync();
        }

        public async Task<Participante> GetByIdAsync(int id)
        {
            return await _context.Participantes.Include(p => p.Disciplina).FirstOrDefaultAsync(p => p.Ci == id);
        }

        public async Task AddAsync(Participante participante)
        {
            await _context.Participantes.AddAsync(participante);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Participante participante)
        {
            _context.Participantes.Update(participante);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante != null)
            {
                _context.Participantes.Remove(participante);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> CalcularPosicionAsync(int id)
        {
            var participantes = await _context.Participantes.OrderByDescending(p => p.Puntaje).ToListAsync();
            var posicion = participantes.FindIndex(p => p.Ci == id) + 1;
            return posicion > 0 ? posicion : -1;
        }

        public async Task<IEnumerable<Participante>> OrdenarParticipantesAsync(int disciplinaId)
        {
            return await _context.Participantes
                                 .Where(p => p.DisciplinaId == disciplinaId)
                                 .OrderByDescending(p => p.Puntaje)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Participante>> ObtenerParticipantesPorDisciplinaAsync(int disciplinaId)
        {
            return await _context.Participantes
                                 .Where(p => p.DisciplinaId == disciplinaId)
                                 .ToListAsync();
        }

        public async Task SetPuntajeAsync(int id, double puntaje)
        {
            var participante = await _context.Participantes.FindAsync(id);
            if (participante != null)
            {
                participante.Puntaje = puntaje;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Participante>> GetClasificacionesAsync()
        {
            return await _context.Participantes
                                 .Include(p => p.Disciplina)
                                 .OrderByDescending(p => p.Puntaje)
                                 .ToListAsync();
        }

        public async Task<double?> GetPuntajeAsync(int id)
        {
            var participante = await _context.Participantes.FindAsync(id);
            return participante?.Puntaje;
        }
    }
}
