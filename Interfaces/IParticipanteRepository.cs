using MiProyectoAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IParticipanteRepository
{
    Task<IEnumerable<Participante>> GetAllAsync();
    Task<Participante> GetByIdAsync(int id);
    Task AddAsync(Participante participante);
    Task UpdateAsync(Participante participante);
    Task DeleteAsync(int id);
    Task<int> CalcularPosicionAsync(int id);
    Task<IEnumerable<Participante>> OrdenarParticipantesAsync(int disciplinaId);
    Task<IEnumerable<Participante>> ObtenerParticipantesPorDisciplinaAsync(int disciplinaId);
    Task SetPuntajeAsync(int id, double puntaje);
    Task<IEnumerable<Participante>> GetClasificacionesAsync();
    Task<double?> GetPuntajeAsync(int id);
}
