namespace RepasoActividadesEventos.Models
{
    public class ResumenUsuario
    {
        public Usuarios usu { get; set; }
        public List<Inscripciones> inscripciones { get; set; }
        public string nombreCurso { get; set; }

        public ResumenUsuario()
        {
            inscripciones = new List<Inscripciones>();
        }
    }
}
