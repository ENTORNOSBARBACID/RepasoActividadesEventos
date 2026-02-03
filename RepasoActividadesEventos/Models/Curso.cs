namespace RepasoActividadesEventos.Models
{
    public class Curso
    {
        public int IdCurso { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public bool Activo { get; set; }
    }
}
