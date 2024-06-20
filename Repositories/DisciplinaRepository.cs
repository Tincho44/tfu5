using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiProyectoAPI.Models;

namespace MiProyectoAPI.Repositories
{
    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly AppDbContext _context;

        public DisciplinaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Disciplina>> GetAllAsync()
        {
            return await _context.Disciplinas.Include(d => d.Categoria).ToListAsync();
        }

        public async Task<Disciplina> GetByIdAsync(int id)
        {
            return await _context.Disciplinas.Include(d => d.Categoria).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddAsync(Disciplina disciplina)
        {
            await _context.Disciplinas.AddAsync(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Disciplina disciplina)
        {
            _context.Disciplinas.Update(disciplina);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var disciplina = await _context.Disciplinas.FindAsync(id);
            if (disciplina != null)
            {
                _context.Disciplinas.Remove(disciplina);
                await _context.SaveChangesAsync();
            }
        }
    }
}
