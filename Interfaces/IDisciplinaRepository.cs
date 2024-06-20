using MiProyectoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IDisciplinaRepository
{
    Task<IEnumerable<Disciplina>> GetAllAsync();
    Task<Disciplina> GetByIdAsync(int id);
    Task AddAsync(Disciplina disciplina);
    Task UpdateAsync(Disciplina disciplina);
    Task DeleteAsync(int id);
}
