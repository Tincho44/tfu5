namespace MiProyectoAPI.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        public ICollection<Participante>? Participantes { get; set; }
    }
}
