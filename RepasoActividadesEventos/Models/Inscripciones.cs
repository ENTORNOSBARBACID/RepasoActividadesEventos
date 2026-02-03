namespace RepasoActividadesEventos.Models
{
    public class Inscripciones
    {
        public int IdInscripcion { get; set; }
        public int IdUsuario { get; set; }
        public int IdEventoActividad { get; set; }
        public bool QuiereSerCapitan { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public string NombreActividad { get; set; }
    }
}
