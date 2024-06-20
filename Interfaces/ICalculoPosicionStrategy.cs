using MiProyectoAPI.Models;

public interface ICalculoPosicionStrategy
{
    int CalcularPosicion(List<Participante> participantes, int id);
}
