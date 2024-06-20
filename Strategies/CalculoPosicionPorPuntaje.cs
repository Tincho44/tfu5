using MiProyectoAPI.Models;

namespace MiProyectoAPI.Strategies
{
    public class CalculoPosicionPorPuntaje : ICalculoPosicionStrategy
    {
        public int CalcularPosicion(List<Participante> participantes, int id)
        {
            var posicion = participantes.OrderByDescending(p => p.Puntaje).ToList().FindIndex(p => p.Ci == id) + 1;
            return posicion > 0 ? posicion : -1;
        }
    }
}
