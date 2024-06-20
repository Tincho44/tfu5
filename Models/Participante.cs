using System.ComponentModel.DataAnnotations;

namespace MiProyectoAPI.Models
{
    public class Participante
    {
        [Key]
        public int Ci { get; set; }
        public string? Nombre { get; set; }
        public int DisciplinaId { get; set; }
        public Disciplina? Disciplina { get; set; }
        public double Puntaje { get; set; }
    }
}
