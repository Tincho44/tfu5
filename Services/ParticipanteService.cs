using MiProyectoAPI.Models;

namespace MiProyectoAPI.Services
{
    public class ParticipanteService
    {
        private readonly ICalculoPosicionStrategy _calculoPosicionStrategy;

        public ParticipanteService(ICalculoPosicionStrategy calculoPosicionStrategy)
        {
            _calculoPosicionStrategy = calculoPosicionStrategy;
        }

        public int CalcularPosicion(List<Participante> participantes, int id)
        {
            return _calculoPosicionStrategy.CalcularPosicion(participantes, id);
        }
    }
}
